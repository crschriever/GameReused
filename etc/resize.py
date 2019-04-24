import sys
from PIL import Image
import os
import shutil

screenshotSizes = [(2688, 1242), (2208, 1242), (320, 100), (2732, 2048)]
iconSizes = [(180, 180), (120, 120), (167, 167), (152, 152), (512, 512), (1024, 1024)]
adSizes = [
# Square and rectangle	 
(200, 200),	#Small square
(240, 400),	#Vertical rectangle
(250, 250),	#Square
(250, 360),	#Triple widescreen
(300, 250),	#Inline rectangle
(336, 280),	#Large rectangle
(580, 400),	#Netboard
# Skyscraper	 
(120, 600),	#Skyscraper
(160, 600),	#Wide skyscraper
(300, 600),	#Half-page ad
(300, 1050),	#Portrait
# Leaderboard	 
(468, 60),	#Banner
(728, 90),	#Leaderboard
(930, 180),	#Top banner
(970, 90),	#Large leaderboard
(970, 250),	#Billboard
(980, 120),	#Panorama
# Mobile	 
(300, 50),	#Mobile banner
(320, 50),	#Mobile banner
(320, 100),	#Large mobile banner
]

def main():
    ads = sys.argv[2] == "a"
    screenshots = sys.argv[2] == "s"
    icon = sys.argv[2] == "i"

    sizes = screenshotSizes
    if ads:
        sizes = adSizes
    elif icon:
        sizes = iconSizes

    portrait = True if (len(sys.argv) >= 4 and sys.argv[3] == "p") else False
    directory = sys.argv[1]
    outDir = directory + "\\resized"
    shutil.rmtree(outDir, ignore_errors=True)
    os.mkdir(outDir)
    for filename in os.listdir(directory):
        if filename.endswith(".png") or filename.endswith(".PNG"):
            noExt = os.path.splitext(filename)[0]
            ext = os.path.splitext(filename)[1]
            with open(directory + "\\" + filename, 'r+b') as f:
                with Image.open(f) as image:
                    for width, height in sizes:
                        if portrait:
                            temp = width
                            width = height
                            height = temp
                        image = remove_transparency(image)
                        image = image.resize((width, height), Image.ANTIALIAS)
                        image.save(outDir + "\\" + noExt + '@' + str(width) + "x" + str(height) + ext, image.format)

                    if screenshots:
                        image = remove_transparency(image)
                        image = image.resize((1024, 500), Image.ANTIALIAS)
                        image.save(outDir + "\\" + noExt + '-promo' + ext, image.format)

def remove_transparency(im, bg_colour=(255, 255, 255)):

    # Only process if image has transparency (http://stackoverflow.com/a/1963146)
    if im.mode in ('RGBA', 'LA') or (im.mode == 'P' and 'transparency' in im.info):

        # Need to convert to RGBA if LA format due to a bug in PIL (http://stackoverflow.com/a/1963146)
        alpha = im.convert('RGBA').split()[-1]

        # Create a new background image of our matt color.
        # Must be RGBA because paste requires both images have the same format
        # (http://stackoverflow.com/a/8720632  and  http://stackoverflow.com/a/9459208)
        bg = Image.new("RGBA", im.size, bg_colour + (255,))
        bg.paste(im, mask=alpha)
        return bg

    else:
        return im

if __name__== "__main__":
    main()
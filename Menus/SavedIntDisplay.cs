using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SavedIntDisplay : MonoBehaviour
{

    public string FORMAT_STRING;
    public string ID;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (PlayerPrefs.HasKey(ID))
        {
            text.text = string.Format(FORMAT_STRING, PlayerPrefs.GetInt(ID) + "");
        }
        else
        {
            text.text = string.Format(FORMAT_STRING, "Unknown");
        }
    }
}

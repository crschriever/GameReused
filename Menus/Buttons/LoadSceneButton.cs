using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{

    public string SCENE_NAME;
    public void LoadScene()
    {
        SceneManager.LoadScene(SCENE_NAME);
    }
}

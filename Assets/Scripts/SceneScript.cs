using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OpenSpelScene()
    {
        Debug.Log("OpenMapScene aangeroepen");
        SceneManager.LoadScene("Spel");
    }

    public void OpenStartScene()
    {
        Debug.Log("OpenStartScene aangeroepen");
        SceneManager.LoadSceneAsync("Start scherm");
    }

    public void OpenInlogScene()
    {
        Debug.Log("OpenInlogScene aangeroepen");
        SceneManager.LoadSceneAsync("Inlog_register scherm");
    }
}

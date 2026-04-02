using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public void OpenSpelScene()
    {
        Debug.Log("OpenSpelScene aangeroepen");
        SceneManager.LoadScene("Spel");
    }

    public void OpenMapScene()
    {
        Debug.Log("OpenMapScene aangeroepen");
        SceneManager.LoadScene("Map");
    }

    public void OpenStartScene()
    {
        Debug.Log("OpenStartScene aangeroepen");
        SceneManager.LoadSceneAsync("Start scherm");
    }

    public void OpenInlogSceneOfAccuontScene()
    {
        Debug.Log("OpenInlogScene/AccountScene aangeroepen");

        if (ApiClient.Instance.ingelogd)
        {
            SceneManager.LoadSceneAsync("AccountInfoScherm");
        }
        else
        {
            SceneManager.LoadSceneAsync("Inlog_register scherm");
        }
    }
}

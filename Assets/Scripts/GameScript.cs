using UnityEngine;

public class GameScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject infoPaneel;

    public void InfoKnop()
    {
        infoPaneel.SetActive(true);
        Debug.Log("InfoKnop clicked");
    }

    public void StartKnop()
    {
        infoPaneel.SetActive(false);
        Debug.Log("StartKnop clicked");
    }
}
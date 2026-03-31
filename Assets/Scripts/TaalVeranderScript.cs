using TMPro;
using UnityEngine;

public class TaalVeranderScript : MonoBehaviour
{
    public GameObject nederlandseVlag;
    public GameObject engelseVlag;

    void Awake()
    {
        Debug.Log("TaalVeranderScript Awake aangeroepen");
        if(TaalManager.Instance.huidigeTaal == TaalManager.Taal.EN)
        {
            nederlandseVlag.SetActive(false);
            engelseVlag.SetActive(true);
        }
        else
        {
            engelseVlag.SetActive(false);
            nederlandseVlag.SetActive(true);
        }
    }

    public void VeranderNaarNederlands()
    {
        Debug.Log("Nederlands geklikt");
        TaalManager.Instance.SetTaal(TaalManager.Taal.NL);
        nederlandseVlag.SetActive(true);
        engelseVlag.SetActive(false);
    }

    public void VeranderNaarEngels()
    {
        Debug.Log("Engels geklikt!");
        TaalManager.Instance.SetTaal(TaalManager.Taal.EN);
        engelseVlag.SetActive(true);
        nederlandseVlag.SetActive(false);
    }
}

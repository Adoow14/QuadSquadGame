using TMPro;
using UnityEngine;

public class TaalVeranderScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI titelStart;
    public TextMeshProUGUI tekstStart;
    public GameObject nederlandseVlag;
    public GameObject engelseVlag;

    public void VeranderNaarNederlands()
    {
        titelStart.text = "Wind Avontuur";
        tekstStart.text = "Ben je klaar voor jou avontuur?";
        nederlandseVlag.SetActive(false);
        engelseVlag.SetActive(true);
    }

    public void VeranderNaarEngels()
    {
        Debug.Log("Engels geklikt!");
        titelStart.text = "Wind Adventure";
        tekstStart.text = "Are you ready for your adventure?";
        engelseVlag.SetActive(false);
        nederlandseVlag.SetActive(true);
    }
}

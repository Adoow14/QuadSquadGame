using UnityEngine;
using TMPro;
public class Stap : MonoBehaviour
{
    public TMP_Text mijnTekst;
    public int stapNummer;

    void Start()
    {
        mijnTekst.text = stapNummer;
    }
}

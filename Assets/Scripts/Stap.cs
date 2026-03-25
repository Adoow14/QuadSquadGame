using UnityEngine;
using TMPro;
public class Stap : MonoBehaviour
{
    [SerializeField] private TMP_Text stapTekst;

    void Start()
    {
        int index = transform.GetSiblingIndex() + 1;
        stapTekst.text = index.ToString();
    }
}

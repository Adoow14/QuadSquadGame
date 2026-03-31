using TMPro;
using UnityEngine;


public class LokaleTekst : MonoBehaviour
{
    public string key;

    private TextMeshProUGUI tekstComponent;

    void Awake()
    {
        tekstComponent = GetComponent<TextMeshProUGUI>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTekst();
        TaalManager.Instance.OnTaalVeranderd += UpdateTekst;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if(TaalManager.Instance != null)
        {
            TaalManager.Instance.OnTaalVeranderd -= UpdateTekst;
        }
    }

    void UpdateTekst()
    {
        tekstComponent.text = TaalManager.Instance.GetTekst(key);
    }
}

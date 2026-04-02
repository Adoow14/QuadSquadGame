using System;
using TMPro;
using UnityEngine;

public class AccountInfoScript : MonoBehaviour
{
    public TextMeshProUGUI TitelTekst;
    public TextMeshProUGUI NaamTekst;
    public TextMeshProUGUI LeeftijdTekst;
    public TextMeshProUGUI DokterTekst;
    public TextMeshProUGUI BehandelingDatumTekst;
    public TextMeshProUGUI BehandTypeTekst;


    void Awake()
    {
        ApiClient.Instance.StartCoroutine(ApiClient.Instance.GetDossier(OnAccountInfoSuccess));
    }

    private void OnAccountInfoSuccess(Dossier dossier)
    {
        Debug.Log(dossier.Naam);

        TitelTekst.text = dossier.Naam;
        NaamTekst.text = dossier.Naam;
        DokterTekst.text = dossier.Arts ?? "";
        BehandelingDatumTekst.text = dossier.BehandelingDatum?.ToString("dd-MM-yyyy") ?? "";
        BehandTypeTekst.text = dossier.BehandelingType ?? "";

        if(dossier.GeboorteDatum != null)
        {
            var today = DateTime.Today;
            var age = today.Year - dossier.GeboorteDatum.Value.Year;
            LeeftijdTekst.text = age.ToString();
        } else
        {
            LeeftijdTekst.text = "";
        }
    }

    public void LogUit()
    {
        ApiClient.Instance.LogUit();
    }
}

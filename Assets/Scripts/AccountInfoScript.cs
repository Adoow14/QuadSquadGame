using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

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
        if (TaalManager.Instance.huidigeTaal == TaalManager.Taal.EN)
        {
            BehandTypeTekst.text = "Lungfunction Test";
        }
        else
        {
            BehandTypeTekst.text = "Longfunctie Test";
        }
        if(dossier.GeboorteDatum != null)
        {
            var today = DateTime.Today;
            var geboorteDatum = dossier.GeboorteDatum.Value;
            var age = today.Year - geboorteDatum.Year;
            if (today.Month < geboorteDatum.Month)
            {
                age--;
            }
            else if (today.Month == geboorteDatum.Month && today.Day < geboorteDatum.Day)
            {
                age--;
            }
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

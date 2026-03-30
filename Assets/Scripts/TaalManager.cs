using System;
using System.Collections.Generic;
using UnityEngine;

public class TaalManager : MonoBehaviour
{
    public static TaalManager Instance;
    private string naamKind = "";

    public enum Taal
    {
        NL,
        EN
    }
    public Taal huidigeTaal = Taal.NL;

    public event Action OnTaalVeranderd;

    private Dictionary<Taal, Dictionary<string, string>> taalData;

    void Awake()
    {
        Debug.Log("TaalManager Awake aangeroepen");
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LaadTaalData();
    }

    void LaadTaalData()
    {
        taalData = new Dictionary<Taal, Dictionary<string, string>>();

        //NL
        taalData[Taal.NL] = new Dictionary<string, string>
        {
            //Startscherm
            {"Titel", "Wind Avontuur"},
            {"StartTekst", $"Ben je klaar voor jouw avontuur{naamKind} ?"},
            
            //SpelScherm
            {"InfoSpel", "In dit spel is het de bedoeling dat je de bal in één adem zo ver mogelijk weg blaast !"},
            {"SpelTekst", $"Blaas de bal weg{naamKind} !" },
            
            //Inlog
            {"InlogTekst", $"Welkom bij jouw avontuur !" },
            {"NaamInlog", "Naam kind" },
            {"Wachtwoord", "Wachtwoord" },
            {"Inlog", "Inloggen" },
            {"Of", "Of" },
            //RegistrerenScherm
            {"Registreer", "Registreer" },
            {"GeboorteDatumRegister", "GeboorteDatum" },
            {"ArtsRegister", "Arts/Zorgverlener" },
            {"BehandelingTypeRegister", "Type Behandeling"},
            {"BehandelDatumRegister", "Behandeldatum dd/mm/jjj" },
            {"AlAccountTekst", "Heb jij al een account?" },

            //MapScherm
            { "OefenTekst", $"Heb je zin om samen oefenen{naamKind} ?" },
            { "OefenKnop", "Begin met oefenen!" },
            { "VolgendeKnop", "Volgende" },
            { "VorigeKnop", "Vorige" }
        };

        taalData[Taal.EN] = new Dictionary<string, string>
        {
            //Startscherm
            {"Titel", "Wind Adventure"},
            {"StartTekst", $"Are you ready for your adventure{naamKind} ?"},
            
            //SpelScherm
            {"InfoSpel", "In this game, the goal is to blow the ball as far away as possible in one breath !"},
            {"SpelTekst", $"Blow the ball away{naamKind} !" },

            //InlogScherm
            {"InlogTekst", "Welcome to your adventure !" },
            {"NaamInlog", "Child's name" },
            {"Wachtwoord", "Password" },
            {"Inlog", "Log In" },
            {"Of", "Or" },
            //RegisterScherm
            {"Registreer", "Register" },
            {"GeboorteDatumRegister", "Date of Birth" },
            {"ArtsRegister", "Doctor/Carer" },
            {"BehandelingTypeRegister", "Type of Treatment"},
            {"BehandelDatumRegister", "Treatment Date dd/mm/yyyy" },
            {"AlAccountTekst", "Do you already have an account?" },

            //MapScherm
            {"OefenTekst", $"Do you want to practice together{naamKind} ?" },
            {"OefenKnop", "Start practicing!" },
            {"VolgendeKnop", "Next" },
            {"VorigeKnop", "Previous" }

        };
    }

    public string GetTekst(string key)
    {
        if(taalData.ContainsKey(huidigeTaal) && taalData[huidigeTaal].ContainsKey(key))
        {
            return taalData[huidigeTaal][key];
        }
        return $"Tekst niet gevonden voor sleutel: {key}";
    }

    public void SetTaal(Taal taal)
    {
        huidigeTaal = taal;
        OnTaalVeranderd?.Invoke();
    }

    public void SetNaam(string naam)
    {
        naamKind = " " + naam;
        LaadTaalData();
    }
}

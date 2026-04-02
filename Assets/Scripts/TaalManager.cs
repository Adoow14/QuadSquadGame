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
            {"GameOverTekst", $"Geweldig gedaan{naamKind} !<br>Jouw score is:" },
            {"Opnieuw", "Opnieuw" },
            {"Terug", "Terug" },
            
            //Inlog
            {"InlogTekst", $"Vraag je ouders om hulp!" },
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
            { "Stap1", "Vandaag ga je naar het ziekenhuis. Dat is een plek waar dokters en verpleegkundigen je helpen om te kijken hoe gezond je bent. Je gaat een test doen voor je longen. Longen helpen je met ademhalen. Je krijgt een apparaat te zien dat lijkt op een buisje waar je in mag blazen. Het doet geen pijn. Je hoeft alleen maar goed te blazen, een beetje zoals wanneer je een ballon opblaast." },
            { "Stap2", "Voordat de echte test begint, ga je eerst oefenen met ademhalen. Je leert hoe je diep moet inademen en daarna zo hard en lang mogelijk moet uitblazen. Je kunt het zien als een spelletje waarin je probeert zo krachtig mogelijk te blazen. Door goed te oefenen weet je straks precies wat je moet doen tijdens de test." },
            { "Stap4", "Nu gaan we de echte meting doen. Je krijgt een mondstuk waar je in gaat blazen. Soms krijg je ook een knijpertje op je neus, zodat alle lucht door je mond gaat. Je haalt eerst diep adem, daarna plaats je je mond goed om het buisje en blaas je zo hard en lang mogelijk uit. De computer meet hoe goed jouw longen werken. Je doet dit een paar keer, zodat de meting goed en duidelijk is." },
            { "Stap5", "Soms krijg je een medicijn dat helpt om je luchtwegen wijder te maken. Je ademt dit medicijn in of slikt het. Daarna moet je ongeveer 15 minuten wachten. In die tijd kun je rustig zitten. Daarna gaan we opnieuw meten om te kijken of het medicijn heeft geholpen." },
            { "Stap6", "Na het wachten doe je de test nog een keer. Je blaast weer op dezelfde manier als eerst. Zo kan de dokter zien of er verschil is. Daarna is de test klaar. De dokter bekijkt de uitslagen en vertelt hoe goed jouw longen werken." },
            { "OefenTekst", $"Heb je zin om samen oefenen{naamKind} ?" },
            { "OefenKnop", "Begin met oefenen!" },
            { "VolgendeKnop", "Volgende" },
            { "VorigeKnop", "Vorige" },

            //AccountScherm
            { "Naam", "Naam" },
            { "Leeftijd", "Leeftijd" },
            { "BehandelType", "Behandel Type" },
            { "BehandelDatum", "Behandel Datum" },
            { "Arts", "Arts" },
            { "LogUit", "LogUit" }
        };

        taalData[Taal.EN] = new Dictionary<string, string>
        {
            //Startscherm
            {"Titel", "Wind Adventure"},
            {"StartTekst", $"Are you ready for your adventure{naamKind} ?"},
            
            //SpelScherm
            {"InfoSpel", "In this game, the goal is to blow the ball as far away as possible in one breath !"},
            {"SpelTekst", $"Blow the ball away{naamKind} !" },
            { "GameOverTekst", $"Great job{naamKind} !<br>Your score is:"  },
            {"Opnieuw", "Again" },
            {"Terug", "Back" },

            //InlogScherm
            {"InlogTekst", "Ask your parents for help!" },
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
            { "Stap1", "Today you are going to the hospital. That is a place where doctors and nurses help you to see how healthy you are. You are going to do a test for your lungs. Lungs help you breathe. You will see a device that looks like a tube that you can blow into. It does not hurt. You just need to blow well, a bit like when you blow up a balloon." },
            { "Stap2", "Before the real test begins, you will first practice breathing. You will learn how to take a deep breath in and then blow out as hard and as long as possible. You can think of it as a game where you try to blow as strongly as you can. By practicing well, you will know exactly what to do during the test." },
            { "Stap4", "Now we will do the real measurement. You will get a mouthpiece that you blow into. Sometimes you will also get a clip on your nose, so all the air goes through your mouth. First you take a deep breath in, then you place your mouth around the tube and blow out as hard and as long as possible. The computer measures how well your lungs work. You will do this a few times so the measurement is clear and correct." },
            { "Stap5", "Sometimes you will get medicine that helps to open your airways. You breathe in this medicine or swallow it. After that you have to wait for about 15 minutes. During that time you can sit quietly. After that we will measure again to see if the medicine has helped." },
            { "Stap6", "After waiting, you will do the test again. You blow in the same way as before. This way the doctor can see if there is a difference. After that the test is finished. The doctor looks at the results and tells you how well your lungs work." },
            {"OefenTekst", $"Do you want to practice together{naamKind} ?" },
            {"OefenKnop", "Start practicing!" },
            {"VolgendeKnop", "Next" },
            {"VorigeKnop", "Previous" },


            //AccountScherm
            {"Naam", "Name" },
            {"Leeftijd", "Age" },
            {"BehandelType", "Treatment Type" },
            {"BehandelDatum", "Treatment Date" },
            {"Arts", "Doctor" },
            {"LogUit", "Log Out" }
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

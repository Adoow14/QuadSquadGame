using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Stappenmanager : MonoBehaviour
{
    public int currentStap = 0;
    public GameObject stapInfo;
    public GameObject gameStap;
    public TextMeshProUGUI geopendeStap;
    public TextMeshProUGUI stapInformatie;

    public List<string> TESTstapInformatieLijst = new List<string> { "stap 1", "stap 2", "stap 3", "stap 4", "stap 5", "stap 6" };

    public void OpenStap(int stap)
    {
        stapInfo.SetActive(true);
        gameObject.SetActive(false);
        if (stap == 3)
        {
            Debug.Log("Stap 3 is geopend, hier komt de code voor stap 3");
            gameObject.SetActive(true);
            geopendeStap.text = "Stap " + currentStap.ToString();
            stapInformatie.text = null;
            return;
        }
        currentStap = stap;
        geopendeStap.text = "Stap " + currentStap.ToString();
        stapInformatie.text = TESTstapInformatieLijst[stap-1];//Info wat nederlands of engels is afhankelijk van de taal die gekozen is
    }

    public void SluitStap()
    {
        stapInfo.SetActive(false);
    }

    public void VolgendeStap()
    {
        if (currentStap >= 6)
            return;
        currentStap += 1;
        OpenStap(currentStap);
    }

    public void VorigeStap()
    {
        if (currentStap <= 1)
            return;
        currentStap -= 1;
        OpenStap(currentStap);
    }

    public void SpeelGame()
    {
        Debug.Log("Game is gestart");
        //Hier komt de code om het spel te starten
    }
}

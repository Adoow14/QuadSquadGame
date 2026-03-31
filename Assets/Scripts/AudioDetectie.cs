using UnityEngine;
using UnityEngine.WSA;

public class AudioDetectie : MonoBehaviour
{
    private AudioClip microfoonClip;
    public int sampleWindow = 64;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MicrofoonNaarAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicrofoonNaarAudioClip()
    {
        Debug.Log("StartMicrofoon aangeroepen");
        string microfoonNaam = "";
        if(Microphone.devices.Length > 0)
        {
            microfoonNaam = Microphone.devices[0];
            Debug.Log("Microfoon gevonden: " + microfoonNaam);
        }
        else
        {
            Debug.LogError("Geen microfoon gevonden!");
            microfoonNaam = null;
        }
        microfoonClip = Microphone.Start(microfoonNaam, true, 20, AudioSettings.outputSampleRate);
    }

    public float LuidheidVanMicrofoon()
    {
        int clipPositie = Microphone.GetPosition(Microphone.devices[0]);
        return LuidheidVanAudioClip(clipPositie, microfoonClip);
    }

    public float LuidheidVanAudioClip(int clipPositie, AudioClip clip)
    {
        int startPositie = clipPositie - sampleWindow;
        if (startPositie < 0)
        {
            startPositie = 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPositie);

        // Bereken de gemiddelde amplitude van de samples
        float totaleLuidheid = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totaleLuidheid += Mathf.Abs(waveData[i]);
        }

        float gemiddeldeLuidheid = totaleLuidheid / sampleWindow;
        return gemiddeldeLuidheid;
    }
}

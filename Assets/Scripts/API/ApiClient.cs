using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;


public class ApiClient : MonoBehaviour
{
    public static ApiClient Instance;

    [Header("API Settings")]
    public string baseUrl = "https://localhost:7222/api";
    public bool ingelogd = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Login(string username, string password, System.Action onSuccess, System.Action<string> onError)
    {
        var requestData = new AuthRequest
        {
            username = username,
            password = password
        };

        string json = JsonUtility.ToJson(requestData);

        using var request = new UnityWebRequest(baseUrl + "/auth/login", "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Login Request Verstuurd");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            onError?.Invoke(request.downloadHandler.text);
            yield break;
        }

        TaalManager.Instance.SetNaam(username);
        ingelogd = true;

        var response = JsonUtility.FromJson<AuthResponse>(request.downloadHandler.text);

        var token = response.token;

        

        PlayerPrefs.SetString("token", token);

        onSuccess?.Invoke();
    }

    public IEnumerator Register(
        string username,
        string password,
        string geboorteDatum,
        string arts,
        string behandelingDatum,
        System.Action onSuccess,
        System.Action<string> onError
    )
    {
        DateTime geboorte;
        DateTime behandeling;

        if (!DateTime.TryParse(geboorteDatum, out geboorte)){
            onError?.Invoke("Ongeldige geboorte datum");
            yield break;
        }

        if (!DateTime.TryParse(behandelingDatum, out behandeling))
        {
            onError?.Invoke("Ongeldige behandeling datum");
            yield break;
        }

        string geboorteFormatted = geboorte.ToString("yyyy-MM-dd");
        string behandelingFormatted = behandeling.ToString("yyyy-MM-dd");

        var requestData = new RegisterRequest
        {
            username = username,
            password = password,
            geboorteDatum = geboorteFormatted,
            arts = arts,
            behandelingDatum = behandelingFormatted
        };

        string json = JsonUtility.ToJson(requestData);
        
        using var request = new UnityWebRequest(baseUrl + "/auth/register", "POST");

        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Registreer Request Verstuurd");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            onError?.Invoke(request.downloadHandler.text);
            yield break;
        }

        TaalManager.Instance.SetNaam(username);
        ingelogd = true;

        var response = JsonUtility.FromJson<AuthResponse>(request.downloadHandler.text);

        var token = response.token;
        PlayerPrefs.SetString("token", token);

        onSuccess?.Invoke();
    }

    public IEnumerator GetDossier(Action<Dossier> onSuccess)
    {
        using var request = UnityWebRequest.Get(baseUrl + "/dossier/");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Authorization", "Bearer " + PlayerPrefs.GetString("token"));

        Debug.Log("Dossier Request Verstuurd");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            var err = request.downloadHandler != null ? request.downloadHandler.text : request.error;
            Debug.Log(err);
            yield break;
        }

        var json = request.downloadHandler.text;
        Debug.Log("Dossier JSON: " + json);
        if (json.Contains("["))
        {
            var jsons = json.Split("[");
            json = jsons[1];
            jsons = json.Split("]");
            json = jsons[0];
        }
        try
        {
            DossierDto dto = JsonUtility.FromJson<DossierDto>(json);
            if (dto == null)
            {
                Debug.Log("Kon Dossier niet parsen uit JSON.");
                yield break;
            }

            var dossier = Dossier.FromDto(dto);
            onSuccess?.Invoke(dossier);
        }
        catch (Exception ex)
        {
            Debug.Log("Fout bij deserialiseren: " + ex.Message);
        }
    }

    public void LogUit()
    {
        PlayerPrefs.DeleteKey("token");
        ingelogd = false;
    }
}

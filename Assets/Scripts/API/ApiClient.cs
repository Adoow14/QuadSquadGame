using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;


public class ApiClient : MonoBehaviour
{
    public static ApiClient Instance;

    [Header("API Settings")]
    public string baseUrl = "https://localhost:7222/api";

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

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            onError?.Invoke(request.downloadHandler.text);
            yield break;
        }

        TaalManager.Instance.SetNaam(username);

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
        var requestData = new RegisterRequest
        {
            username = username,
            password = password,
            geboorteDatum = geboorteDatum,
            arts = arts,
            behandelingDatum = behandelingDatum
        };

        string json = JsonUtility.ToJson(requestData);
        
        using var request = new UnityWebRequest(baseUrl + "/auth/register", "POST");

        request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            onError?.Invoke(request.downloadHandler.text);
            yield break;
        }

        var response = JsonUtility.FromJson<AuthResponse>(request.downloadHandler.text);

        // var token = response.token;
        // PlayerPrefs.SetString("token", token);

        onSuccess?.Invoke();
    }
}

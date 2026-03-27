using UnityEngine;

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
}

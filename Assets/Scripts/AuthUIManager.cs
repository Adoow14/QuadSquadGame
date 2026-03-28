using UnityEngine;
using TMPro;

public class AuthUIManager : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject registerPanel;

    public TMP_InputField loginName;
    public TMP_InputField loginPassword;
    public TMP_Text loginError;

    public TMP_InputField registerName;
    public TMP_InputField registerPassword;
    public TMP_Text registerError;

    public void ShowLogin()
    {
        loginPanel.SetActive(true);
        registerPanel.SetActive(false);

        // reset errors
        loginError.text = "";
        registerError.text = "";
    }

    public void ShowRegister()
    {
        loginPanel.SetActive(false);
        registerPanel.SetActive(true);

        // reset errors
        loginError.text = "";
        registerError.text = "";
    }

    public void OnLoginClicked()
    {
        loginError.text = "";

        string username = loginName.text;
        string password = loginPassword.text;

        StartCoroutine(ApiClient.Instance.Login(username, password, OnAuthSuccess, OnAuthError));
    }

    public void OnRegisterClicked()
    {
        registerError.text = "";

        string username = registerName.text;
        string password = registerPassword.text;

        StartCoroutine(ApiClient.Instance.Register(username, password, OnAuthSuccess, OnAuthError));
    }

    void OnAuthSuccess()
    {
        // Login/Register success, Response moet nog komen als parameter
    }

    void OnAuthError(string error)
    {
        loginError.text = error;
        Debug.LogError("Auth error: " + error);
    }
}

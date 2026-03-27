using UnityEngine;
using TMPro;

public class AuthUIManager : MonoBehaviour
{
    public GameObject authPanel;
    public GameObject loginPanel;
    public GameObject registerPanel;

    public TMP_InputField loginName;
    public TMP_InputField loginPassword;
    public TMP_Text loginError;

    public TMP_InputField registerName;
    public TMP_InputField registerPassword;
    public TMP_Text registerError;

    public void TogglePanel()
    {
        authPanel.SetActive(!authPanel.activeSelf);
    }

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

    public void Login()
    {
        loginError.text = "";

        if (loginName.text == "" || loginPassword.text == "")
        {
            loginError.text = "Vul alles in!";
            return;
        }

        if (loginPassword.text.Length < 4)
        {
            loginError.text = "Wachtwoord te kort!";
            return;
        }

        loginError.text = "Succes!";
    }

    public void Register()
    {
        registerError.text = "";

        if (registerName.text == "" || registerPassword.text == "")
        {
            registerError.text = "Vul alles in!";
            return;
        }

        if (registerPassword.text.Length < 4)
        {
            registerError.text = "Wachtwoord te kort!";
            return;
        }

        registerError.text = "Registratie gelukt!";
    }
}

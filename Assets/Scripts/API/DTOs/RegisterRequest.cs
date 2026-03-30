using UnityEngine;
using System;
using System.Globalization;

[System.Serializable]
public class RegisterRequest
{
    public string username;
    public string password;

    public string geboorteDatum;
    public string arts;
    public string behandelingDatum;
}
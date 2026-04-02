using System;
using UnityEngine;

[Serializable]
public class DossierDto
{
    public int id;
    public int userId;
    public string naam;
    public string? geboorteDatum;
    public string? arts;
    public string? behandelingType;
    public string? behandelingDatum;
    public int? stap;
}

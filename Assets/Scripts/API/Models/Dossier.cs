using System;
using UnityEngine;

public class Dossier
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Naam { get; set; }
    public DateTime? GeboorteDatum { get; set; }
    public string? Arts { get; set; }
    public string? BehandelingType { get; set; }
    public DateTime? BehandelingDatum { get; set; }
    public int? Stap { get; set; }

    public static Dossier FromDto(DossierDto dto)
    {
        if (dto == null) return null;

        var dossier = new Dossier
        {
            Id = dto.id,
            UserId = dto.userId,
            Naam = dto.naam,
            Arts = dto.arts,
            BehandelingType = dto.behandelingType
        };

        // Parse geboorte datum
        if (!string.IsNullOrEmpty(dto.geboorteDatum) &&
            DateTime.TryParse(dto.geboorteDatum, out var geboorte))
        {
            dossier.GeboorteDatum = geboorte;
        }
        else
        {
            dossier.GeboorteDatum = null;
        }

        // Parse optional behandeling datum
        if (!string.IsNullOrEmpty(dto.behandelingDatum) &&
            DateTime.TryParse(dto.behandelingDatum, out var behandeling))
        {
            dossier.BehandelingDatum = behandeling;
        }
        else
        {
            dossier.BehandelingDatum = null;
        }

        dossier.Stap = dto.stap == 0 ? (int?)null : dto.stap;

        return dossier;
    }
}

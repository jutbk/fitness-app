using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public class Paiement
{
    public int PaiementId { get; set; }
    public decimal? PaiementMontant { get; set; }
    public DateTime? PaiementDate { get; set; }
    public string? PaiementStatut { get; set; }
    public int MembreId { get; set; }
    public virtual Membre Membre { get; set; } = null!;
}

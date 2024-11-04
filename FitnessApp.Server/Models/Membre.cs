using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public partial class Membre
{
    public int MembreId { get; set; }
    public string MembreFirstname { get; set; } = null!;
    public string MembreLastname { get; set; } = null!;
    public string MembreEmail { get; set; } = null!;
    public string? MembrePhonenumber { get; set; }
    public string? MembreStatutAbonnement { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? AbonnementId { get; set; }
    public virtual Abonnement? Abonnement { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}


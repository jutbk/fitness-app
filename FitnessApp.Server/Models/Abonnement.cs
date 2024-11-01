using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public class Abonnement
{
    public int AbonnementId { get; set; }
    public string AbonnementType { get; set; } = null!;
    public decimal AbonnementPrix { get; set; }
    public string AbonnementDuree { get; set; } = null!;
    public virtual ICollection<Membre> Membres { get; set; } = new List<Membre>();
}

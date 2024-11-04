using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public partial class Coach
{
    public string CoachFirstname { get; set; } = null!;

    public string CoachLastname { get; set; } = null!;

    public string CoachSpecialite { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int CoachId { get; set; }

    public virtual ICollection<Cours> Cours { get; set; } = new List<Cours>();
}

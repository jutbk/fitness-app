using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public class Coach
{
    public int CoachId { get; set; }
    public string CoachFirstname { get; set; } = null!;
    public string CoachLastname { get; set; } = null!;
    public string CoachSpecialite { get; set; } = null!;
    public virtual ICollection<Cours> Cours { get; set; } = new List<Cours>();
}

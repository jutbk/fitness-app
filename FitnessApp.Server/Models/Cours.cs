using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public class Cours
{
    public int CoursId { get; set; }
    public string CoursName { get; set; } = null!;
    public DateOnly CoursDate { get; set; }
    public TimeOnly CoursHeureDebut { get; set; }
    public TimeOnly CoursHeureFin { get; set; }
    public int CoachId { get; set; }
    public virtual Coach Coach { get; set; } = null!;
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

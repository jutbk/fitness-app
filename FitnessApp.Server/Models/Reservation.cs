﻿using System;
using System.Collections.Generic;

namespace FitnessApp.Server.Models;

public partial class Reservation
{
    public DateTime? ReservationDate { get; set; }

    public int CoursId { get; set; }

    public int MembreId { get; set; }

    public int ReservationId { get; set; }

    public virtual Cours Cours { get; set; } = null!;

    public virtual Membre Membre { get; set; } = null!;
}

﻿using System;
using System.Collections.Generic;

namespace ExampleExercise.Data​;

public partial class Guest
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Ucn { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}

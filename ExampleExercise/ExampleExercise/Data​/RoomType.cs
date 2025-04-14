﻿using System;
using System.Collections.Generic;

namespace ExampleExercise.Data​;

public partial class RoomType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int MaxCapacity { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}

﻿using System;
using System.Collections.Generic;

namespace TacoBellDB_API;

public partial class Taco
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? SoftShell { get; set; }

    public bool? Dorito { get; set; }
}

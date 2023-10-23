﻿using System;
using System.Collections.Generic;

namespace Entity2;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Toun { get; set; }

    public string Phon { get; set; } = null!;

    public string Tz { get; set; } = null!;

    public DateTime? DateBirth { get; set; }

    public string Pic { get; set; } = null!;

    public bool IsManager { get; set; }

    public bool? Status { get; set; }

    public bool ReadTerms { get; set; }
}

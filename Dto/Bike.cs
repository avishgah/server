﻿using System;
using System.Collections.Generic;

namespace Dto;

public partial class BikeDto
{
    public int? Id { get; set; }

    public string? Code { get; set; }

    public int? Battery { get; set; }

    public int? IdStation { get; set; }

    public DateTime? DateStart { get; set; }
}
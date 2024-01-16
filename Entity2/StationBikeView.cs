using System;
using System.Collections.Generic;

namespace Entity2;

public partial class StationBikeView
{
    public int Id { get; set; }

    public int Battery { get; set; }

    public int Code { get; set; }

    public DateTime? DateStart { get; set; }

    public bool? Status { get; set; }

    public int? IdStation { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }
}

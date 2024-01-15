using System;
using System.Collections.Generic;

namespace Entity2;

public partial class StationView
{
    public int Id { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }

    public bool Status { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public int? NumOrders { get; set; }

    public int? Cun { get; set; }
}

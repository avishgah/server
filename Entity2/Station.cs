using System;
using System.Collections.Generic;

namespace Entity2;

public partial class Station
{
    public int Id { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }

    public bool Status { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public virtual ICollection<Bike> Bikes { get; set; } = new List<Bike>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

using System;
using System.Collections.Generic;

namespace Entity;

public partial class Bike
{
    public int? Id { get; set; }

    public string? Code { get; set; }

    public int? Battery { get; set; }

    public int? IdStation { get; set; }

    public DateTime? DateStart { get; set; }
}

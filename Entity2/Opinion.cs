using System;
using System.Collections.Generic;

namespace Entity2;

public partial class Opinion
{
    public int Id { get; set; }

    public int? IdCust { get; set; }

    public int? IdStation { get; set; }

    public string? Caption { get; set; }

    public int? SatisfactionLeve { get; set; }

    public virtual Customer IdNavigation { get; set; } = null!;

    public virtual Station? IdStationNavigation { get; set; }
}

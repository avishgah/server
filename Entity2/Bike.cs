using System;
using System.Collections.Generic;

namespace Entity2;

public partial class Bike
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public int? Battery { get; set; }

    public int? IdStation { get; set; }

    public DateTime? DateStart { get; set; }

    public bool? Status { get; set; }

    public virtual Station? IdStationNavigation { get; set; }

    public virtual ICollection<Opinion> Opinions { get; set; } = new List<Opinion>();

    public virtual ICollection<OrderBike> OrderBikes { get; set; } = new List<OrderBike>();
}

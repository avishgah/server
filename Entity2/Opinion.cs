using System;
using System.Collections.Generic;

namespace Entity2;

public partial class Opinion
{
    public int Id { get; set; }

    public int? IdCust { get; set; }

    public int? IdStation { get; set; }

    public string? Caption { get; set; }

    public double? SatisfactionLeve { get; set; }

    public DateTime? Date { get; set; }

    public string? Place { get; set; }

    public string? TypeProblem { get; set; }

    public string? Pic { get; set; }

    public int? IdBike { get; set; }

    public virtual Bike? IdBikeNavigation { get; set; }

    public virtual Customer? IdCustNavigation { get; set; }

    public virtual Station? IdStationNavigation { get; set; }
}

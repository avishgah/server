using System;
using System.Collections.Generic;

namespace Dto;

public partial class OpinionDto
{
    public int Id { get; set; }

    public int? IdCust { get; set; }

    public int? IdStation { get; set; }

    public string? Caption { get; set; }

    public double? SatisfactionLeve { get; set; }

    public DateTime? Date { get; set; }

    public string? Place { get; set; }

    public string? TypeProblem { get; set; }

    public string? NumBike { get; set; }

    public virtual CustomerDto IdNavigation { get; set; } = null!;
  public virtual StationDto? IdStationNavigation { get; set; }
}

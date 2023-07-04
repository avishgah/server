using System;
using System.Collections.Generic;

namespace Dto;

public partial class OpinionDto
{
    public int Id { get; set; }

    public int? IdCust { get; set; }

    public int? IdStation { get; set; }

    public string? Caption { get; set; }

    public int? SatisfactionLeve { get; set; }

    public virtual CustomerDto IdNavigation { get; set; } = null!;

    public virtual StationDto? IdStationNavigation { get; set; }
}

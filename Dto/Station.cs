using System;
using System.Collections.Generic;

namespace Dto;

public partial class StationDto
{
    public int Id { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }

    public bool Status { get; set; }

    //public virtual ICollection<BikeDto> Bikes { get; set; } = new List<BikeDto>();

    //public virtual ICollection<OpinionDto> Opinions { get; set; } = new List<OpinionDto>();

    //public virtual ICollection<OrderBikeDto> OrderBikes { get; set; } = new List<OrderBikeDto>();
}

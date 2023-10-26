using System;
using System.Collections.Generic;

namespace Dto;

public partial class OrderBikeDto
{
    public int Id { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? IdBike { get; set; }

    public int? IdPay { get; set; }

    public bool? Status { get; set; }


    public int? Sum { get; set; }


   
}

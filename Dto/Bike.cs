 using System;
using System.Collections.Generic;

namespace Dto;

public partial class BikeDto
{

    //comenet for test github
    public int Id { get; set; }

    public int? Code { get; set; }

    public int? Battery { get; set; }

    public int? IdStation { get; set; }

    public DateTime? DateStart { get; set; }

    public bool? Status { get; set; }

}

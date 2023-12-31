﻿using System;
using System.Collections.Generic;

namespace Dto;


public partial class OrderDto
{
    public int Id { get; set; }

    public DateTime? DatePay { get; set; }

    public int? IdStation { get; set; }

    public DateTime? DateOrder { get; set; }

    public string? Code { get; set; }

    public int? IdCust { get; set; }

    public double? EndSum { get; set; }

    public bool? IsPay { get; set; }

    public string? custName { get; set; } = "";
    public int count { get; set;}


}

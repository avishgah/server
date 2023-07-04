using System;
using System.Collections.Generic;

namespace Entity;

public partial class Order
{
    public int? Id { get; set; }

    public DateTime? DatePay { get; set; }

    public string? Code { get; set; }

    public string? IdCust { get; set; }

    public int? EndSum { get; set; }

    public bool? IsPay { get; set; }
}

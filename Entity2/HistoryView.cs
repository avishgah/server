using System;
using System.Collections.Generic;

namespace Entity2;

public partial class HistoryView
{
    public int Id { get; set; }

    public DateTime? DatePay { get; set; }

    public string? Code { get; set; }

    public int? IdCust { get; set; }

    public int? EndSum { get; set; }

    public bool? IsPay { get; set; }

    public int? IdStation { get; set; }

    public DateTime? DateOrder { get; set; }

    public int? Count { get; set; }

    public string? Location { get; set; }

    public string? Name { get; set; }
}

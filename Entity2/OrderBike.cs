﻿using System;
using System.Collections.Generic;

namespace Entity2;

public partial class OrderBike
{
    public int Id { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public int? IdBike { get; set; }

    public int? IdPay { get; set; }

    public bool? Status { get; set; }

    public int? IdStation { get; set; }

    public int? Sum { get; set; }

    public DateTime? DateOrder { get; set; }

    public virtual Bike IdNavigation { get; set; } = null!;

    public virtual Order? IdPayNavigation { get; set; }

    public virtual Station? IdStationNavigation { get; set; }
}

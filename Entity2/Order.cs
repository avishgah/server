﻿using System;
using System.Collections.Generic;

namespace Entity2;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? DatePay { get; set; }

    public string? Code { get; set; }

    public int? IdCust { get; set; }

    public int? EndSum { get; set; }

    public bool? IsPay { get; set; }

   public virtual Customer? IdCustNavigation { get; set; }

   public virtual ICollection<OrderBike> OrderBikes { get; set; } = new List<OrderBike>();
}

using System;
using System.Collections.Generic;

namespace Dto;

public partial class OrderDto
{
    public int Id { get; set; }

    public DateTime? DatePay { get; set; }

    public string? Code { get; set; }

    public int? IdCust { get; set; }

    public int? EndSum { get; set; }

    public bool? IsPay { get; set; }

    public virtual CustomerDto? IdCustNavigation { get; set; }

    public virtual ICollection<OrderBikeDto> OrderBikes { get; set; } = new List<OrderBikeDto>();
}

using System;
using System.Collections.Generic;

namespace Dto;

public partial class CustomerOrdersViewDto
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public string? Address { get; set; }

    public DateTime? DateBirth { get; set; }

    public string Mail { get; set; } = null!;

    public string Phon { get; set; } = null!;

    public bool? Status { get; set; }

    public string? Toun { get; set; }

    public string Tz { get; set; } = null!;

    public string Pic { get; set; } = null!;

    public int? NumOrders { get; set; }
}

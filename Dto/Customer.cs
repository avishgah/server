using System;
using System.Collections.Generic;

namespace Dto;

public partial class CustomerDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Toun { get; set; }

    public string Phon { get; set; } = null!;

    public string Tz { get; set; } = null!;

    public DateTime? DateBirth { get; set; }

    public string Pic { get; set; } = null!;

    public bool IsManager { get; set; }

    public bool? Status { get; set; }

    public bool ReadTerms { get; set; }

    //public virtual OpinionDto? Opinion { get; set; }

    //public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
}

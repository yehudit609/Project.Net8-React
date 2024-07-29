using System;
using System.Collections.Generic;

namespace Entities;

public partial class Car
{
    public int CarId { get; set; }

    public int? CarNumber { get; set; }

    public int? ModelId { get; set; }

    public int? NumOfKilometraz { get; set; }

    public bool? Status { get; set; }

    public string? Color { get; set; }

    public int? Price { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Model? Model { get; set; }

    public virtual ICollection<Renting> Rentings { get; set; } = new List<Renting>();
}

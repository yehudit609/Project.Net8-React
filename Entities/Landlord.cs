using System;
using System.Collections.Generic;

namespace Entities;

public partial class Landlord
{
    public int LandlordId { get; set; }

    public int? LandlordTz { get; set; }

    public string? LandlordName { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? LandlordPhone { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Renting> Rentings { get; set; } = new List<Renting>();
}

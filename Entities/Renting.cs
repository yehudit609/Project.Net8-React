using System;
using System.Collections.Generic;

namespace Entities;

public partial class Renting
{
    public int RentingId { get; set; }

    public int? LandlordId { get; set; }

    public DateOnly? RentingDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public int? CarId { get; set; }

    public bool? BabySeat { get; set; }

    public bool? Koster { get; set; }

    public bool? AddDriver { get; set; }

    public bool? Damages { get; set; }

    public bool? Wase { get; set; }

    public int? EarlyPayment { get; set; }

    public int? TotalPayment { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Landlord? Landlord { get; set; }
}

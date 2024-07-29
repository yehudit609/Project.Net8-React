using System;
using System.Collections.Generic;

namespace Entities;

public partial class Model
{
    public int ModelId { get; set; }

    public string? ModelName { get; set; }

    public int? CompanyId { get; set; }

    public int? NumOfSeats { get; set; }

    public int? ManufactureYear { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Company? Company { get; set; }
}

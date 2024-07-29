using System;
using System.Collections.Generic;

namespace Entities;

public partial class Company
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}

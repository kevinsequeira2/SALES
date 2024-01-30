using System;
using System.Collections.Generic;

namespace Sale_system.MODEL;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegister { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

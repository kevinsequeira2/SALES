using System;
using System.Collections.Generic;

namespace Sale_system.MODEL;

public partial class Product
{
    public int IdPproduct { get; set; }

    public string? Name { get; set; }

    public int? IdCategory { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DateRegister { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();
}

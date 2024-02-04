using System;
using System.Collections.Generic;

namespace Sale_system.MODEL;

public partial class Sale
{
    public int Documentsale { get; set; }

    public string? TypePay { get; set; }

    public decimal? Total { get; set; }

    public DateTime? DateRegister { get; set; }

    public virtual ICollection<Saledetail> Saledetails { get; set; } = new List<Saledetail>();
}

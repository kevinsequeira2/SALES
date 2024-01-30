using System;
using System.Collections.Generic;

namespace Sale_system.MODEL;

public partial class Saledetail
{
    public int IdSaleDetail { get; set; }

    public int? IdSale { get; set; }

    public int? IdProduct { get; set; }

    public int? Amount { get; set; }

    public decimal? Price { get; set; }

    public decimal? Total { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Sale? IdSaleNavigation { get; set; }
}

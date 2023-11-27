﻿using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public int? StockBalance { get; set; }

    public int StoreId { get; set; }

    public string Isbn13 { get; set; } = null!;

    public virtual Book Isbn13Navigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}

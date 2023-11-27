using System;
using System.Collections.Generic;

namespace Labb2.Databas.Ebooks.Models;

public partial class BookView
{
    public string Isbn13 { get; set; } = null!;

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? StockBalance { get; set; }

    public int StoreId { get; set; }
}

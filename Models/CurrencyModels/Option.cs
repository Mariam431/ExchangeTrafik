using System;
using System.Collections.Generic;

namespace ExchangeTrafik.Models.CurrencyModels;

public partial class Option
{
    public int Id { get; set; }

    public string Url { get; set; } = null!;

    public string Headers { get; set; } = null!;

    public string Setting1 { get; set; } = null!;

    public string Setting2 { get; set; } = null!;

    public string Setting3 { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ExchangeTrafik.Models.CurrencyModels;

public partial class TransactionLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string RequestUrl { get; set; } = null!;

    public string? ResponseLog { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool? TransactionType { get; set; }
}

using System;
using System.Collections.Generic;

namespace ExemploSolucao.Models;

public partial class Trip
{
    public long TripId { get; set; }

    public int VendorId { get; set; }

    public DateTime PickupDateTime { get; set; }

    public DateTime DropoffDateTime { get; set; }

    public int? PassengerCount { get; set; }

    public decimal TripDistance { get; set; }

    public int? PickupLocationId { get; set; }

    public int? DropoffLocationId { get; set; }

    public decimal? StartLon { get; set; }

    public decimal? StartLat { get; set; }

    public decimal? EndLon { get; set; }

    public decimal? EndLat { get; set; }

    public int? RateCodeId { get; set; }

    public string? StoreAndFwdFlag { get; set; }

    public int? PaymentTypeId { get; set; }

    public decimal FareAmount { get; set; }

    public decimal Extra { get; set; }

    public decimal MtaTax { get; set; }

    public decimal ImprovementSurcharge { get; set; }

    public decimal TipAmount { get; set; }

    public decimal TollsAmount { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Location? DropoffLocation { get; set; }

    public virtual PaymentType? PaymentType { get; set; }

    public virtual Location? PickupLocation { get; set; }

    public virtual RateCode? RateCode { get; set; }

    public virtual Vendor Vendor { get; set; } = null!;
}

using System.Text.Json.Serialization;

namespace ExemploSolucao.DTO
{
    public sealed class YellowTaxiTripDto
    {
        [JsonPropertyName("vendorID")]
        public string VendorID { get; set; } = "";

        [JsonPropertyName("tpepPickupDateTime")]
        public long TpepPickupDateTime { get; set; }

        [JsonPropertyName("tpepDropoffDateTime")]
        public long TpepDropoffDateTime { get; set; }

        [JsonPropertyName("passengerCount")]
        public int? PassengerCount { get; set; }

        [JsonPropertyName("tripDistance")]
        public decimal TripDistance { get; set; }

        [JsonPropertyName("puLocationId")]
        public string? PuLocationId { get; set; }

        [JsonPropertyName("doLocationId")]
        public string? DoLocationId { get; set; }

        [JsonPropertyName("startLon")]
        public decimal? StartLon { get; set; }

        [JsonPropertyName("startLat")]
        public decimal? StartLat { get; set; }

        [JsonPropertyName("endLon")]
        public decimal? EndLon { get; set; }

        [JsonPropertyName("endLat")]
        public decimal? EndLat { get; set; }

        [JsonPropertyName("rateCodeId")]
        public int? RateCodeId { get; set; }

        [JsonPropertyName("storeAndFwdFlag")]
        public string? StoreAndFwdFlag { get; set; }

        [JsonPropertyName("paymentType")]
        public int? PaymentType { get; set; }

        [JsonPropertyName("fareAmount")]
        public decimal FareAmount { get; set; }

        [JsonPropertyName("extra")]
        public decimal Extra { get; set; }

        [JsonPropertyName("mtaTax")]
        public decimal MtaTax { get; set; }

        [JsonPropertyName("improvementSurcharge")]
        public string? ImprovementSurcharge { get; set; }

        [JsonPropertyName("tipAmount")]
        public decimal TipAmount { get; set; }

        [JsonPropertyName("tollsAmount")]
        public decimal TollsAmount { get; set; }

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }
    }

}

using ExemploSolucao.DTO;
using ExemploSolucao.Models;
using System.Globalization;

namespace ExemploSolucao.Mapper
{
    public static class YellowTaxiTripMapper
    {
        public static Trip ToEntity(YellowTaxiTripDto dto)
        {
            return new Trip
            {
                VendorId = int.Parse(
                    dto.VendorID, CultureInfo.InvariantCulture),

                PickupDateTime =
                    DateTimeOffset
                        .FromUnixTimeMilliseconds(dto.TpepPickupDateTime)
                        .UtcDateTime,

                DropoffDateTime =
                    DateTimeOffset
                        .FromUnixTimeMilliseconds(dto.TpepDropoffDateTime)
                        .UtcDateTime,

                PassengerCount = dto.PassengerCount,
                TripDistance = dto.TripDistance,

                PickupLocationId = ParseNullableInt(dto.PuLocationId),
                DropoffLocationId = ParseNullableInt(dto.DoLocationId),

                StartLon = dto.StartLon,
                StartLat = dto.StartLat,
                EndLon = dto.EndLon,
                EndLat = dto.EndLat,

                RateCodeId = dto.RateCodeId,
                StoreAndFwdFlag = dto.StoreAndFwdFlag,
                PaymentTypeId = dto.PaymentType,

                FareAmount = dto.FareAmount,
                Extra = dto.Extra,
                MtaTax = dto.MtaTax,

                ImprovementSurcharge =
                    decimal.Parse(
                        dto.ImprovementSurcharge ?? "0",
                        CultureInfo.InvariantCulture),

                TipAmount = dto.TipAmount,
                TollsAmount = dto.TollsAmount,
                TotalAmount = dto.TotalAmount
            };
        }

        private static int? ParseNullableInt(string? value)
        {
            return int.TryParse(
                value,
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out var result)
                    ? result
                    : null;
        }
    }
}
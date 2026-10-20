
using ExemploSolucao.Models;
using Microsoft.EntityFrameworkCore;

namespace ExemploSolucao.Services;

public sealed class TripDependencyService
{
    private readonly SqldbMonitorJnPrdContext _db;

    public TripDependencyService(SqldbMonitorJnPrdContext db)
    {
        _db = db;
    }

    public async Task EnsureDependenciesAsync(
        Trip trip,
        CancellationToken cancellationToken = default)
    {
        // Vendor
        if (!await _db.Vendors.AnyAsync(
                x => x.VendorId == trip.VendorId,
                cancellationToken))
        {
            _db.Vendors.Add(new Vendor
            {
                VendorId = trip.VendorId,
                VendorName = $"Unknown Vendor {trip.VendorId}"
            });
        }

        // Pickup location
        if (trip.PickupLocationId.HasValue &&
            !await _db.Locations.AnyAsync(
                x => x.LocationId == trip.PickupLocationId.Value,
                cancellationToken))
        {
            _db.Locations.Add(new Location
            {
                LocationId = trip.PickupLocationId.Value,
                LocationName = null,
                Borough = null,
                ServiceZone = null
            });
        }

        // Dropoff location
        if (trip.DropoffLocationId.HasValue &&
            trip.DropoffLocationId != trip.PickupLocationId &&
            !await _db.Locations.AnyAsync(
                x => x.LocationId == trip.DropoffLocationId.Value,
                cancellationToken))
        {
            _db.Locations.Add(new Location
            {
                LocationId = trip.DropoffLocationId.Value,
                LocationName = null,
                Borough = null,
                ServiceZone = null
            });
        }

        // Rate code
        if (trip.RateCodeId.HasValue &&
            !await _db.RateCodes.AnyAsync(
                x => x.RateCodeId == trip.RateCodeId.Value,
                cancellationToken))
        {
            _db.RateCodes.Add(new RateCode
            {
                RateCodeId = trip.RateCodeId.Value,
                RateCodeName = $"Unknown Rate Code {trip.RateCodeId}"
            });
        }

        // Payment type
        if (trip.PaymentTypeId.HasValue &&
            !await _db.PaymentTypes.AnyAsync(
                x => x.PaymentTypeId == trip.PaymentTypeId.Value,
                cancellationToken))
        {
            _db.PaymentTypes.Add(new PaymentType
            {
                PaymentTypeId = trip.PaymentTypeId.Value,
                PaymentTypeName = $"Unknown Payment Type {trip.PaymentTypeId}"
            });
        }

        // Persistir primeiro as dependências.
        await _db.SaveChangesAsync(cancellationToken);
    }
}

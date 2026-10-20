using System;
using System.Collections.Generic;

namespace ExemploSolucao.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    public string? Borough { get; set; }

    public string? ServiceZone { get; set; }

    public virtual ICollection<Trip> TripDropoffLocations { get; set; } = new List<Trip>();

    public virtual ICollection<Trip> TripPickupLocations { get; set; } = new List<Trip>();
}

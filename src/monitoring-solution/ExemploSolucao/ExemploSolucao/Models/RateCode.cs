using System;
using System.Collections.Generic;

namespace ExemploSolucao.Models;

public partial class RateCode
{
    public int RateCodeId { get; set; }

    public string RateCodeName { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}

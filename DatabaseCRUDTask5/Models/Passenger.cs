using System;
using System.Collections.Generic;

namespace DatabaseCRUDTask5.Models;

public partial class Passenger
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<PassInTrip> PassInTrips { get; set; } = new List<PassInTrip>();
}

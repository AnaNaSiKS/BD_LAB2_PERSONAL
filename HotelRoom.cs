using System;
using System.Collections.Generic;

namespace BD_LAB2_PERSONAL;

public partial class HotelRoom
{
    public long NumberId { get; set; }

    public string NumberName { get; set; } = null!;

    public long Capacity { get; set; }

    public string Description { get; set; } = null!;

    public double Price { get; set; }

    public long? EmplsId { get; set; }

    public virtual Employee? Empls { get; set; }
}

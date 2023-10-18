using System;
using System.Collections.Generic;

namespace BD_LAB2_PERSONAL;

public partial class Employee
{
    public long EmplId { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Birthday { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string TelephoneNumber { get; set; } = null!;

    public string PassportDetails { get; set; } = null!;

    public long PositionsId { get; set; }

    public virtual ICollection<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();

    public virtual Position Positions { get; set; } = null!;
}

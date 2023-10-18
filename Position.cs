using System;
using System.Collections.Generic;

namespace BD_LAB2_PERSONAL;

public partial class Position
{
    public long PositionId { get; set; }

    public string PositionName { get; set; } = null!;

    public double Salary { get; set; }

    public string Duties { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

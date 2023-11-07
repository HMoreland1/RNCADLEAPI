using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class RoleAssignment
{
    public int AssignmentId { get; set; }

    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public virtual UserRole? Role { get; set; }

    public virtual User? User { get; set; }
}

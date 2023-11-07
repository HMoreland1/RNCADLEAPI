using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class UserRole
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<RoleAssignment> RoleAssignments { get; set; } = new List<RoleAssignment>();
}

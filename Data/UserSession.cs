using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class UserSession
{
    public int SessionId { get; set; }

    public int? UserId { get; set; }

    public string? SessionToken { get; set; }

    public DateTime? LoginTime { get; set; }

    public string? IpAddress { get; set; }

    public virtual User? User { get; set; }
}

using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class UserActivity
{
    public int ActivityId { get; set; }

    public int? UserId { get; set; }

    public string? ActivityType { get; set; }

    public DateTime? ActivityTimestamp { get; set; }

    public virtual User? User { get; set; }
}

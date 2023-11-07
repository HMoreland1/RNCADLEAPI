using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class UserProgress
{
    public int ProgressId { get; set; }

    public int? UserId { get; set; }

    public int? ContentId { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int? Score { get; set; }

    public virtual LearningContent? Content { get; set; }

    public virtual User? User { get; set; }
}

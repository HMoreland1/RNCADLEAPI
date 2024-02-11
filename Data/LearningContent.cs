using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class LearningContent
{
    public int ContentId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? Content { get; set; }

    public int? CategoryId { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ContentCategory? Category { get; }

    public virtual User? CreatedByUser { get; }

    public virtual ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
}

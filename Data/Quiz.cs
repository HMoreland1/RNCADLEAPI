using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class Quiz
{
    public int QuizId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public int? CreatedByUserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>();
}

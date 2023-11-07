using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class QuizQuestion
{
    public int QuestionId { get; set; }

    public int? QuizId { get; set; }

    public string QuestionText { get; set; } = null!;

    public string? Option1 { get; set; }

    public string? Option2 { get; set; }

    public string? Option3 { get; set; }

    public string? Option4 { get; set; }

    public int? CorrectOption { get; set; }

    public virtual Quiz? Quiz { get; set; }
}

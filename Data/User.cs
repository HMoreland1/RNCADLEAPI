using System;
using System.Collections.Generic;

namespace RNCADLEAPI.Data;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<LearningContent> LearningContents { get; set; } = new List<LearningContent>();

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public virtual ICollection<RoleAssignment> RoleAssignments { get; set; } = new List<RoleAssignment>();

    public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();

    public virtual ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();

    public virtual ICollection<UserSession> UserSessions { get; set; } = new List<UserSession>();
}

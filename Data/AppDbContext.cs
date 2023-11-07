using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RNCADLEAPI.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContentCategory> ContentCategories { get; set; }

    public virtual DbSet<LearningContent> LearningContents { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<RoleAssignment> RoleAssignments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivity> UserActivities { get; set; }

    public virtual DbSet<UserProgress> UserProgresses { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserSession> UserSessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=dist-6-505.uopnet.plymouth.ac.uk;Database=Comp3000_HMoreland;User ID=HMoreland;Password=IcqU903+;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContentCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ContentC__D54EE9B41768D300");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<LearningContent>(entity =>
        {
            entity.HasKey(e => e.ContentId).HasName("PK__Learning__655FE510CF226D83");

            entity.ToTable("LearningContent");

            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Category).WithMany(p => p.LearningContents)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__LearningC__categ__778AC167");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.LearningContents)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__LearningC__creat__76969D2E");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__2D7053ECD1B4A164");

            entity.ToTable("Quiz");

            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedByUserId).HasColumnName("created_by_user_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK__Quiz__created_by__02FC7413");
        });

        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__QuizQues__2EC2154956306B39");

            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.CorrectOption).HasColumnName("correct_option");
            entity.Property(e => e.Option1)
                .HasMaxLength(255)
                .HasColumnName("option_1");
            entity.Property(e => e.Option2)
                .HasMaxLength(255)
                .HasColumnName("option_2");
            entity.Property(e => e.Option3)
                .HasMaxLength(255)
                .HasColumnName("option_3");
            entity.Property(e => e.Option4)
                .HasMaxLength(255)
                .HasColumnName("option_4");
            entity.Property(e => e.QuestionText).HasColumnName("question_text");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizQuestions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__QuizQuest__quiz___05D8E0BE");
        });

        modelBuilder.Entity<RoleAssignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__RoleAssi__DA891814CD3DA466");

            entity.Property(e => e.AssignmentId).HasColumnName("assignment_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleAssignments)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RoleAssig__role___68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.RoleAssignments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RoleAssig__user___6754599E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__B9BE370F2E0B843D");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__UserActi__482FBD6358F0A8D7");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");
            entity.Property(e => e.ActivityTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("activity_timestamp");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(100)
                .HasColumnName("activity_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserActiv__user___08B54D69");
        });

        modelBuilder.Entity<UserProgress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("PK__UserProg__49B3D8C1CB581E2C");

            entity.ToTable("UserProgress");

            entity.Property(e => e.ProgressId).HasColumnName("progress_id");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.ContentId).HasColumnName("content_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Content).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.ContentId)
                .HasConstraintName("FK__UserProgr__conte__7B5B524B");

            entity.HasOne(d => d.User).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserProgr__user___7A672E12");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__760965CC6A06DB68");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<UserSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__UserSess__69B13FDCE09079B0");

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
            entity.Property(e => e.LoginTime)
                .HasColumnType("datetime")
                .HasColumnName("login_time");
            entity.Property(e => e.SessionToken)
                .HasMaxLength(255)
                .HasColumnName("session_token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserSessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserSessi__user___7E37BEF6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

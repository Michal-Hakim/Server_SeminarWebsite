using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class SeminarWebsiteContext : DbContext
{
    public SeminarWebsiteContext()
    {
    }

    public SeminarWebsiteContext(DbContextOptions<SeminarWebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AttendencePerCourseTbl> AttendencePerCourseTbls { get; set; }

    public virtual DbSet<CoursesTbl> CoursesTbls { get; set; }

    public virtual DbSet<ExistedLessonsTbl> ExistedLessonsTbls { get; set; }

    public virtual DbSet<MajorCoursesTbl> MajorCoursesTbls { get; set; }

    public virtual DbSet<MajorTbl> MajorTbls { get; set; }

    public virtual DbSet<MarkPerCourseTbl> MarkPerCourseTbls { get; set; }

    public virtual DbSet<SeminarTbl> SeminarTbls { get; set; }

    public virtual DbSet<StaffTbl> StaffTbls { get; set; }

    public virtual DbSet<StudentsTbl> StudentsTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-2E511JM\\SQLEXPRESS;Database=SeminarWebsite;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttendencePerCourseTbl>(entity =>
        {
            entity.HasKey(e => e.AttendenceCodeForTheCourse).HasName("PK__Attenden__D10AD108FF408C32");

            entity.ToTable("AttendencePerCourse_tbl");

            entity.HasOne(d => d.LessonCodeNavigation).WithMany(p => p.AttendencePerCourseTbls)
                .HasForeignKey(d => d.LessonCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendenc__Lesso__440B1D61");

            entity.HasOne(d => d.StudentCodeNavigation).WithMany(p => p.AttendencePerCourseTbls)
                .HasForeignKey(d => d.StudentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendenc__Stude__44FF419A");
        });

        modelBuilder.Entity<CoursesTbl>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__Courses___FC00E00139EB4DE8");

            entity.ToTable("Courses_tbl");

            entity.Property(e => e.CourseName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ExistedLessonsTbl>(entity =>
        {
            entity.HasKey(e => e.LessonCode).HasName("PK__ExistedL__F447E504D062FC15");

            entity.ToTable("ExistedLessons_tbl");

            entity.Property(e => e.LessonDate).HasColumnType("date");

            entity.HasOne(d => d.CourseCodeForTheMajorNavigation).WithMany(p => p.ExistedLessonsTbls)
                .HasForeignKey(d => d.CourseCodeForTheMajor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExistedLe__Cours__412EB0B6");
        });

        modelBuilder.Entity<MajorCoursesTbl>(entity =>
        {
            entity.HasKey(e => e.CourseCodeForTheMajor).HasName("PK__MajorCou__FD811A27E6418264");

            entity.ToTable("MajorCourses_tbl");

            entity.Property(e => e.CourseGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CourseStartYear).HasColumnType("date");

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.MajorCoursesTbls)
                .HasForeignKey(d => d.CourseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MajorCour__Cours__398D8EEE");

            entity.HasOne(d => d.CourseTeacherCodeNavigation).WithMany(p => p.MajorCoursesTbls)
                .HasForeignKey(d => d.CourseTeacherCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MajorCour__Cours__3A81B327");

            entity.HasOne(d => d.MajorCodeNavigation).WithMany(p => p.MajorCoursesTbls)
                .HasForeignKey(d => d.MajorCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MajorCour__Major__38996AB5");
        });

        modelBuilder.Entity<MajorTbl>(entity =>
        {
            entity.HasKey(e => e.MajorCode).HasName("PK__Major_tb__64E58F9569762373");

            entity.ToTable("Major_tbl");

            entity.Property(e => e.MajorName)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.MajorCodeCoordinatorNavigation).WithMany(p => p.MajorTbls)
                .HasForeignKey(d => d.MajorCodeCoordinator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Major_tbl__Major__2C3393D0");

            entity.HasOne(d => d.SeminarCodeNavigation).WithMany(p => p.MajorTbls)
                .HasForeignKey(d => d.SeminarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Major_tbl__Semin__2D27B809");
        });

        modelBuilder.Entity<MarkPerCourseTbl>(entity =>
        {
            entity.HasKey(e => e.MarkCodeForTheCourse).HasName("PK__MarkPerC__EDE971E67377EE0B");

            entity.ToTable("MarkPerCourse_tbl");

            entity.HasOne(d => d.CourseCodeForTheMajorNavigation).WithMany(p => p.MarkPerCourseTbls)
                .HasForeignKey(d => d.CourseCodeForTheMajor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MarkPerCo__Cours__3D5E1FD2");

            entity.HasOne(d => d.StudentCodeNavigation).WithMany(p => p.MarkPerCourseTbls)
                .HasForeignKey(d => d.StudentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MarkPerCo__Stude__3E52440B");
        });

        modelBuilder.Entity<SeminarTbl>(entity =>
        {
            entity.HasKey(e => e.SeminarCode).HasName("PK__Seminar___FB52B63E8B088AE6");

            entity.ToTable("Seminar_tbl");

            entity.Property(e => e.SeminarAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeminarEmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeminarFaxNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SeminarLocationCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeminarLogo).IsUnicode(false);
            entity.Property(e => e.SeminarManagerPassword)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SeminarName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeminarPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StaffTbl>(entity =>
        {
            entity.HasKey(e => e.StaffCode).HasName("PK__Staff_tb__D83AD81315FC566B");

            entity.ToTable("Staff_tbl");

            entity.Property(e => e.StaffEmploymentStartDate).HasColumnType("date");
            entity.Property(e => e.StaffId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("StaffID");
            entity.Property(e => e.StaffMemberPosition)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.SeminarCodeNavigation).WithMany(p => p.StaffTbls)
                .HasForeignKey(d => d.SeminarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff_tbl__Semin__29572725");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffTbls)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff_tbl__Staff__286302EC");
        });

        modelBuilder.Entity<StudentsTbl>(entity =>
        {
            entity.HasKey(e => e.StudentCode).HasName("PK__Students__1FC8860526FB88D3");

            entity.ToTable("Students_tbl");

            entity.Property(e => e.StudentFatherCellPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StudentId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("StudentID");
            entity.Property(e => e.StudentMotherCellPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentYearOfStartingSchool).HasColumnType("date");

            entity.HasOne(d => d.SeminarCodeNavigation).WithMany(p => p.StudentsTbls)
                .HasForeignKey(d => d.SeminarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students___Semin__33D4B598");

            entity.HasOne(d => d.StudentFirstMajorCodeNavigation).WithMany(p => p.StudentsTblStudentFirstMajorCodeNavigations)
                .HasForeignKey(d => d.StudentFirstMajorCode)
                .HasConstraintName("FK__Students___Stude__30F848ED");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsTbls)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students___Stude__300424B4");

            entity.HasOne(d => d.StudentSecondMajorCodeNavigation).WithMany(p => p.StudentsTblStudentSecondMajorCodeNavigations)
                .HasForeignKey(d => d.StudentSecondMajorCode)
                .HasConstraintName("FK__Students___Stude__31EC6D26");

            entity.HasOne(d => d.StudentTeachingGuideCodeNavigation).WithMany(p => p.StudentsTbls)
                .HasForeignKey(d => d.StudentTeachingGuideCode)
                .HasConstraintName("FK__Students___Stude__32E0915F");
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User_tbl__1788CCAC214AF41B");

            entity.ToTable("User_tbl");

            entity.Property(e => e.UserId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserCellPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserEnglishDateOfBirth).HasColumnType("date");
            entity.Property(e => e.UserFirstName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserHebrewDateOfBirth)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.UserHomePhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserLastName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UserLocationCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

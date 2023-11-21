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

    public virtual DbSet<MessagePerMajorTbl> MessagePerMajorTbls { get; set; }

    public virtual DbSet<SeminarTbl> SeminarTbls { get; set; }

    public virtual DbSet<StaffTbl> StaffTbls { get; set; }

    public virtual DbSet<StudentsTbl> StudentsTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JQVA1GIN;Database=SeminarWebsite;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttendencePerCourseTbl>(entity =>
        {
            entity.HasKey(e => e.AttendenceCodeForTheCourse).HasName("PK__Attenden__D10AD1083F01BA98");

            entity.ToTable("AttendencePerCourse_tbl");

            entity.HasOne(d => d.LessonCodeNavigation).WithMany(p => p.AttendencePerCourseTbls)
                .HasForeignKey(d => d.LessonCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendenc__Lesso__571DF1D5");

            entity.HasOne(d => d.StudentCodeNavigation).WithMany(p => p.AttendencePerCourseTbls)
                .HasForeignKey(d => d.StudentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendenc__Stude__5812160E");
        });

        modelBuilder.Entity<CoursesTbl>(entity =>
        {
            entity.HasKey(e => e.CourseCode).HasName("PK__Courses___FC00E00134BF86A6");

            entity.ToTable("Courses_tbl");

            entity.Property(e => e.CourseName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ExistedLessonsTbl>(entity =>
        {
            entity.HasKey(e => e.LessonCode).HasName("PK__ExistedL__F447E5044AA69840");

            entity.ToTable("ExistedLessons_tbl");

            entity.Property(e => e.LessonDate).HasColumnType("date");

            entity.HasOne(d => d.CourseCodeForTheMajorNavigation).WithMany(p => p.ExistedLessonsTbls)
                .HasForeignKey(d => d.CourseCodeForTheMajor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExistedLe__Cours__5441852A");
        });

        modelBuilder.Entity<MajorCoursesTbl>(entity =>
        {
            entity.HasKey(e => e.CourseCodeForTheMajor).HasName("PK__MajorCou__FD811A27C36AAE81");

            entity.ToTable("MajorCourses_tbl");

            entity.Property(e => e.CourseGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CourseStartYear).HasColumnType("date");

            entity.HasOne(d => d.CourseCodeNavigation).WithMany(p => p.MajorCoursesTbls)
                .HasForeignKey(d => d.CourseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MajorCour__Cours__4CA06362");

            entity.HasOne(d => d.CourseTeacherCodeNavigation).WithMany(p => p.MajorCoursesTbls)
                .HasForeignKey(d => d.CourseTeacherCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MajorCour__Cours__4D94879B");

            entity.HasOne(d => d.MajorCodeNavigation).WithMany(p => p.MajorCoursesTbls)
                .HasForeignKey(d => d.MajorCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MajorCour__Major__4BAC3F29");
        });

        modelBuilder.Entity<MajorTbl>(entity =>
        {
            entity.HasKey(e => e.MajorCode).HasName("PK__Major_tb__64E58F95E8C1C2B2");

            entity.ToTable("Major_tbl");

            entity.Property(e => e.MajorName)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.MajorCodeCoordinatorNavigation).WithMany(p => p.MajorTbls)
                .HasForeignKey(d => d.MajorCodeCoordinator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Major_tbl__Major__3F466844");

            entity.HasOne(d => d.SeminarCodeNavigation).WithMany(p => p.MajorTbls)
                .HasForeignKey(d => d.SeminarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Major_tbl__Semin__403A8C7D");
        });

        modelBuilder.Entity<MarkPerCourseTbl>(entity =>
        {
            entity.HasKey(e => e.MarkCodeForTheCourse).HasName("PK__MarkPerC__EDE971E661B1D5D8");

            entity.ToTable("MarkPerCourse_tbl");

            entity.HasOne(d => d.CourseCodeForTheMajorNavigation).WithMany(p => p.MarkPerCourseTbls)
                .HasForeignKey(d => d.CourseCodeForTheMajor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MarkPerCo__Cours__5165187F");

            entity.HasOne(d => d.StudentCodeNavigation).WithMany(p => p.MarkPerCourseTbls)
                .HasForeignKey(d => d.StudentCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MarkPerCo__Stude__5070F446");
        });

        modelBuilder.Entity<MessagePerMajorTbl>(entity =>
        {
            entity.HasKey(e => e.MessageCode).HasName("PK__MessageP__54E8229E1B2CCA97");

            entity.ToTable("MessagePerMajor_tbl");

            entity.Property(e => e.MessageContent).IsUnicode(false);
            entity.Property(e => e.MessageDate).HasColumnType("date");

            entity.HasOne(d => d.MajorCodeNavigation).WithMany(p => p.MessagePerMajorTbls)
                .HasForeignKey(d => d.MajorCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MessagePe__Major__5AEE82B9");

            entity.HasOne(d => d.StaffCodeNavigation).WithMany(p => p.MessagePerMajorTbls)
                .HasForeignKey(d => d.StaffCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MessagePe__Staff__5BE2A6F2");
        });

        modelBuilder.Entity<SeminarTbl>(entity =>
        {
            entity.HasKey(e => e.SeminarCode).HasName("PK__Seminar___FB52B63EB5DA458A");

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
            entity.HasKey(e => e.StaffCode).HasName("PK__Staff_tb__D83AD81318A2522A");

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
                .HasConstraintName("FK__Staff_tbl__Semin__3C69FB99");

            entity.HasOne(d => d.Staff).WithMany(p => p.StaffTbls)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Staff_tbl__Staff__3B75D760");
        });

        modelBuilder.Entity<StudentsTbl>(entity =>
        {
            entity.HasKey(e => e.StudentCode).HasName("PK__Students__1FC8860557D7BB0E");

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
            entity.Property(e => e.StudentMessageBox).IsUnicode(false);
            entity.Property(e => e.StudentMotherCellPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentYearOfStartingSchool).HasColumnType("date");

            entity.HasOne(d => d.SeminarCodeNavigation).WithMany(p => p.StudentsTbls)
                .HasForeignKey(d => d.SeminarCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students___Semin__440B1D61");

            entity.HasOne(d => d.StudentFirstMajorCodeNavigation).WithMany(p => p.StudentsTblStudentFirstMajorCodeNavigations)
                .HasForeignKey(d => d.StudentFirstMajorCode)
                .HasConstraintName("FK__Students___Stude__44FF419A");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsTbls)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Students___Stude__4316F928");

            entity.HasOne(d => d.StudentSecondMajorCodeNavigation).WithMany(p => p.StudentsTblStudentSecondMajorCodeNavigations)
                .HasForeignKey(d => d.StudentSecondMajorCode)
                .HasConstraintName("FK__Students___Stude__45F365D3");

            entity.HasOne(d => d.StudentTeachingGuideCodeNavigation).WithMany(p => p.StudentsTbls)
                .HasForeignKey(d => d.StudentTeachingGuideCode)
                .HasConstraintName("FK__Students___Stude__46E78A0C");
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User_tbl__1788CCACE98EB568");

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
            entity.Property(e => e.UserHebrewDateOfBirth).HasMaxLength(9);
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

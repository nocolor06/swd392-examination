using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace examination_schedule.Models
{
    public partial class SWD392_ClinicScheduleContext : DbContext
    {
        public SWD392_ClinicScheduleContext()
        {
        }

        public SWD392_ClinicScheduleContext(DbContextOptions<SWD392_ClinicScheduleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;
        public virtual DbSet<TimeSlot> TimeSlots { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =LAPTOP-SK2I1UHQ\\SQLEXPRESScl; database = SWD392_ClinicSchedule;uid=sa;pwd=30102003;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__BE2D26B654DC98F9");

                entity.ToTable("Department");

                entity.Property(e => e.DeptId)
                    .ValueGeneratedNever()
                    .HasColumnName("deptId");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(255)
                    .HasColumnName("deptName");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("doctorId");

                entity.Property(e => e.DeptId).HasColumnName("deptId");

                entity.Property(e => e.License)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("license");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK__Doctor__deptId__0B91BA14");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Doctor__username__0A9D95DB");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.DoctorId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("doctorId");

                entity.Property(e => e.EventType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("eventType");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patientId");

                entity.Property(e => e.RoomId).HasColumnName("roomId");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("staffId");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TimeSlotId).HasColumnName("timeSlotId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Event__doctorId__18EBB532");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Event__patientId__19DFD96B");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Event__roomId__1BC821DD");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Event__staffId__1AD3FDA4");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Event__timeSlotI__1CBC4616");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patientId");

                entity.Property(e => e.MedicalRecord)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("medicalRecord");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Patient__usernam__07C12930");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId)
                    .ValueGeneratedNever()
                    .HasColumnName("roomId");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(255)
                    .HasColumnName("roomName");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("staffId");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK__Staff__username__0E6E26BF");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.EndTime).HasColumnName("endTime");

                entity.Property(e => e.StartTime).HasColumnName("startTime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__F3DBC57369F796D9");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastName");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

namespace EXON.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EXON.Model;

    public partial class EXONDbContext : DbContext
    {
        public EXONDbContext()
            : base("name=EXONSystem")
        {
        }

        public virtual DbSet<ANSWER> ANSWERS { get; set; }
        public virtual DbSet<ANSWERSHEET_DETAIL> ANSWERSHEET_DETAIL { get; set; }
        public virtual DbSet<ANSWERSHEET> ANSWERSHEETS { get; set; }
        public virtual DbSet<BAGOFTEST> BAGOFTESTS { get; set; }
        public virtual DbSet<CONTEST_TYPES> CONTEST_TYPES { get; set; }
        public virtual DbSet<CONTESTANT_TYPES> CONTESTANT_TYPES { get; set; }
        public virtual DbSet<CONTESTANT> CONTESTANTS { get; set; }
        public virtual DbSet<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }
        public virtual DbSet<CONTESTANTS_SUBJECTS> CONTESTANTS_SUBJECTS { get; set; }
        public virtual DbSet<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }
        public virtual DbSet<CONTEST> CONTESTS { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTS { get; set; }
        public virtual DbSet<FINGERPRINT> FINGERPRINTS { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<MODULE> MODULES { get; set; }
        public virtual DbSet<POSITION> POSITIONS { get; set; }
        public virtual DbSet<QUESTION_TYPES> QUESTION_TYPES { get; set; }
        public virtual DbSet<QUESTION> QUESTIONS { get; set; }
        public virtual DbSet<RECEIPT> RECEIPTS { get; set; }
        public virtual DbSet<REGISTER> REGISTERS { get; set; }
        public virtual DbSet<REGISTERS_SUBJECTS> REGISTERS_SUBJECTS { get; set; }
        public virtual DbSet<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }
        public virtual DbSet<ROOMTEST> ROOMTESTS { get; set; }
        public virtual DbSet<SCHEDULE> SCHEDULES { get; set; }
        public virtual DbSet<SHIFT> SHIFTS { get; set; }
        public virtual DbSet<SHIFTS_STAFFS> SHIFTS_STAFFS { get; set; }
        public virtual DbSet<STAFF> STAFFS { get; set; }
        public virtual DbSet<STRUCTURE_DETAIL> STRUCTURE_DETAIL { get; set; }
        public virtual DbSet<STRUCTURE> STRUCTURES { get; set; }
        public virtual DbSet<SUBJECT> SUBJECTS { get; set; }
        public virtual DbSet<SUBQUESTION> SUBQUESTIONS { get; set; }
        public virtual DbSet<TEST_DETAIL> TEST_DETAIL { get; set; }
        public virtual DbSet<TEST> TESTS { get; set; }
        public virtual DbSet<TOPIC> TOPICS { get; set; }
        public virtual DbSet<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }
        public virtual DbSet<VIOLATION_TYPES> VIOLATION_TYPES { get; set; }
        public virtual DbSet<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ANSWERSHEET_DETAIL>()
                .Property(e => e.AnswerSheetDetailContent)
                .IsUnicode(false);

            modelBuilder.Entity<ANSWERSHEET>()
                .Property(e => e.AnswerContent)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.ContestantCode)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANT>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANTS_SHIFTS>()
                .Property(e => e.ClientIP)
                .IsUnicode(false);

            modelBuilder.Entity<CONTESTANTS_SHIFTS>()
                .Property(e => e.ContestantPass)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.DEPARTMENTS1)
                .WithOptional(e => e.DEPARTMENT1)
                .HasForeignKey(e => e.DepartmentIDParent);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.STAFFS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DEPARTMENT>()
                .HasMany(e => e.SUBJECTS)
                .WithRequired(e => e.DEPARTMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POSITION>()
                .HasMany(e => e.STAFFS)
                .WithRequired(e => e.POSITION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REGISTER>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ComputerCode)
                .IsUnicode(false);

            modelBuilder.Entity<ROOMDIAGRAM>()
                .Property(e => e.ComputerName)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .Property(e => e.IdentityCardNumber)
                .IsUnicode(false);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.CONTESTS)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.StaffID1);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.CONTESTS1)
                .WithOptional(e => e.STAFF1)
                .HasForeignKey(e => e.StaffID2);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.QUESTIONS)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.StaffID1);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.QUESTIONS1)
                .WithOptional(e => e.STAFF1)
                .HasForeignKey(e => e.StaffID2);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.TOPICS_STAFFS)
                .WithOptional(e => e.STAFF)
                .HasForeignKey(e => e.StaffID1);

            modelBuilder.Entity<STAFF>()
                .HasMany(e => e.TOPICS_STAFFS1)
                .WithOptional(e => e.STAFF1)
                .HasForeignKey(e => e.StaffID2);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.MODULES)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SUBJECT>()
                .HasMany(e => e.TOPICS)
                .WithRequired(e => e.SUBJECT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEST_DETAIL>()
                .Property(e => e.RandomAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<TOPIC>()
                .HasMany(e => e.TOPICS_STAFFS)
                .WithRequired(e => e.TOPIC)
                .WillCascadeOnDelete(false);
        }
    }
}

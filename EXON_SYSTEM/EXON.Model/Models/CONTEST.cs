namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTS")]
    public partial class CONTEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTEST()
        {
            CONTESTANTS = new HashSet<CONTESTANT>();
            LOCATIONS = new HashSet<LOCATION>();
            REGISTERS = new HashSet<REGISTER>();
            SCHEDULES = new HashSet<SCHEDULE>();
        }

        public int ContestID { get; set; }

        [StringLength(100)]
        public string ContestName { get; set; }

        public string Description { get; set; }

        public int? CreateDate { get; set; }

        public int? AcceptDate { get; set; }

        public int? BeginRegisiter { get; set; }

        public int? EndRegister { get; set; }

        public int? QuestionStartDate { get; set; }

        public int? QuestionEndDate { get; set; }

        public int? SchoolYear { get; set; }

        public int Status { get; set; }

        public int? StaffID1 { get; set; }

        public int? StaffID2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANT> CONTESTANTS { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual STAFF STAFF1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOCATION> LOCATIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTER> REGISTERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULES { get; set; }
    }
}

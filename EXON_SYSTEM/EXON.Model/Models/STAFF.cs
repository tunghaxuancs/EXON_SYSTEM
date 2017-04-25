namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STAFFS")]
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            CONTESTS = new HashSet<CONTEST>();
            CONTESTS1 = new HashSet<CONTEST>();
            QUESTIONS = new HashSet<QUESTION>();
            QUESTIONS1 = new HashSet<QUESTION>();
            RECEIPTS = new HashSet<RECEIPT>();
            SHIFTS_STAFFS = new HashSet<SHIFTS_STAFFS>();
            STRUCTURES = new HashSet<STRUCTURE>();
            TOPICS_STAFFS = new HashSet<TOPICS_STAFFS>();
            TOPICS_STAFFS1 = new HashSet<TOPICS_STAFFS>();
        }

        public int StaffID { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        public int Birthday { get; set; }

        public int Sex { get; set; }

        [Required]
        [StringLength(12)]
        public string IdentityCardNumber { get; set; }

        public string AcademicRank { get; set; }

        public string Degree { get; set; }

        public string CurrentAddress { get; set; }

        public int Status { get; set; }

        public int PositionID { get; set; }

        public int DepartmentID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTEST> CONTESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTEST> CONTESTS1 { get; set; }

        public virtual DEPARTMENT DEPARTMENT { get; set; }

        public virtual POSITION POSITION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEIPT> RECEIPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFTS_STAFFS> SHIFTS_STAFFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE> STRUCTURES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOPICS_STAFFS> TOPICS_STAFFS1 { get; set; }
    }
}

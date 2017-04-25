namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONTESTANTS")]
    public partial class CONTESTANT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANT()
        {
            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            FINGERPRINTS = new HashSet<FINGERPRINT>();
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            CONTESTANTS_SUBJECTS = new HashSet<CONTESTANTS_SUBJECTS>();
        }

        public int ContestantID { get; set; }

        [StringLength(20)]
        public string ContestantCode { get; set; }

        public int Status { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        public int? Birthday { get; set; }

        [StringLength(100)]
        public string Ethnic { get; set; }

        public string PlaceOfBirth { get; set; }

        public string HighSchool { get; set; }

        public int? Sex { get; set; }

        [StringLength(12)]
        public string IdentityCardNumber { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        public string CurrentAddress { get; set; }

        public int? ContestID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FINGERPRINT> FINGERPRINTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SUBJECTS> CONTESTANTS_SUBJECTS { get; set; }
    }
}

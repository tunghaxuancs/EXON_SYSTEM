namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REGISTERS")]
    public partial class REGISTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REGISTER()
        {
            RECEIPTS = new HashSet<RECEIPT>();
            REGISTERS_SUBJECTS = new HashSet<REGISTERS_SUBJECTS>();
        }

        public int RegisterID { get; set; }

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

        public int? RegisterDate { get; set; }

        public bool? RegisterType { get; set; }

        public int Status { get; set; }

        public int? ContestID { get; set; }

        public int? ContestantTypeID { get; set; }

        public virtual CONTESTANT_TYPES CONTESTANT_TYPES { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEIPT> RECEIPTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGISTERS_SUBJECTS> REGISTERS_SUBJECTS { get; set; }
    }
}

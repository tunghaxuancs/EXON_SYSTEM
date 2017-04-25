namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIOLATION_TYPES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VIOLATION_TYPES()
        {
            VIOLATIONS_CONTESTANTS = new HashSet<VIOLATIONS_CONTESTANTS>();
        }

        [Key]
        public int ViolationTypeID { get; set; }

        [StringLength(100)]
        public string ViolationName { get; set; }

        public string Description { get; set; }

        public int? Level { get; set; }

        public int Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
    }
}

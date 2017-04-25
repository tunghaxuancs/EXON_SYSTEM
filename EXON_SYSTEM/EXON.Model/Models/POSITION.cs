namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POSITIONS")]
    public partial class POSITION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POSITION()
        {
            STAFFS = new HashSet<STAFF>();
        }

        public int PositionID { get; set; }

        [Required]
        [StringLength(10)]
        public string PositionCode { get; set; }

        [Required]
        public string PositionName { get; set; }

        public int Permission { get; set; }

        public int Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STAFF> STAFFS { get; set; }
    }
}

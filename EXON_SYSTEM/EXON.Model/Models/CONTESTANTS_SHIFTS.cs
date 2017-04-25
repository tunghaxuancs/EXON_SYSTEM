namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_SHIFTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTESTANTS_SHIFTS()
        {
            VIOLATIONS_CONTESTANTS = new HashSet<VIOLATIONS_CONTESTANTS>();
        }

        [Key]
        public int ContestantShiftID { get; set; }

        [StringLength(25)]
        public string ClientIP { get; set; }

        public int Status { get; set; }

        [StringLength(20)]
        public string ContestantPass { get; set; }

        public int? ShiftID { get; set; }

        public int? ContestantID { get; set; }

        public int? RoomDiagramID { get; set; }

        public virtual CONTESTANT CONTESTANT { get; set; }

        public virtual ROOMDIAGRAM ROOMDIAGRAM { get; set; }

        public virtual SHIFT SHIFT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VIOLATIONS_CONTESTANTS> VIOLATIONS_CONTESTANTS { get; set; }
    }
}

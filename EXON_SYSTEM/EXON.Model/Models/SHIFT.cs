namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHIFTS")]
    public partial class SHIFT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHIFT()
        {
            BAGOFTESTS = new HashSet<BAGOFTEST>();
            CONTESTANTS_SHIFTS = new HashSet<CONTESTANTS_SHIFTS>();
            SHIFTS_STAFFS = new HashSet<SHIFTS_STAFFS>();
        }

        public int ShiftID { get; set; }

        public int? ShiftDate { get; set; }

        public int? StartTime { get; set; }

        public int? EndTime { get; set; }

        public int? ScheduleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAGOFTEST> BAGOFTESTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_SHIFTS> CONTESTANTS_SHIFTS { get; set; }

        public virtual SCHEDULE SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFTS_STAFFS> SHIFTS_STAFFS { get; set; }
    }
}

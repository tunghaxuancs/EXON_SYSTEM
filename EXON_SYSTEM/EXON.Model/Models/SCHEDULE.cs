namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SCHEDULES")]
    public partial class SCHEDULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHEDULE()
        {
            SHIFTS = new HashSet<SHIFT>();
            STRUCTURES = new HashSet<STRUCTURE>();
        }

        public int ScheduleID { get; set; }

        public int? StartDate { get; set; }

        public int? EndDate { get; set; }

        public int TimeOfTest { get; set; }

        public int Status { get; set; }

        public int? ContestID { get; set; }

        public int? SubjectID { get; set; }

        public int? ContestTypeID { get; set; }

        public virtual CONTEST_TYPES CONTEST_TYPES { get; set; }

        public virtual CONTEST CONTEST { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFT> SHIFTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE> STRUCTURES { get; set; }
    }
}

namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VIOLATIONS_CONTESTANTS
    {
        [Key]
        public int ViolationDetailID { get; set; }

        public int Status { get; set; }

        public int? ViolationTypeID { get; set; }

        public int? ContestantShiftID { get; set; }

        public virtual CONTESTANTS_SHIFTS CONTESTANTS_SHIFTS { get; set; }

        public virtual VIOLATION_TYPES VIOLATION_TYPES { get; set; }
    }
}

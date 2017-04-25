namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SHIFTS_STAFFS
    {
        [Key]
        public int DivisionShiftID { get; set; }

        public int Status { get; set; }

        public int? ShiftID { get; set; }

        public int? StaffID { get; set; }

        public int? RoomTestID { get; set; }

        public virtual ROOMTEST ROOMTEST { get; set; }

        public virtual SHIFT SHIFT { get; set; }

        public virtual STAFF STAFF { get; set; }
    }
}

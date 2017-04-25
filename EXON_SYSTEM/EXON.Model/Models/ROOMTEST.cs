namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ROOMTESTS")]
    public partial class ROOMTEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROOMTEST()
        {
            ROOMDIAGRAMS = new HashSet<ROOMDIAGRAM>();
            SHIFTS_STAFFS = new HashSet<SHIFTS_STAFFS>();
        }

        public int RoomTestID { get; set; }

        [StringLength(100)]
        public string RoomTestName { get; set; }

        public int? MaxSeatMount { get; set; }

        public int? MaxSupervisor { get; set; }

        public int Status { get; set; }

        public int? LocationID { get; set; }

        public virtual LOCATION LOCATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROOMDIAGRAM> ROOMDIAGRAMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHIFTS_STAFFS> SHIFTS_STAFFS { get; set; }
    }
}

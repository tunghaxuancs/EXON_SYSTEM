namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAGOFTESTS")]
    public partial class BAGOFTEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAGOFTEST()
        {
            TESTS = new HashSet<TEST>();
        }

        public int BagOfTestID { get; set; }

        public int? NumberOfTest { get; set; }

        public int? ShiftID { get; set; }

        public virtual SHIFT SHIFT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST> TESTS { get; set; }
    }
}

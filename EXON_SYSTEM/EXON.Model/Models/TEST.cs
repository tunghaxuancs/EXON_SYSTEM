namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TESTS")]
    public partial class TEST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEST()
        {
            ANSWERSHEETS = new HashSet<ANSWERSHEET>();
            CONTESTANTS_TESTS = new HashSet<CONTESTANTS_TESTS>();
            TEST_DETAIL = new HashSet<TEST_DETAIL>();
        }

        public int TestID { get; set; }

        public int? TestDate { get; set; }

        public int Status { get; set; }

        public int? BagOfTestID { get; set; }

        public int? StructureID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET> ANSWERSHEETS { get; set; }

        public virtual BAGOFTEST BAGOFTEST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTESTANTS_TESTS> CONTESTANTS_TESTS { get; set; }

        public virtual STRUCTURE STRUCTURE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAIL> TEST_DETAIL { get; set; }
    }
}

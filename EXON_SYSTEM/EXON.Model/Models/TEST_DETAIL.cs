namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEST_DETAIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEST_DETAIL()
        {
            ANSWERSHEET_DETAIL = new HashSet<ANSWERSHEET_DETAIL>();
        }

        [Key]
        public int TestDetailID { get; set; }

        [StringLength(200)]
        public string RandomAnswer { get; set; }

        public int? NumberIndex { get; set; }

        public int? TestID { get; set; }

        public int? QuestionID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET_DETAIL> ANSWERSHEET_DETAIL { get; set; }

        public virtual QUESTION QUESTION { get; set; }

        public virtual TEST TEST { get; set; }
    }
}

namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUESTIONS")]
    public partial class QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION()
        {
            SUBQUESTIONS = new HashSet<SUBQUESTION>();
            TEST_DETAIL = new HashSet<TEST_DETAIL>();
        }

        public int QuestionID { get; set; }

        public string QuestionContent { get; set; }

        public int? Level { get; set; }

        public int Status { get; set; }

        public int? CreatedDate { get; set; }

        public int? UpdateDate { get; set; }

        public int? AcceptedDate { get; set; }

        public int? QuestionTypeID { get; set; }

        public int? TopicID { get; set; }

        public int? StaffID1 { get; set; }

        public int? StaffID2 { get; set; }

        public virtual QUESTION_TYPES QUESTION_TYPES { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual STAFF STAFF1 { get; set; }

        public virtual TOPIC TOPIC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUBQUESTION> SUBQUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEST_DETAIL> TEST_DETAIL { get; set; }
    }
}

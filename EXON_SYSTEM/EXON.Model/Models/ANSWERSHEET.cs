namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ANSWERSHEETS")]
    public partial class ANSWERSHEET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ANSWERSHEET()
        {
            ANSWERSHEET_DETAIL = new HashSet<ANSWERSHEET_DETAIL>();
        }

        public int AnswerSheetID { get; set; }

        public string AnswerContent { get; set; }

        public double? TestScores { get; set; }

        public double? EssayPoints { get; set; }

        public int Status { get; set; }

        public int? ContestantID { get; set; }

        public int? TestID { get; set; }

        public int? StaffID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ANSWERSHEET_DETAIL> ANSWERSHEET_DETAIL { get; set; }

        public virtual CONTESTANT CONTESTANT { get; set; }

        public virtual STAFF STAFF { get; set; }

        public virtual TEST TEST { get; set; }
    }
}

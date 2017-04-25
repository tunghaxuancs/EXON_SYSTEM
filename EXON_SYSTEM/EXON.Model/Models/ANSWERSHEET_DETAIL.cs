namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ANSWERSHEET_DETAIL
    {
        [Key]
        public int AnswerSheetDetailID { get; set; }

        public string AnswerSheetDetailContent { get; set; }

        public int? LastTime { get; set; }

        public int? AnswerSheetID { get; set; }

        public int? TestDetailID { get; set; }

        public virtual ANSWERSHEET ANSWERSHEET { get; set; }

        public virtual TEST_DETAIL TEST_DETAIL { get; set; }
    }
}

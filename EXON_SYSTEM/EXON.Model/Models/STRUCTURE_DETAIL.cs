namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STRUCTURE_DETAIL
    {
        [Key]
        public int StructureDetailID { get; set; }

        public int? NumberQuestions { get; set; }

        public int? Level { get; set; }

        public int? StructureID { get; set; }

        public int? TopicID { get; set; }

        public int? QuestionTypeID { get; set; }

        public virtual QUESTION_TYPES QUESTION_TYPES { get; set; }

        public virtual STRUCTURE STRUCTURE { get; set; }

        public virtual TOPIC TOPIC { get; set; }
    }
}

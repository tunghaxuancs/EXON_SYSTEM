namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QUESTION_TYPES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION_TYPES()
        {
            QUESTIONS = new HashSet<QUESTION>();
            STRUCTURE_DETAIL = new HashSet<STRUCTURE_DETAIL>();
        }

        [Key]
        public int QuestionTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public string QuestionTypeName { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public bool IsQuiz { get; set; }

        public bool IsSingleChoice { get; set; }

        public bool IsParagraph { get; set; }

        public bool IsQuestionContent { get; set; }

        public bool IsMixSubQuestion { get; set; }

        public int NumberSubQuestion { get; set; }

        public int NumberAnswer { get; set; }

        public int Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE_DETAIL> STRUCTURE_DETAIL { get; set; }
    }
}

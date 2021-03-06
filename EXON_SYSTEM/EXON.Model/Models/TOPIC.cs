namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOPICS")]
    public partial class TOPIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOPIC()
        {
            QUESTIONS = new HashSet<QUESTION>();
            STRUCTURE_DETAIL = new HashSet<STRUCTURE_DETAIL>();
            TOPICS_STAFFS = new HashSet<TOPICS_STAFFS>();
        }

        public int TopicID { get; set; }

        [StringLength(100)]
        public string TopicName { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }

        public int SubjectID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUESTION> QUESTIONS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STRUCTURE_DETAIL> STRUCTURE_DETAIL { get; set; }

        public virtual SUBJECT SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOPICS_STAFFS> TOPICS_STAFFS { get; set; }
    }
}

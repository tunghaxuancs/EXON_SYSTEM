namespace EXON.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONTESTANTS_TESTS
    {
        [Key]
        public int ContestantTestID { get; set; }

        public int? ContestantID { get; set; }

        public int? TestID { get; set; }

        public virtual CONTESTANT CONTESTANT { get; set; }

        public virtual TEST TEST { get; set; }
    }
}

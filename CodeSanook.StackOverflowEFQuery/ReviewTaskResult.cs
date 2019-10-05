namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReviewTaskResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReviewTaskResult()
        {
            ReviewTasks = new HashSet<ReviewTask>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int ReviewTaskId { get; set; }

        public byte ReviewTaskResultTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreationDate { get; set; }

        public byte? RejectionReasonId { get; set; }

        [StringLength(150)]
        public string Comment { get; set; }

        public virtual ReviewRejectionReason ReviewRejectionReason { get; set; }

        public virtual ReviewTask ReviewTask { get; set; }

        public virtual ReviewTaskResultType ReviewTaskResultType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewTask> ReviewTasks { get; set; }
    }
}

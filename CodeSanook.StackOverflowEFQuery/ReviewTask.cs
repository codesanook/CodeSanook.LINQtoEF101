namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReviewTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReviewTask()
        {
            ReviewTaskResults = new HashSet<ReviewTaskResult>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public byte ReviewTaskTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeletionDate { get; set; }

        public byte ReviewTaskStateId { get; set; }

        public int PostId { get; set; }

        public int? SuggestedEditId { get; set; }

        public int? CompletedByReviewTaskId { get; set; }

        public virtual Post Post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewTaskResult> ReviewTaskResults { get; set; }

        public virtual ReviewTaskResult ReviewTaskResult { get; set; }

        public virtual ReviewTaskState ReviewTaskState { get; set; }

        public virtual ReviewTaskType ReviewTaskType { get; set; }

        public virtual SuggestedEdit SuggestedEdit { get; set; }
    }
}

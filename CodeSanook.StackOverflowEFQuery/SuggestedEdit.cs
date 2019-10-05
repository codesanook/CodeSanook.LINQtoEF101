namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggestedEdit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuggestedEdit()
        {
            ReviewTasks = new HashSet<ReviewTask>();
            SuggestedEditVotes = new HashSet<SuggestedEditVote>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int PostId { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public DateTime? RejectionDate { get; set; }

        public int? OwnerUserId { get; set; }

        [StringLength(800)]
        public string Comment { get; set; }

        [StringLength(800)]
        public string Text { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Tags { get; set; }

        public Guid? RevisionGUID { get; set; }

        public virtual Post Post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewTask> ReviewTasks { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestedEditVote> SuggestedEditVotes { get; set; }
    }
}

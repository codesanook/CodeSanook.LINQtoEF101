namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CloseAsOffTopicReasonType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CloseAsOffTopicReasonType()
        {
            PendingFlags = new HashSet<PendingFlag>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Id { get; set; }

        public bool IsUniversal { get; set; }

        [Required]
        [StringLength(500)]
        public string MarkdownMini { get; set; }

        public DateTime CreationDate { get; set; }

        public int? CreationModeratorId { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public int? ApprovalModeratorId { get; set; }

        public DateTime? DeactivationDate { get; set; }

        public int? DeactivationModeratorId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PendingFlag> PendingFlags { get; set; }
    }
}

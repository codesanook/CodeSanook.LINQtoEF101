using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class CloseAsOffTopicReasonType
  {
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
    public DateTime? ApprovalDate { get; set; }
    public DateTime? DeactivationDate { get; set; }

    public int? CreationModeratorId { get; set; }
    public int? ApprovalModeratorId { get; set; }
    public int? DeactivationModeratorId { get; set; }

    public virtual User CreationModerator { get; set; }
    public virtual User ApprovalModerator { get; set; }
    public virtual User DeactivationModerator { get; set; }

    public virtual ICollection<PendingFlag> PendingFlags { get; set; }
  }
}

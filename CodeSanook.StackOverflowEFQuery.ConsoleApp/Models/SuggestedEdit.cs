using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class SuggestedEdit
  {
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

    public virtual ICollection<ReviewTask> ReviewTasks { get; set; }

    public virtual User User { get; set; }

    public virtual ICollection<SuggestedEditVote> SuggestedEditVotes { get; set; }
  }
}

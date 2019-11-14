using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class SuggestedEditVote
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int SuggestedEditId { get; set; }
    public byte VoteTypeId { get; set; }
    public DateTime CreationDate { get; set; }

    public int UserId { get; set; }
    public int? TargetUserId { get; set; }
    public int TargetRepChange { get; set; }
    public virtual SuggestedEdit SuggestedEdit { get; set; }

    public virtual User User { get; set; }
    public virtual User TargetUser { get; set; }

    public virtual VoteType VoteType { get; set; }
  }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class VoteType
  {
    public VoteType()
    {
      PostFeedbacks = new HashSet<PostFeedback>();
      SuggestedEditVotes = new HashSet<SuggestedEditVote>();
      Votes = new HashSet<Vote>();
    }

    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public virtual ICollection<PostFeedback> PostFeedbacks { get; set; }
    public virtual ICollection<SuggestedEditVote> SuggestedEditVotes { get; set; }
    public virtual ICollection<Vote> Votes { get; set; }
  }
}

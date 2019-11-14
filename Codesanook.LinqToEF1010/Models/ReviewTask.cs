using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class ReviewTask
  {
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

    public virtual ICollection<ReviewTaskResult> ReviewTaskResults { get; set; }

    public virtual ReviewTaskResult ReviewTaskResult { get; set; }

    public virtual ReviewTaskState ReviewTaskState { get; set; }

    public virtual ReviewTaskType ReviewTaskType { get; set; }

    public virtual SuggestedEdit SuggestedEdit { get; set; }
  }
}

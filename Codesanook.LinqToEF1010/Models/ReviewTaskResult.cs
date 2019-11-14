using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class ReviewTaskResult
  {
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

    public virtual ICollection<ReviewTask> ReviewTasks { get; set; }
  }
}

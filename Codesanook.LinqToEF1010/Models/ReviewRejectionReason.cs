using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class ReviewRejectionReason
  {
    public ReviewRejectionReason()
    {
      ReviewTaskResults = new HashSet<ReviewTaskResult>();
    }

    public byte Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(300)]
    public string Description { get; set; }

    public byte? PostTypeId { get; set; }
    public virtual PostType PostType { get; set; }
    public virtual ICollection<ReviewTaskResult> ReviewTaskResults { get; set; }
  }
}

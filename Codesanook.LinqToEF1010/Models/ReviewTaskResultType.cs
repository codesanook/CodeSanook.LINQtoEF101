using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class ReviewTaskResultType
  {
    public ReviewTaskResultType()
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

    public virtual ICollection<ReviewTaskResult> ReviewTaskResults { get; set; }
  }
}

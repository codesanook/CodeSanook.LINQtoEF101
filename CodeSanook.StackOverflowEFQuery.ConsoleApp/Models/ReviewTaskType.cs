using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class ReviewTaskType
  {
    public ReviewTaskType()
    {
      ReviewTasks = new HashSet<ReviewTask>();
    }

    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(300)]
    public string Description { get; set; }

    public virtual ICollection<ReviewTask> ReviewTasks { get; set; }
  }
}

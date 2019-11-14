using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class PostHistoryType
  {
    public PostHistoryType()
    {
      PostHistories = new HashSet<PostHistory>();
    }

    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public virtual ICollection<PostHistory> PostHistories { get; set; }
  }
}

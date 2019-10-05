using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class FlagType
  {
    public FlagType()
    {
      PendingFlags = new HashSet<PendingFlag>();
    }

    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    public virtual ICollection<PendingFlag> PendingFlags { get; set; }
  }
}

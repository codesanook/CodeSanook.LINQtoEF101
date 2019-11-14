using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class PostType
  {
    public PostType()
    {
      Posts = new HashSet<Post>();
      PostsWithDeleteds = new HashSet<PostsWithDeleted>();
      ReviewRejectionReasons = new HashSet<ReviewRejectionReason>();
    }

    public byte Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<PostsWithDeleted> PostsWithDeleteds { get; set; }
    public virtual ICollection<ReviewRejectionReason> ReviewRejectionReasons { get; set; }
  }
}

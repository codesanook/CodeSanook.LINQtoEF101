using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class PostLink
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }
    public int PostId { get; set; }
    public int RelatedPostId { get; set; }
    public byte LinkTypeId { get; set; }
    public virtual Post Post { get; set; }
    public virtual Post RelatedPost { get; set; }
  }
}

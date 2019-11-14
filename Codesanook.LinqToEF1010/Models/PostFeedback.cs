using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  [Table("PostFeedback")]
  public class PostFeedback
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int PostId { get; set; }
    public bool? IsAnonymous { get; set; }
    public byte VoteTypeId { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual Post Post { get; set; }
    public virtual VoteType VoteType { get; set; }
  }
}

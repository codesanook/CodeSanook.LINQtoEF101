using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class Comment
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int PostId { get; set; }
    public int Score { get; set; }

    [Required]
    [StringLength(600)]
    public string Text { get; set; }

    public DateTime CreationDate { get; set; }

    [StringLength(30)]
    public string UserDisplayName { get; set; }

    public int? UserId { get; set; }
    public virtual Post Post { get; set; }
    public virtual User User { get; set; }
  }
}

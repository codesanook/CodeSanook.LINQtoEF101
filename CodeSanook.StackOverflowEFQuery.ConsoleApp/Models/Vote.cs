using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class Vote
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int PostId { get; set; }

    public byte VoteTypeId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? BountyAmount { get; set; }

    public virtual Post Post { get; set; }

    public virtual User User { get; set; }

    public virtual VoteType VoteType { get; set; }
  }
}

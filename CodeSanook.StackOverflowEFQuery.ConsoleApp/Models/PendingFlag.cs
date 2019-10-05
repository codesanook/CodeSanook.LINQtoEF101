using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class PendingFlag
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public byte FlagTypeId { get; set; }

    public int PostId { get; set; }

    [Column(TypeName = "date")]
    public DateTime? CreationDate { get; set; }

    public byte? CloseReasonTypeId { get; set; }

    public short? CloseAsOffTopicReasonTypeId { get; set; }

    public int? DuplicateOfQuestionId { get; set; }

    [StringLength(100)]
    public string BelongsOnBaseHostAddress { get; set; }

    public virtual CloseAsOffTopicReasonType CloseAsOffTopicReasonType { get; set; }

    public virtual CloseReasonType CloseReasonType { get; set; }

    public virtual FlagType FlagType { get; set; }

    public virtual Post Post { get; set; }

    public virtual Post DuplicateOfQuestion { get; set; }
  }
}

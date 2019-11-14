using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class PostNotice
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public int? PostNoticeTypeId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public DateTime? ExpiryDate { get; set; }

    [StringLength(800)]
    public string Body { get; set; }

    public int? OwnerUserId { get; set; }
    public int? DeletionUserId { get; set; }

    public virtual User DeletionUser { get; set; }
    public virtual User OwnerUser { get; set; }
    public virtual PostNoticeType PostNoticeType { get; set; }
  }
}

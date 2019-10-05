using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class PostNoticeType
  {
    public PostNoticeType()
    {
      PostNotices = new HashSet<PostNotice>();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public byte ClassId { get; set; }

    [StringLength(80)]
    public string Name { get; set; }

    [StringLength(800)]
    public string Body { get; set; }

    public bool IsHidden { get; set; }

    public bool Predefined { get; set; }

    public int PostNoticeDurationId { get; set; }

    public virtual ICollection<PostNotice> PostNotices { get; set; }
  }
}

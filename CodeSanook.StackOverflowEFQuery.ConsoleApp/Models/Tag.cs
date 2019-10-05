using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class Tag
  {
    public Tag()
    {
      PostTags = new List<PostTag>();
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [StringLength(35)]
    public string TagName { get; set; }

    public int Count { get; set; }

    public int? ExcerptPostId { get; set; }
    public int? WikiPostId { get; set; }

    public virtual Post ExcerptPost { get; set; }
    public virtual Post WikiPost { get; set; }

    public virtual ICollection<PostTag> PostTags { get; set; }
  }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class Badge
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public DateTime Date { get; set; }
    public byte Class { get; set; }
    public bool TagBased { get; set; }
    public virtual User User { get; set; }
  }
}

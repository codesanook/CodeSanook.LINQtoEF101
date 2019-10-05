namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostHistory")]
    public partial class PostHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public byte PostHistoryTypeId { get; set; }

        public int PostId { get; set; }

        public Guid RevisionGUID { get; set; }

        public DateTime CreationDate { get; set; }

        public int? UserId { get; set; }

        [StringLength(40)]
        public string UserDisplayName { get; set; }

        [StringLength(400)]
        public string Comment { get; set; }

        [StringLength(800)]
        public string Text { get; set; }

        public virtual PostHistoryType PostHistoryType { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}

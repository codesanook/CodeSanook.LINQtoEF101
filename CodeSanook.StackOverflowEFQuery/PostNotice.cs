namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostNotice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int PostId { get; set; }

        public int? PostNoticeTypeId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [StringLength(800)]
        public string Body { get; set; }

        public int? OwnerUserId { get; set; }

        public int? DeletionUserId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual Post Post { get; set; }

        public virtual PostNoticeType PostNoticeType { get; set; }
    }
}

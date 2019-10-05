namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostFeedback")]
    public partial class PostFeedback
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

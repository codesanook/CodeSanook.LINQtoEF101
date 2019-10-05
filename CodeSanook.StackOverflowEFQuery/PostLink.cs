namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostLink
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public int PostId { get; set; }

        public int RelatedPostId { get; set; }

        public byte LinkTypeId { get; set; }

        public virtual Post Post { get; set; }

        public virtual Post Post1 { get; set; }
    }
}

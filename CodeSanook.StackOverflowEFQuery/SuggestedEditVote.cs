namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SuggestedEditVote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int SuggestedEditId { get; set; }

        public int UserId { get; set; }

        public byte VoteTypeId { get; set; }

        public DateTime CreationDate { get; set; }

        public int? TargetUserId { get; set; }

        public int TargetRepChange { get; set; }

        public virtual SuggestedEdit SuggestedEdit { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual VoteType VoteType { get; set; }
    }
}

namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostsWithDeleted")]
    public partial class PostsWithDeleted
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public byte PostTypeId { get; set; }

        public int? AcceptedAnswerId { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public int Score { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(800)]
        public string Body { get; set; }

        public int? OwnerUserId { get; set; }

        [StringLength(40)]
        public string OwnerDisplayName { get; set; }

        public int? LastEditorUserId { get; set; }

        [StringLength(40)]
        public string LastEditorDisplayName { get; set; }

        public DateTime? LastEditDate { get; set; }

        public DateTime? LastActivityDate { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Tags { get; set; }

        public int? AnswerCount { get; set; }

        public int? CommentCount { get; set; }

        public int? FavoriteCount { get; set; }

        public DateTime? ClosedDate { get; set; }

        public DateTime? CommunityOwnedDate { get; set; }

        public virtual Post Post { get; set; }

        public virtual Post Post1 { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual PostType PostType { get; set; }
    }
}

namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Comments = new HashSet<Comment>();
            PendingFlags = new HashSet<PendingFlag>();
            PendingFlags1 = new HashSet<PendingFlag>();
            PostFeedbacks = new HashSet<PostFeedback>();
            PostHistories = new HashSet<PostHistory>();
            PostLinks = new HashSet<PostLink>();
            PostLinks1 = new HashSet<PostLink>();
            PostNotices = new HashSet<PostNotice>();
            Posts1 = new HashSet<Post>();
            Posts11 = new HashSet<Post>();
            PostsWithDeleteds = new HashSet<PostsWithDeleted>();
            PostsWithDeleteds1 = new HashSet<PostsWithDeleted>();
            ReviewTasks = new HashSet<ReviewTask>();
            SuggestedEdits = new HashSet<SuggestedEdit>();
            Tags1 = new HashSet<Tag>();
            Tags2 = new HashSet<Tag>();
            Votes = new HashSet<Vote>();
            Tags3 = new HashSet<Tag>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PendingFlag> PendingFlags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PendingFlag> PendingFlags1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostFeedback> PostFeedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostHistory> PostHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostLink> PostLinks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostLink> PostLinks1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostNotice> PostNotices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts1 { get; set; }

        public virtual Post Post1 { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts11 { get; set; }

        public virtual Post Post2 { get; set; }

        public virtual PostType PostType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostsWithDeleted> PostsWithDeleteds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostsWithDeleted> PostsWithDeleteds1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewTask> ReviewTasks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestedEdit> SuggestedEdits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote> Votes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags3 { get; set; }
    }
}

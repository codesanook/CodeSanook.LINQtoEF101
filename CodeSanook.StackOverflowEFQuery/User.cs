namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Badges = new HashSet<Badge>();
            CloseAsOffTopicReasonTypes = new HashSet<CloseAsOffTopicReasonType>();
            CloseAsOffTopicReasonTypes1 = new HashSet<CloseAsOffTopicReasonType>();
            CloseAsOffTopicReasonTypes2 = new HashSet<CloseAsOffTopicReasonType>();
            Comments = new HashSet<Comment>();
            PostHistories = new HashSet<PostHistory>();
            PostNotices = new HashSet<PostNotice>();
            PostNotices1 = new HashSet<PostNotice>();
            Posts = new HashSet<Post>();
            Posts1 = new HashSet<Post>();
            PostsWithDeleteds = new HashSet<PostsWithDeleted>();
            PostsWithDeleteds1 = new HashSet<PostsWithDeleted>();
            SuggestedEdits = new HashSet<SuggestedEdit>();
            SuggestedEditVotes = new HashSet<SuggestedEditVote>();
            SuggestedEditVotes1 = new HashSet<SuggestedEditVote>();
            TagSynonyms = new HashSet<TagSynonym>();
            TagSynonyms1 = new HashSet<TagSynonym>();
            Votes = new HashSet<Vote>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int Reputation { get; set; }

        public DateTime CreationDate { get; set; }

        [StringLength(40)]
        public string DisplayName { get; set; }

        public DateTime LastAccessDate { get; set; }

        [StringLength(200)]
        public string WebsiteUrl { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(800)]
        public string AboutMe { get; set; }

        public int Views { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        [StringLength(200)]
        public string ProfileImageUrl { get; set; }

        [StringLength(32)]
        public string EmailHash { get; set; }

        public int? AccountId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Badge> Badges { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypes2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostHistory> PostHistories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostNotice> PostNotices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostNotice> PostNotices1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostsWithDeleted> PostsWithDeleteds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostsWithDeleted> PostsWithDeleteds1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestedEdit> SuggestedEdits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestedEditVote> SuggestedEditVotes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuggestedEditVote> SuggestedEditVotes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TagSynonym> TagSynonyms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TagSynonym> TagSynonyms1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote> Votes { get; set; }
    }
}

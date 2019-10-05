namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StackOverflowDbContext : DbContext
    {
        public StackOverflowDbContext()
            : base("name=StackOverflowDbContext")
        {
        }

        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypes { get; set; }
        public virtual DbSet<CloseReasonType> CloseReasonTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FlagType> FlagTypes { get; set; }
        public virtual DbSet<PendingFlag> PendingFlags { get; set; }
        public virtual DbSet<PostFeedback> PostFeedbacks { get; set; }
        public virtual DbSet<PostHistory> PostHistories { get; set; }
        public virtual DbSet<PostHistoryType> PostHistoryTypes { get; set; }
        public virtual DbSet<PostLink> PostLinks { get; set; }
        public virtual DbSet<PostNotice> PostNotices { get; set; }
        public virtual DbSet<PostNoticeType> PostNoticeTypes { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostsWithDeleted> PostsWithDeleteds { get; set; }
        public virtual DbSet<PostType> PostTypes { get; set; }
        public virtual DbSet<ReviewRejectionReason> ReviewRejectionReasons { get; set; }
        public virtual DbSet<ReviewTaskResult> ReviewTaskResults { get; set; }
        public virtual DbSet<ReviewTaskResultType> ReviewTaskResultTypes { get; set; }
        public virtual DbSet<ReviewTask> ReviewTasks { get; set; }
        public virtual DbSet<ReviewTaskState> ReviewTaskStates { get; set; }
        public virtual DbSet<ReviewTaskType> ReviewTaskTypes { get; set; }
        public virtual DbSet<SuggestedEdit> SuggestedEdits { get; set; }
        public virtual DbSet<SuggestedEditVote> SuggestedEditVotes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagSynonym> TagSynonyms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteType> VoteTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlagType>()
                .HasMany(e => e.PendingFlags)
                .WithRequired(e => e.FlagType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostHistoryType>()
                .HasMany(e => e.PostHistories)
                .WithRequired(e => e.PostHistoryType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PendingFlags)
                .WithOptional(e => e.Post)
                .HasForeignKey(e => e.DuplicateOfQuestionId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PendingFlags1)
                .WithRequired(e => e.Post1)
                .HasForeignKey(e => e.PostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostFeedbacks)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostHistories)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostLinks)
                .WithRequired(e => e.Post)
                .HasForeignKey(e => e.PostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostLinks1)
                .WithRequired(e => e.Post1)
                .HasForeignKey(e => e.RelatedPostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostNotices)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Posts1)
                .WithOptional(e => e.Post1)
                .HasForeignKey(e => e.AcceptedAnswerId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Posts11)
                .WithOptional(e => e.Post2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostsWithDeleteds)
                .WithOptional(e => e.Post)
                .HasForeignKey(e => e.AcceptedAnswerId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostsWithDeleteds1)
                .WithOptional(e => e.Post1)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.ReviewTasks)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.SuggestedEdits)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags1)
                .WithOptional(e => e.Post)
                .HasForeignKey(e => e.ExcerptPostId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags2)
                .WithOptional(e => e.Post1)
                .HasForeignKey(e => e.WikiPostId);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Votes)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags3)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("PostTags").MapLeftKey("PostId").MapRightKey("TagId"));

            modelBuilder.Entity<PostType>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.PostType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PostType>()
                .HasMany(e => e.PostsWithDeleteds)
                .WithRequired(e => e.PostType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReviewRejectionReason>()
                .HasMany(e => e.ReviewTaskResults)
                .WithOptional(e => e.ReviewRejectionReason)
                .HasForeignKey(e => e.RejectionReasonId);

            modelBuilder.Entity<ReviewTaskResult>()
                .HasMany(e => e.ReviewTasks)
                .WithOptional(e => e.ReviewTaskResult)
                .HasForeignKey(e => e.CompletedByReviewTaskId);

            modelBuilder.Entity<ReviewTaskResultType>()
                .HasMany(e => e.ReviewTaskResults)
                .WithRequired(e => e.ReviewTaskResultType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReviewTask>()
                .HasMany(e => e.ReviewTaskResults)
                .WithRequired(e => e.ReviewTask)
                .HasForeignKey(e => e.ReviewTaskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReviewTaskState>()
                .HasMany(e => e.ReviewTasks)
                .WithRequired(e => e.ReviewTaskState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReviewTaskType>()
                .HasMany(e => e.ReviewTasks)
                .WithRequired(e => e.ReviewTaskType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SuggestedEdit>()
                .HasMany(e => e.SuggestedEditVotes)
                .WithRequired(e => e.SuggestedEdit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailHash)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Badges)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CloseAsOffTopicReasonTypes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ApprovalModeratorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CloseAsOffTopicReasonTypes1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.CreationModeratorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CloseAsOffTopicReasonTypes2)
                .WithOptional(e => e.User2)
                .HasForeignKey(e => e.DeactivationModeratorId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PostNotices)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.DeletionUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PostNotices1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.LastEditorUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PostsWithDeleteds)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.LastEditorUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PostsWithDeleteds1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SuggestedEdits)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SuggestedEditVotes)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.TargetUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SuggestedEditVotes1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TagSynonyms)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ApprovedByUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.TagSynonyms1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.OwnerUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VoteType>()
                .HasMany(e => e.PostFeedbacks)
                .WithRequired(e => e.VoteType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VoteType>()
                .HasMany(e => e.SuggestedEditVotes)
                .WithRequired(e => e.VoteType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VoteType>()
                .HasMany(e => e.Votes)
                .WithRequired(e => e.VoteType)
                .WillCascadeOnDelete(false);
        }
    }
}

using Codesanook.StackOverflowEFQuery.ConsoleApp.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Codesanook.StackOverflowEFQuery.ConsoleApp.Models
{
    public class StackOverflowDbContext : DbContext
    {
        private static ILoggerFactory loggerFactory;

        static StackOverflowDbContext() => loggerFactory = new LoggerFactory().AddLog4Net();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlServer(
                    @"data source=.\;initial catalog=StackOverflow;integrated security=True;",
                    c => c.UseRelationalNulls(true)
                );
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
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<TagSynonym> TagSynonyms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteType> VoteTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //https://www.learnentityframeworkcore.com/configuration/fluent-api/ondelete-method
            modelBuilder.Entity<FlagType>()
              .HasMany(e => e.PendingFlags)
              .WithOne(e => e.FlagType)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostHistoryType>()
              .HasMany(e => e.PostHistories)
              .WithOne(e => e.PostHistoryType)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.Comments)
              .WithOne(e => e.Post)
              .IsRequired()
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.PendingFlags)
              .WithOne(e => e.Post)
              .HasForeignKey(e => e.PostId);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.DuplicatedOfQuestions)
              .WithOne(e => e.DuplicateOfQuestion)
              .HasForeignKey(e => e.DuplicateOfQuestionId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.PostFeedbacks)
              .WithOne(e => e.Post)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.PostHistories)
              .WithOne(e => e.Post)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.PostLinks)
              .WithOne(e => e.Post)
              .HasForeignKey(e => e.PostId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.RelatePosts)
              .WithOne(e => e.RelatedPost)
              .HasForeignKey(e => e.RelatedPostId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.PostNotices)
              .WithOne(e => e.Post)
              .OnDelete(DeleteBehavior.NoAction);

            //many to one
            modelBuilder.Entity<Post>()
              .HasMany(e => e.Posts)
              .WithOne(e => e.Parent)
              .HasForeignKey(e => e.ParentId);

            //one to many
            modelBuilder.Entity<Post>()
              .HasOne(e => e.Parent)
              .WithMany(e => e.Posts)
              .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.AcceptedAnswerPostsWithDeleteds)
              .WithOne(e => e.AcceptedAnswer)
              .HasForeignKey(e => e.AcceptedAnswerId);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.ParentsPostsWithDeleteds)
              .WithOne(e => e.Parent)
              .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.ReviewTasks)
              .WithOne(e => e.Post)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.SuggestedEdits)
              .WithOne(e => e.Post)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.ExcerptPostTags)
              .WithOne(e => e.ExcerptPost)
              .HasForeignKey(e => e.ExcerptPostId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.WikiPostTags)
              .WithOne(e => e.WikiPost)
              .HasForeignKey(e => e.WikiPostId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Post>()
              .HasMany(e => e.Votes)
              .WithOne(e => e.Post)
              .OnDelete(DeleteBehavior.NoAction);

            //join to PostTag
            modelBuilder.Entity<PostTag>()
               .HasKey(pt => new { pt.PostId, pt.TagId });

            //relation to post
            modelBuilder.Entity<PostTag>()
              .HasOne(pt => pt.Post)
              .WithMany(p => p.PostTags)
              .HasForeignKey(pt => pt.PostId);

            //relation to tag
            modelBuilder.Entity<PostTag>()
              .HasOne(pt => pt.Tag)
              .WithMany(t => t.PostTags)
              .HasForeignKey(pt => pt.TagId);

            // The EF Team are planning on removing the need for a join entity at some point. The issue can be tracked at GitHub and also here. 
            // Currently, there doesn't appear to be any plan to include this before at least EF Core 3.0.

            modelBuilder.Entity<PostType>()
              .HasMany(e => e.Posts)
              .WithOne(e => e.PostType)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PostType>()
              .HasMany(e => e.PostsWithDeleteds)
              .WithOne(e => e.PostType)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReviewRejectionReason>()
              .HasMany(e => e.ReviewTaskResults)
              .WithOne(e => e.ReviewRejectionReason)
              .HasForeignKey(e => e.RejectionReasonId);

            modelBuilder.Entity<ReviewTaskResult>()
              .HasMany(e => e.ReviewTasks)
              .WithOne(e => e.ReviewTaskResult)
              .HasForeignKey(e => e.CompletedByReviewTaskId);

            modelBuilder.Entity<ReviewTaskResultType>()
              .HasMany(e => e.ReviewTaskResults)
              .WithOne(e => e.ReviewTaskResultType)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReviewTask>()
              .HasMany(e => e.ReviewTaskResults)
              .WithOne(e => e.ReviewTask)
              .HasForeignKey(e => e.ReviewTaskId)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReviewTaskState>()
              .HasMany(e => e.ReviewTasks)
              .WithOne(e => e.ReviewTaskState)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ReviewTaskType>()
              .HasMany(e => e.ReviewTasks)
              .WithOne(e => e.ReviewTaskType)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SuggestedEdit>()
              .HasMany(e => e.SuggestedEditVotes)
              .WithOne(e => e.SuggestedEdit)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
              .Property(e => e.EmailHash)
              .IsUnicode(false);

            modelBuilder.Entity<User>()
              .HasMany(e => e.Badges)
              .WithOne(e => e.User)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
              .HasMany(e => e.CloseAsOffTopicReasonTypesByApprovalModerator)
              .WithOne(e => e.ApprovalModerator)
              .HasForeignKey(e => e.ApprovalModeratorId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.CloseAsOffTopicReasonTypesByCreationModerator)
              .WithOne(e => e.CreationModerator)
              .HasForeignKey(e => e.CreationModeratorId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.CloseAsOffTopicReasonTypesDeactivationModerator)
              .WithOne(e => e.DeactivationModerator)
              .HasForeignKey(e => e.DeactivationModeratorId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.DeletionUserPostNotices)
              .WithOne(e => e.DeletionUser)
              .HasForeignKey(e => e.DeletionUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.OwnerUserPostNotices)
              .WithOne(e => e.OwnerUser)
              .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.OwnerUserPosts)
              .WithOne(e => e.OwnerUser)
              .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.LastEditorUserPosts)
              .WithOne(e => e.LastEditorUser)
              .HasForeignKey(e => e.LastEditorUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.OwnerUserPostsWithDeleteds)
              .WithOne(e => e.OwnerUser)
              .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.LastEditorUserPostsWithDeleteds)
              .WithOne(e => e.LastEditorUser)
              .HasForeignKey(e => e.LastEditorUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.SuggestedEdits)
              .WithOne(e => e.User)
              .HasForeignKey(e => e.OwnerUserId);

            modelBuilder.Entity<User>()
              .HasMany(e => e.UserSuggestedEditVotes)
              .WithOne(e => e.User)
              .HasForeignKey(e => e.UserId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
              .HasMany(e => e.TargetUserSuggestedEditVotes)
              .WithOne(e => e.TargetUser)
              .HasForeignKey(e => e.TargetUserId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
              .HasMany(e => e.OnwerUserTagSynonyms)
              .WithOne(e => e.OwnerUser)
              .HasForeignKey(e => e.OwnerUserId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
              .HasMany(e => e.ApprovedByUserTagSynonyms)
              .WithOne(e => e.ApprovedByUser)
              .HasForeignKey(e => e.ApprovedByUserId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VoteType>()
              .HasMany(e => e.PostFeedbacks)
              .WithOne(e => e.VoteType)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VoteType>()
              .HasMany(e => e.SuggestedEditVotes)
              .WithOne(e => e.VoteType)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VoteType>()
              .HasMany(e => e.Votes)
              .WithOne(e => e.VoteType)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

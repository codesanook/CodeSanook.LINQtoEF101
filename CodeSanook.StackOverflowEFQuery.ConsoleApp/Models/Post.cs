using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class Post
  {
    public Post()
    {
      Comments = new HashSet<Comment>();
      PendingFlags = new HashSet<PendingFlag>();
      DuplicatedOfQuestions = new HashSet<PendingFlag>();
      PostFeedbacks = new HashSet<PostFeedback>();
      PostHistories = new HashSet<PostHistory>();
      PostLinks = new HashSet<PostLink>();
      RelatePosts = new HashSet<PostLink>();
      PostNotices = new HashSet<PostNotice>();
      AcceptedAnswerPostsWithDeleteds = new HashSet<PostsWithDeleted>();
      ParentsPostsWithDeleteds = new HashSet<PostsWithDeleted>();
      ReviewTasks = new HashSet<ReviewTask>();
      SuggestedEdits = new HashSet<SuggestedEdit>();
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
    public virtual ICollection<Comment> Comments { get; set; }

    public virtual ICollection<PendingFlag> PendingFlags { get; set; }
    public virtual ICollection<PendingFlag> DuplicatedOfQuestions { get; set; }
    public virtual ICollection<PostFeedback> PostFeedbacks { get; set; }
    public virtual ICollection<PostHistory> PostHistories { get; set; }
    public virtual ICollection<PostLink> PostLinks { get; set; }
    public virtual ICollection<PostLink> RelatePosts { get; set; }
    public virtual ICollection<PostNotice> PostNotices { get; set; }

    public virtual User OwnerUser { get; set; }
    public virtual User LastEditorUser { get; set; }

    public virtual Post Parent { get; set; }
    public virtual ICollection<Post> Posts { get; set; }

    public virtual PostType PostType { get; set; }

    public virtual ICollection<PostsWithDeleted> AcceptedAnswerPostsWithDeleteds { get; set; }
    public virtual ICollection<PostsWithDeleted> ParentsPostsWithDeleteds { get; set; }

    public virtual ICollection<ReviewTask> ReviewTasks { get; set; }
    public virtual ICollection<SuggestedEdit> SuggestedEdits { get; set; }
    public virtual ICollection<Vote> Votes { get; set; }
    public virtual ICollection<PostTag> PostTags { get; set; }

    public virtual ICollection<Tag> ExcerptPostTags { get; set; }
    public virtual ICollection<Tag> WikiPostTags { get; set; }
  }
}

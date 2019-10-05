using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp.Models
{
  public class User
  {
    public User()
    {
      Badges = new HashSet<Badge>();
      CloseAsOffTopicReasonTypesByCreationModerator = new HashSet<CloseAsOffTopicReasonType>();
      CloseAsOffTopicReasonTypesByApprovalModerator = new HashSet<CloseAsOffTopicReasonType>();
      CloseAsOffTopicReasonTypesDeactivationModerator = new HashSet<CloseAsOffTopicReasonType>();
      Comments = new HashSet<Comment>();
      PostHistories = new HashSet<PostHistory>();
      OwnerUserPostNotices = new HashSet<PostNotice>();
      DeletionUserPostNotices = new HashSet<PostNotice>();
      OwnerUserPosts = new HashSet<Post>();
      LastEditorUserPosts = new HashSet<Post>();
      OwnerUserPostsWithDeleteds = new HashSet<PostsWithDeleted>();
      LastEditorUserPostsWithDeleteds = new HashSet<PostsWithDeleted>();
      SuggestedEdits = new HashSet<SuggestedEdit>();
      UserSuggestedEditVotes = new HashSet<SuggestedEditVote>();
      TargetUserSuggestedEditVotes = new HashSet<SuggestedEditVote>();
      OnwerUserTagSynonyms = new HashSet<TagSynonym>();
      ApprovedByUserTagSynonyms = new HashSet<TagSynonym>();
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

    public virtual ICollection<Badge> Badges { get; set; }

    public virtual ICollection<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypesByCreationModerator { get; set; }
    public virtual ICollection<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypesByApprovalModerator { get; set; }
    public virtual ICollection<CloseAsOffTopicReasonType> CloseAsOffTopicReasonTypesDeactivationModerator { get; set; }

    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<PostHistory> PostHistories { get; set; }

    public virtual ICollection<PostNotice> DeletionUserPostNotices { get; set; }
    public virtual ICollection<PostNotice> OwnerUserPostNotices { get; set; }

    public virtual ICollection<Post> OwnerUserPosts { get; set; }
    public virtual ICollection<Post> LastEditorUserPosts { get; set; }

    public virtual ICollection<PostsWithDeleted> OwnerUserPostsWithDeleteds { get; set; }
    public virtual ICollection<PostsWithDeleted> LastEditorUserPostsWithDeleteds { get; set; }

    public virtual ICollection<SuggestedEdit> SuggestedEdits { get; set; }
    public virtual ICollection<SuggestedEditVote> UserSuggestedEditVotes { get; set; }
    public virtual ICollection<SuggestedEditVote> TargetUserSuggestedEditVotes { get; set; }

    public virtual ICollection<TagSynonym> OnwerUserTagSynonyms { get; set; }
    public virtual ICollection<TagSynonym> ApprovedByUserTagSynonyms { get; set; }
    public virtual ICollection<Vote> Votes { get; set; }
  }
}

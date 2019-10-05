namespace CodeSanook.StackOverflowEFQuery
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PostNoticeType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostNoticeType()
        {
            PostNotices = new HashSet<PostNotice>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public byte ClassId { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(800)]
        public string Body { get; set; }

        public bool IsHidden { get; set; }

        public bool Predefined { get; set; }

        public int PostNoticeDurationId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostNotice> PostNotices { get; set; }
    }
}

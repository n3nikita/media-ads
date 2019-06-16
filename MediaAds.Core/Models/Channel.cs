
using System.ComponentModel.DataAnnotations;

namespace MediaAds.Core.Models
{
    public class Channel : BaseModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required, MaxLength(50)]
        public string Link { get; set; }
        public int Subscribers { get; set; }
        public int Views { get; set; }
        public int ERR { get; set; }
        public string Image { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? PlatformId { get; set; }
        public virtual Platform Platform { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}

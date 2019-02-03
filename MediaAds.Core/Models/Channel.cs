
namespace MediaAds.Core.Models
{
    public class Channel : BaseModel
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public int Subscribers { get; set; }
        public int Views { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}

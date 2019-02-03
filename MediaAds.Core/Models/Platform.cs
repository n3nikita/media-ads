namespace MediaAds.Core.Models
{
    public class Platform : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Users { get; set; }
    }
}

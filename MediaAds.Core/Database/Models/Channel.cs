using System;
using System.Collections.Generic;
using System.Text;

namespace MediaAds.Core.Database.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int Subscribers { get; set; }
        public int Views { get; set; }
        public string Image { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}

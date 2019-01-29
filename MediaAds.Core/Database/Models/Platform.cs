using System;
using System.Collections.Generic;
using System.Text;

namespace MediaAds.Core.Database.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Users { get; set; }
    }
}

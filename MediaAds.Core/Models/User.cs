using System;
using System.Collections.Generic;
using System.Text;

namespace MediaAds.Core.Models
{
    public class User : BaseModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Link { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediaAds.Core.Models
{
    public class Role : BaseModel
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}

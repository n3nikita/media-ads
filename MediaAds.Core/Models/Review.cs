using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MediaAds.Core.Models
{
    public class Review : BaseModel
    {
        public string Text { get; set; }
        [Required, Range(1d,5d)]
        public double Rating { get; set; }
        public DateTime Date { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}

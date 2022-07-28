using System;
using System.Collections.Generic;

namespace MyTunes.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        
        public int SongId { get; set; }
        public Song Song { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }

        public Rating()
        {
            Rate= 0;
            CreatedAt = DateTime.Now;
        }
        
        public Rating(int rate, int songId, int userId)
        {
            Rate = rate;
            SongId = songId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }
        
    }
}

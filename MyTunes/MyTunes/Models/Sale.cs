using System;
using System.Collections.Generic;

namespace MyTunes.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int SongId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public virtual Song Song { get; set; }
        public virtual User User { get; set; }
        
        public Sale()
        {
            Date = DateTime.Now;
        }
        
        public Sale(int songId, int userId)
        {
            SongId = songId;
            UserId = userId;
            Date = DateTime.Now;
        }
    }
}
using System;

namespace MyTunes.Models
{
    public class Artist
    {
        public int Id { get;set; }

       public string Name { get;set; }
       
       public int Sales { get; set; }
       public int RatingCount { get; set; }

       public Artist()
       {
       }
       
       public Artist(string name)
       {
           Name = name;
           Sales = 0;
            RatingCount = 0;
       }
    }
}

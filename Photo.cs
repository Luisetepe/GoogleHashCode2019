using System;
using System.Collections.Generic;

namespace SlideShow.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public bool Vertical { get; set; }
        public List<string> tags { get; set; }
    }
}
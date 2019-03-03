using System;
using System.Collections.Generic;

namespace SlideShow.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public int NumTags { get; set; }
        public List<string> Tags { get; set; }
        public List<Photo> photos { get; set; }
    }
}
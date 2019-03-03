using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SlideShow.Models
{
    public class Slideshow
    {
        public List<Slide> Slides { get; set; }

        public void GenerateResultFile(string fileName)
        {
            StringBuilder stringResult = new StringBuilder();
            stringResult.AppendLine(this.Slides.Count.ToString());
            foreach(var slide in this.Slides)
            {
                foreach(var photo in slide.photos)
                {
                    stringResult.Append($"{photo.Id} ");

                }
                stringResult.AppendLine();
            }

            File.WriteAllText(fileName, stringResult.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SlideShow.Models;
using SlideShow.Utils;

namespace GoogleHashCode2019
{
    class Program
    {

        public static List<Photo> photoList;
        public static List<Slide> slides;

        static void Main(string[] args)
        {
            photoList = FileLoader.LoadFile(args[0]);
            slides = GetVerticalSlides();
            int currentId = 0;
            if(slides != null && slides.Count != 0)
            {
                currentId = slides.Max(x => x.Id);
            }
            var horizontalList = photoList.Where(x => !x.Vertical).Select(y => 
            {
                currentId++;
                return new Slide()
                {
                    Id = currentId,
                    NumTags = y.tags.Count,
                    Tags = y.tags,
                    photos = new List<Photo>(){ y }
                };
            }).OrderByDescending(z => z.NumTags).ToList();

            //slides = slides.OrderByDescending(x => x.NumTags).ToList();

            //calculateMinMatrix();

            Slideshow result = new Slideshow()
            {
                Slides = slides
            };

            result.GenerateResultFile(args[1]);
            //int score = GetScore();
            //Console.WriteLine($"La puntuacion es: {score}");
        }

        private static int GetScore()
        {
            int tempScore = 0;
            int iterator = 1;
            List<string> tempTags = null;

            foreach(var slide in slides)
            {
                if(iterator % 2 == 0)
                {
                    tempScore += GetMin(tempTags,slide.Tags);
                }
                tempTags = slide.Tags;
                iterator++;
            }

            return tempScore;
        }

        private static int GetMin(List<string> tags1, List<string> tags2)
        {

            List<string> sharedTags = new List<String>(tags1);
            sharedTags.AddRange(tags2);
            //sharedTags..ToList();

            int slide1UniqueTags = tags1.Count - sharedTags.Count;
            int slidesSharedTags = sharedTags.Count;
            int slide2UniqueTags = tags2.Count - sharedTags.Count;

            return Math.Min(slide1UniqueTags, Math.Min(slidesSharedTags,slide2UniqueTags));
        }

        private static void calculateMinMatrix()
        {
            foreach(var slide in slides)
            {

            }
        }

        private static List<Slide> GetVerticalSlides()
        {
            int idCounter = 1;

            List<Slide> listresult = new List<Slide>();
            List<Photo> verticalPhotosOrderDesc = photoList.Where(x => x.Vertical == true)?.OrderByDescending(y => y.tags.Count)?.ToList();
            if(verticalPhotosOrderDesc == null || verticalPhotosOrderDesc.Count == 0)
            {
                return listresult;
            }

            for (int i = 0; i < verticalPhotosOrderDesc.Count/2; i++)
            {
                List<string> tempTags = new List<string>(verticalPhotosOrderDesc[i].tags);
                tempTags.AddRange(verticalPhotosOrderDesc[verticalPhotosOrderDesc.Count - (1 + i)].tags);

                listresult.Add(new Slide(){
                    Id = idCounter,
                    Tags = tempTags.Distinct().ToList(),
                    NumTags = tempTags.Distinct().Count(),
                    photos = new List<Photo>(){
                        verticalPhotosOrderDesc[i],
                        verticalPhotosOrderDesc[verticalPhotosOrderDesc.Count - (1 + i)]
                    }
                });

                idCounter++;
            }

            return listresult;
        }
    }
}

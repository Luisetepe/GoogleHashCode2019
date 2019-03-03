using System;
using System.Collections.Generic;
using System.IO;
using SlideShow.Models;

namespace SlideShow.Utils
{
    public static class FileLoader
    {
        public static List<Photo> LoadFile(string path)
        {
            int idCounter = 0;
            var photoList = new List<Photo>();
            string line = string.Empty;
            List<string> tempTags = null;
            StreamReader file = new System.IO.StreamReader(path);
            file.ReadLine();
            while((line = file.ReadLine()) != null)  
            {  
                string[] tempInfo = line.Split(" ");
                int numTags = int.Parse(tempInfo[1]);
                tempTags = new List<string>();
                for (int i = 0; i < numTags; i++)
                {
                    tempTags.Add(tempInfo[2+i]);
                }

                photoList.Add(new Photo(){
                    Id = idCounter,
                    Vertical = tempInfo[0] == "V",
                    tags = tempTags
                });
                idCounter++;
            }

            return photoList;
        }
    }
}
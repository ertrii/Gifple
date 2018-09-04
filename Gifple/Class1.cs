using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gifple
{
    public class Gifple
    {                
        public Gifple(string name)
        {
            this.name = name;
        }

        private String name;
        public string Autor = "Anonymous";
        private string description = null;
        public bool Repeat = true;

        private IMGFileGifple[] imageFiles;

        public IMGFileGifple[] ImageFiles
        {
            set
            {
                imageFiles = value;
            }

        }
        
        public String Description
        {
            set
            {
                description = value;
            }
        }

        private List<Object> prepareJson()
        {
            //config.json
            JObject jConfig = new JObject();
            jConfig["proyectName"] = name;
            jConfig["autor"] = Autor;
            jConfig["description"] = description;
            jConfig["date"] = DateTime.Now;
            jConfig["repeat"] = Repeat;

            //images.json
            int index = 0;
            JArray jImages = new JArray();
            foreach (IMGFileGifple img in imageFiles)
            {
                JObject jImage = new JObject();
                jImage["index"] = index;
                jImage["src"] = img.Path;
                jImage["delay"] = img.Delay;
                JObject vector = new JObject();
                vector["x"] = img.X;
                vector["y"] = img.Y;
                jImage["vector"] = vector;
                jImages.Add(jImage);
                index++;
            }
            List<Object> jFiles = new List<Object>() { jConfig, jImages};
            return jFiles;
        }
        /// <summary>
        /// Generate sequence images.png in HTML file.
        /// </summary>
        /// <returns></returns>
        public bool Generate(String outputPath)
        {            
            if (imageFiles.Length < 1) return false;
            List<Object> jsonFile = prepareJson();
            File.WriteAllText("config.json", jsonFile[0].ToString());
            File.WriteAllText("images.json", jsonFile[1].ToString());
            return true;
        }

    }

    public class IMGFileGifple
    {
        public String Path;
        private int delay = 60;
        public int X;
        public int Y;

        public int Delay
        {
            set
            {
                if (value >= 0) delay = value;
                else throw new ArgumentOutOfRangeException();
            }
            get
            {
                return delay;
            }
        }
        public void Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

using System;
using System.Collections.Generic;
/*using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.IO;
using System.Web.Script.Serialization;

namespace Gifple
{
    class Vector
    {
        public int x { get; set; }
        public int y { get; set; }
    }
    class GifpleImage
    {        
        public GifpleImage(int index)
        {
            this.index = index;
        }
        public int index { get; set; }
        public string src { get; set; }
        public int delay { get; set; }
        public Vector vector { get; } = new Vector();
    }
    class GifpleConfig
    {
        public string name { get; set; }
        public string autor { get; set; }
        public string description { get; set; }
        public string date { get; set; }
        public bool repeat { get; set; }
    }
    public class GifpleGenerate
    {
        
        public string Name { get; set; }
        public string Autor { get; set; } = "Anonymous";
        public string Description { get; set; } = "";
        public bool Repeat { get; set; } = true;
        public IMGFileGifple[] ImageFiles { get; set; }

        private List<string> prepareJson()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //config.json
            GifpleConfig jConfig = new GifpleConfig()
            {
                name = Name,
                autor = Autor,
                description = Description,
                date = DateTime.Today.ToString(),
                repeat = Repeat
            };

            //images.json
            int index = 0;
            List<GifpleImage> jImage = new List<GifpleImage> { };
            foreach (IMGFileGifple img in ImageFiles)
            {
                GifpleImage gifpleImage = new GifpleImage(index)
                {
                    src = img.Path,
                    delay = img.Delay,
                };
                gifpleImage.vector.x = img.X;
                gifpleImage.vector.y = img.Y;
                jImage.Add(gifpleImage);
                index++;
            }
            List<string> jFiles = new List<string>() {
                ser.Serialize(jConfig),
                ser.Serialize(jImage)
            };
            return jFiles;
        }
        /// <summary>
        /// Generate sequence images.png in HTML file.
        /// </summary>
        /// <returns></returns>
        public bool Generate(String outputPath = "")
        {            
            if (ImageFiles.Length < 1) return false;
            List<string> jsonFile = prepareJson();
            File.WriteAllText(outputPath + "config.json", jsonFile[0]);
            File.WriteAllText(outputPath + "images.json", jsonFile[1]);
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

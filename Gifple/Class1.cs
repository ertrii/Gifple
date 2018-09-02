using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifple
{
    public class Gifple
    {
        private String name;
        private string description = null;
        private IMGFileGifple[] imageFiles;

        public Gifple(String name)
        {
            this.name = name;
        }

        public IMGFileGifple[] ImageFiles
        {
            set
            {
                imageFiles = value;
            }

        }
        public bool Repeat = true;
        public string Autor = "Anonymous";


        public String Description
        {
            set
            {
                description = value;
            }
        }


        /// <summary>
        /// Generate sequence images.png in HTML file.
        /// </summary>
        /// <returns></returns>
        public bool Generate(String outputPath)
        {
            if (imageFiles.Length < 1) return false;
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

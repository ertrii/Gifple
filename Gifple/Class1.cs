using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Drawing;

namespace Gifple
{
    class Template
    {
        public static string html { get; } = "<html lang='en'><head><title id='head-title' ></title><meta charset='utf-8'/><meta name = 'viewport' content='width=device-width, initial-scale=1.0'><link rel = 'stylesheet' href='style.css'></head><body><div class='container'><button class='btn-stop-animate' id='btn-stop-animate' title='stop animate'>∎</button><button class='btn-plane' id='btn-plane' title='plane visible'>✛</button><header id = 'canvas'><div class='plane' id='plane'><div class='x'></div><div class='y'></div></div><div class='gif' id='container-img-canvas'><img src = '' alt='img' id='img-canvas'></div></header><div class='main-container'><main class='main-content'><h1 class='proyect-name' id='proyect-name'></h1><p class='autor' id='autor'></p><p class='description' id='description'></p><div class='sequence' id='sequence'></div></main><footer><div class='credits'><p>Lorem ipsum dolor sit amet consectetur adipisicing elit.Quae minima, facilis inventore voluptatibus voluptatum corrupti? Corrupti quam eum repudiandae aspernatur velit nulla necessitatibus ex autem voluptates, ratione, laboriosam nam assumenda.</p></div></footer></div></div><script src = 'animate.js'></script></body></html>";
        public static string css { get; } = "header,header .plane{height:100vh;width:100%;display:flex}.autor,.description,.proyect-name,footer .credits{text-align:center}*{padding:0;margin:0;box-sizing:border-box}body{color:#424242;background-color:#FAFAFA;font-family:sans-serif}header{background-color:#424242;position:fixed;top:0;justify-content:center;align-items:center;overflow:hidden}header .gif{position:relative;z-index:100}header .plane{position:absolute;justify-content:center;align-items:center}header .plane .x,header .plane .y{position:absolute;background-color:#555}header .plane .x{width:100%;height:1px}header .plane .y{height:100vh;width:1px;bottom:0}.btn-plane,.btn-stop-animate{position:absolute;border-radius:50%;cursor:pointer;padding:7px 9px;border:none;z-index:100;background-color:#4682b4;color:#fff;bottom:25px}.autor,.sequence .images .content-property p strong{color:#4682b4}.btn-plane{right:25px}.btn-stop-animate{right:65px}.main-container{background-color:#FAFAFA;position:relative;z-index:10}.main-content{max-width:750px;margin:100vh auto 0;padding:35px 15px 0;min-height:100vh}.proyect-name{margin-top:15px}.autor{font-size:9pt;margin-bottom:25px;font-family:serif}.sequence{margin-top:75px;margin-bottom:75px}.sequence .images{display:flex;align-items:center;border-bottom:1px solid #ccc;margin-bottom:15px}.sequence .images .content-img{min-width:100px;padding:2px;min-height:100px;max-width:200px;max-height:200px;display:flex;justify-content:center;align-items:center;margin-right:15px}.sequence .images .content-img img{display:inline}.sequence .images .content-property p{font-size:10pt;margin-bottom:3px}footer{background-color:#424242;color:#ECECEC;font-size:11pt}footer .credits{padding:50px 0;width:100%;max-width:750px;margin:0 auto}";
        public static string js { get; set; } = "'use strict';let Sequences;(function(){const a=document.getElementById('canvas'),b=document.getElementById('plane');let c=0;a.onclick=()=>{1==c?(a.style.backgroundColor='#424242',b.children[0].style.backgroundColor='#555',b.children[1].style.backgroundColor='#555',c=0):(a.style.backgroundColor='#ccc',b.children[0].style.backgroundColor='#aaa',b.children[1].style.backgroundColor='#aaa',c=1)};const d=document.getElementById('btn-plane');let e=!0;d.onclick=function(){e?(b.style.visibility='hidden',e=!1):(b.style.visibility='visible',e=!0)};Sequences=class{constructor(g,h){this.el=document.getElementById(g),this.images=h,this.btnStopAnimate=document.getElementById('btn-stop-animate'),this.option={index:0,stop:!1,repeat:!0}}animate(){if(!this.option.stop){let g=this.images[this.option.index];if(document.getElementById('img-canvas').src=g.src,document.getElementById('container-img-canvas').style.transform=`translate(${g.vector.x}px, ${g.vector.y}px)`,this.option.index++,setTimeout(()=>this.animate(),g.delay),this.option.index>=this.images.length)if(this.option.repeat)this.option.index=0;else return this.option.index=0,this.option.stop=!0,void(this.btnStopAnimate.innerHTML='\u22B3')}}structure(g){let h=document.createElement('div');h.setAttribute('class','images');const i=document.createElement('div');i.setAttribute('class','content-img');const j=document.createElement('img');j.setAttribute('src',g.src),i.appendChild(j);const k=document.createElement('div');k.setAttribute('class','content-property');const l=document.createElement('p'),m=document.createElement('strong');m.appendChild(document.createTextNode(`#${g.index}`)),l.appendChild(m);const n=document.createElement('p'),o=document.createElement('strong');o.appendChild(document.createTextNode('Delay: ')),n.appendChild(o),n.appendChild(document.createTextNode(g.delay));const p=document.createElement('p'),q=document.createElement('strong');q.appendChild(document.createTextNode('x: ')),p.appendChild(q),p.appendChild(document.createTextNode(g.vector.x));const r=document.createElement('p'),s=document.createElement('strong');return s.appendChild(document.createTextNode('y: ')),r.appendChild(s),r.appendChild(document.createTextNode(g.vector.y)),k.appendChild(l),k.appendChild(n),k.appendChild(p),k.appendChild(r),h.appendChild(i),h.appendChild(k),h}start(){this.animate(),this.btnStopAnimate.onclick=()=>{this.option.stop?(this.option.stop=!1,this.btnStopAnimate.innerHTML='\u220E',this.animate()):(this.option.stop=!0,this.btnStopAnimate.innerHTML='\u22B3')};const g=document.createElement('div');this.images.forEach(h=>{g.appendChild(this.structure(h))}),this.el.appendChild(g)}}})();";
    }
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
                    src = $"img/{index}.png",
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
        private void saveBpm(string outputPath)
        {
            int index = 0;
            foreach (IMGFileGifple img in ImageFiles)
            {
                img.Bmp.Save($"{outputPath}img/{index}.png");
                index++;
            }
        }
        /// <summary>
        /// Generate sequence images.png in HTML file.
        /// </summary>
        /// <returns></returns>
        public bool Generate(string outputPath = "")
        {            
            if (ImageFiles.Length < 1) return false;
            //Bitmap img = new Bitmap(@"d:\");
            File.WriteAllText(outputPath + "index.html", Template.html);
            File.WriteAllText(outputPath + "style.css", Template.css);
            List<string> jsonFile = prepareJson();
            Template.js += $"const config = {jsonFile[0]};";
            Template.js += $"const img = {jsonFile[1]};";
            Template.js += "document.getElementById('head-title').innerHTML=config.name,document.getElementById('proyect-name').innerHTML=config.name,document.getElementById('autor').innerHTML=config.autor,document.getElementById('description').innerHTML=config.description;const sequence=new Sequences('sequence',img);sequence.option.repeat=config.repeat,sequence.start();";
            File.WriteAllText(outputPath + "animate.js", Template.js);

            if (Directory.Exists($"{outputPath}img"))
            {
                saveBpm(outputPath);
            }else
            {
                Directory.CreateDirectory($"{outputPath}img");
                saveBpm(outputPath);
            }

            return true;
        }

    }

    public class IMGFileGifple
    {
        public Bitmap Bmp;
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

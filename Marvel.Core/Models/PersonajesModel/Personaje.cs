using System;
using System.Collections.Generic;
using System.Text;
using Marvel.Core.Models.BaseMarvelModel;

namespace Marvel.Core.Models.PersonajesModel
{
    public class Personaje
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string modified { get; set; }
      
        public Thumbnail thumbnail { get; set; }
    }
}

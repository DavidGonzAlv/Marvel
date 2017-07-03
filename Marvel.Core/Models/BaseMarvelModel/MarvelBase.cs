using System;
using System.Collections.Generic;
using System.Text;
using Marvel.Core.Models.Data;

namespace Marvel.Core.Models.BaseMarvelModel
{
    public class MarvelBase<T> where T : class
    {
        public int code { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
        public string attributionText { get; set; }
        public string attributionHTML { get; set; }
        public string etag { get; set; }
        public MarvelData<T> data { get; set; }
    }
    public class Thumbnail
    {
        public string path { get; set; }
        public string extension { get; set; }

        public string rutaImagen => path + "." + extension;
    }
}

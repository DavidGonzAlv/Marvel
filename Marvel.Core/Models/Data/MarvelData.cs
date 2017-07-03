using System;
using System.Collections.Generic;
using System.Text;
using Marvel.Core.Models.BaseMarvelModel;

namespace Marvel.Core.Models.Data
{
    public class MarvelData<T>
    {
      
            public int offset { get; set; }
            public int limit { get; set; }
            public int total { get; set; }
            public int count { get; set; }
            public List<T> results { get; set; }
        
    }
}

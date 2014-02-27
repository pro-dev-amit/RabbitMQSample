using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Data
{
    public class MXEmployee : MXEntity
    {        
        public string Name { get; set; }

        public List<string> Skills { get; set; }

    }
}

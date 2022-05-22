using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCApp.Models
{
    public class Person
    {
        // PersionIdをレコードの主キーとする

        public int PersonId { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public int Age { get; set; }
    }
}

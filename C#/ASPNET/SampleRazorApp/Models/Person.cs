using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SampleRazorApp.Models
{
    public class Person
    {
        // PersionIdをレコードの主キーとする

        public int PersonId { get; set; }

        [Required]
        //[Index(IsUnique = true)]
        [StringLength(256)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [DataType(DataType.Text)]
        public int Age { get; set; }
    }
}

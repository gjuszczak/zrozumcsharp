using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zrozumcsharp.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string UrlSlug { get; set; }
    }
}

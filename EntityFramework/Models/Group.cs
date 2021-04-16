using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<Song> Songs { get; set; }
    }
}

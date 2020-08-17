using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Choozy.Data.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0,120)]
        public int Age { get; set; }

        [Display(Name="Is Excluded?")]
        public bool IsExcluded { get; set; } = false;

        [Display(Name="Avatar Filename")]
        public string AvatarFilename { get; set; } = "default.png";
    }
}

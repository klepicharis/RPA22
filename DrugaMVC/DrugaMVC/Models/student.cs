using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrugaMVC.Models
{
    public class student
    {
        public int Studentid { get; set; }
    [Display(Name="Ime")]
    [Required(ErrorMessage ="What the dog doin")]
        public String Studentname { get; set; }
        [Display(Name ="Starost")]
        [Range(5,50,ErrorMessage ="Doin ur mom")]
        public int Age { get; set; }
    }
}
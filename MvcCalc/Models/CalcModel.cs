using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCalc.Models
{
    /// <summary>
    /// Model for calculating
    /// </summary>
    public class CalcModel
    {
        [Required]
        [Display(Name="Первая переменная")]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }
        [Display(Name = "Результат:")]
        public double? Result { get; set; }
        [Display]
        public List<string> Action { get; set; }
    }
}
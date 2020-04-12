using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NASAPOD.Models
{
    public class PictureOfDayFilter
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}

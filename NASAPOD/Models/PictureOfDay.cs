using System;
using System.ComponentModel.DataAnnotations;

namespace NASAPOD.Models
{
    public class PictureOfDay
    {
        public string Copyright { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Explanation { get; set; }

        public string Hdurl { get; set; }

        public string Media_type { get; set; }

        public string Service_version { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}

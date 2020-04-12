using System;

namespace NASAPOD.Infra.Dtos
{
    public class PictureOfDayDto
    {
        public PictureOfDayDto()
        {
        }

        public PictureOfDayDto(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsValid => string.IsNullOrEmpty(ErrorMessage);

        public string ErrorMessage { get; private set; }

        public string Copyright { get; set; }

        public DateTime Date { get; set; }

        public string Explanation { get; set; }

        public string Hdurl { get; set; }

        public string Media_type { get; set; }

        public string Service_version { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}

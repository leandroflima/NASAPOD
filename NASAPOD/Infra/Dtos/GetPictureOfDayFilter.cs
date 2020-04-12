using System;

namespace NASAPOD.Infra.Dtos
{
    public class GetPictureOfDayFilter
    {
        public GetPictureOfDayFilter(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; private set; }
    }
}

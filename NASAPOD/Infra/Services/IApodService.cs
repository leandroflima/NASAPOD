using NASAPOD.Infra.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASAPOD.Infra.Services
{
    public interface IApodService
    {
        Task<PictureOfDayDto> GetPictureOfDay(GetPictureOfDayFilter getPictureOfDayFilter);
    }
}

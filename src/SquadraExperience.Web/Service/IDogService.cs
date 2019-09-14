using Refit;
using SquadraExperience.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadraExperience.Web.Service
{
    public interface IDogService
    {
        [Get("/breed/{dogName}/images/random")]
        Task<DogImageModel> GetRandomImage(string dogName);
    }
}

using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IActions
    {
        Task<IEnumerable<Poster>> GetPostersAsync();
        Task<Poster> GetPosterAsync(string id);
        Task CreatePosterAsync(Poster poster);
        Task DeletePosterAsync(string id);
        Task UpdatePosterAsync(Poster poster);
    }
}

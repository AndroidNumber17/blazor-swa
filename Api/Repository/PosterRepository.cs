using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Database;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class PosterRepository : IActions
{
    private readonly DataContext context;
    
    public PosterRepository(DataContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Poster>> GetPostersAsync()
    {
        return await context.Posters.ToListAsync();
    }

    public async Task<Poster> GetPosterAsync(string id)
    {
        return await context.Posters.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreatePosterAsync(Poster poster)
    {
        await context.Posters.AddAsync(poster);
        await context.SaveChangesAsync();
    }

    public async Task DeletePosterAsync(string id)
    {
        var poster = await GetPosterAsync(id);
        context.Posters.Remove(poster);
        await context.SaveChangesAsync();
    }

    public async Task UpdatePosterAsync(Poster poster)
    {
        context.Posters.Update(poster);
        await context.SaveChangesAsync();
    }
}
using DotNetCoreIdentity.Mvc.Data;
using DotNetCoreIdentity.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreIdentity.Mvc.Services
{
    public class AlbumEfService : IAlbumService
    {
        private readonly ApplicationDbContext _context;

        public AlbumEfService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetAllAsync()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task<Album> AddAsync(Album model)
        {
            _context.Albums.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task UpdateAsync(Album model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Album model)
        {
            _context.Albums.Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}

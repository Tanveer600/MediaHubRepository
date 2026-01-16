using MediaHub.Domain.Entities;
using MediaHub.Domain.Enums;
using MediaHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaHub.Infrastructure.Data.Repositories
{
    public class MediaRepository : IMediaInterface
    {
        private readonly AppDbContext _context;

        public MediaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Media> Create(Media model)
        {
            // Default MediaType if invalid
            if (!Enum.IsDefined(typeof(MediaType), model.MediaType))
                model.MediaType = MediaType.Image;
                

            await _context.MediaItems.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<Media?> Read(long id)
        {
            return await _context.MediaItems
                .Include(m => m.Category)
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Media> Update(Media model)
        {
            var existing = await _context.MediaItems.FindAsync(model.Id);
            if (existing == null)
                throw new Exception("Media not found"); // service will handle this

            existing.Title = model.Title;
            existing.Description = model.Description;
            existing.FilePath = model.FilePath;

            if (Enum.IsDefined(typeof(MediaType), model.MediaType))
                existing.MediaType = model.MediaType;

            existing.CategoryId = model.CategoryId;
            existing.UserId= model.UserId;  

            _context.MediaItems.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> Delete(long id)
        {
            var existing = await _context.MediaItems.FindAsync(id);
            if (existing == null)
                return false;

            _context.MediaItems.Remove(existing);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Media>> GetAll()
        {
            return await _context.MediaItems
                .Include(m => m.Category)
                .Include(m => m.User)
                .ToListAsync();
        }
    }
}

using MediaHub.Application;
using MediaHub.Domain;
using MediaHub.Domain.Entities;
using MediaHub.Domain.Enums;
using MediaHub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ResponseDataModel> Create(Media model)
        {
            var response = new ResponseDataModel();
            try
            {
                // Ensure MediaType is valid
                if (!Enum.IsDefined(typeof(MediaType), model.MediaType))
                    model.MediaType = MediaType.Image; // Default fallback
                    model.MediaType = MediaType.Audio;
                    model.MediaType = MediaType.Video;  
                var created = await _context.MediaItems.AddAsync(model);
                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Media created successfully";
                response.Data = created.Entity;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error creating media";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDataModel> Read(long id)
        {
            var response = new ResponseDataModel();
            try
            {
                var media = await _context.MediaItems
                    .Include(m => m.Category)
                    .Include(m => m.User)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (media == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Media not found";
                }
                else
                {
                    response.IsSuccess = true;
                    response.Data = media;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error fetching media";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDataModel> Update(Media model)
        {
            var response = new ResponseDataModel();
            try
            {
                var existing = await _context.MediaItems.FindAsync(model.Id);
                if (existing == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Media not found";
                    return response;
                }

                // Update properties
                existing.Title = model.Title;
                existing.Description = model.Description;
                existing.FilePath = model.FilePath;

                // Ensure MediaType is valid before updating
                if (Enum.IsDefined(typeof(MediaType), model.MediaType))
                    existing.MediaType = model.MediaType;
                  

                existing.CategoryId = model.CategoryId;

                _context.MediaItems.Update(existing);
                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Media updated successfully";
                response.Data = existing;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error updating media";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDataModel> Delete(long id)
        {
            var response = new ResponseDataModel();
            try
            {
                var existing = await _context.MediaItems.FindAsync(id);
                if (existing == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Media not found";
                    return response;
                }

                _context.MediaItems.Remove(existing);
                await _context.SaveChangesAsync();

                response.IsSuccess = true;
                response.Message = "Media deleted successfully";
                response.Data = existing;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error deleting media";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDataModel> GetAll()
        {
            var response = new ResponseDataModel();
            try
            {
                var allMedia = await _context.MediaItems
                    .Include(m => m.Category)
                    .Include(m => m.User)
                    .ToListAsync();

                response.IsSuccess = true;
                response.Data = allMedia;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error fetching media list";
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}

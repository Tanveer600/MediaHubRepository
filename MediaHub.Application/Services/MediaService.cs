using MediaHub.Application;
using MediaHub.Application.DTOs;
using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaHub.Application.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaInterface _mediaInterface;

        public MediaService(IMediaInterface mediaInterface)
        {
            _mediaInterface = mediaInterface;
        }

        // ✅ CREATE
        public async Task<ResponseDataModel> CreateMedia(CreateMediaDto dto)
        {
            var media = new Media
            {
                Title = dto.Title,
                Description = dto.Description,
                FilePath = dto.FilePath,
                MediaType = dto.MediaType,
                UserId = dto.UserId,
                CategoryId = dto.CategoryId
            };

            var created = await _mediaInterface.Create(media);

            return new ResponseDataModel
            {
                IsSuccess = true,
                Message = "Media created successfully",
                Data = created
            };
        }

        // ✅ READ
        public async Task<ResponseDataModel> ReadMedia(long id)
        {
            var response = new ResponseDataModel();
            var media = await _mediaInterface.Read(id);

            if (media == null)
            {
                response.IsSuccess = false;
                response.Message = "Media not found";
                return response;
            }

            response.IsSuccess = true;
            response.Data = media;
            return response;
        }

        // ✅ UPDATE
        public async Task<ResponseDataModel> UpdateMedia(UpdateMediaDto dto)
        {
            var response = new ResponseDataModel();
            var existing = await _mediaInterface.Read(dto.id);

            if (existing == null)
            {
                response.IsSuccess = false;
                response.Message = "Media not found";
                return response;
            }

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.FilePath = dto.FilePath;
            existing.MediaType = dto.MediaType;
            existing.CategoryId = dto.CategoryId;

            var updated = await _mediaInterface.Update(existing);

            response.IsSuccess = true;
            response.Message = "Media updated successfully";
            response.Data = updated;
            return response;
        }

        // ✅ DELETE
        public async Task<ResponseDataModel> DeleteMedia(long id)
        {
            var response = new ResponseDataModel();
            var deleted = await _mediaInterface.Delete(id);

            if (!deleted)
            {
                response.IsSuccess = false;
                response.Message = "Media not found or could not be deleted";
                return response;
            }

            response.IsSuccess = true;
            response.Message = "Media deleted successfully";
            return response;
        }

        // ✅ GET ALL
        public async Task<ResponseDataModel> GetAllMedia()
        {
            var response = new ResponseDataModel();
            var allMedia = await _mediaInterface.GetAll();

            response.IsSuccess = true;
            response.Data = allMedia;
            return response;
        }
    }
}

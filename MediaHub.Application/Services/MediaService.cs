using MediaHub.Application.Interfaces;
using MediaHub.Domain.Entities;
using MediaHub.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaHub.Application; // <-- ResponseDataModel

namespace MediaHub.Application.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaInterface _mediaInterface;
        public MediaService(IMediaInterface mediaInterface)
        {
            _mediaInterface = mediaInterface;
        }
        public async Task<ResponseDataModel> CreateMedia(Media model)
        {
          return  await _mediaInterface.Create(model);
        }

        public Task<ResponseDataModel> DeleteMedia(long id)
        {
           return _mediaInterface.Delete(id);
        }

        public Task<ResponseDataModel> GetAllMedia()
        {
           return _mediaInterface.GetAll();
        }

        public Task<ResponseDataModel> ReadMedia(long id)
        {
            return _mediaInterface.Read(id);
        }

        public Task<ResponseDataModel> UpdateMedia(Media model)
        {
           return _mediaInterface.Update(model);
        }
    }
}

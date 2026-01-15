using System;
using System.Collections.Generic;
using MediaHub.Domain.Entities; // Media class namespace
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Add the following using directive if the Media class exists in another namespace
// using MediaHub.Domain.Entities; // <-- Uncomment and adjust the namespace as needed

namespace MediaHub.Application.Interfaces
{
    public interface IMediaService
    {
        Task<ResponseDataModel> CreateMedia(Media model);
        Task<ResponseDataModel> ReadMedia(long id);
        Task<ResponseDataModel> UpdateMedia(Media model);
        Task<ResponseDataModel> DeleteMedia(long id);
        Task<ResponseDataModel> GetAllMedia();
    }
}

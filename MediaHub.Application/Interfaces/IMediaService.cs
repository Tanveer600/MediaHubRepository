using MediaHub.Application.DTOs;
using System.Threading.Tasks;

namespace MediaHub.Application.Interfaces
{
    public interface IMediaService
    {
        Task<ResponseDataModel> CreateMedia(CreateMediaDto model);
        Task<ResponseDataModel> ReadMedia(long id);
        Task<ResponseDataModel> UpdateMedia(UpdateMediaDto model);
        Task<ResponseDataModel> DeleteMedia(long id);
        Task<ResponseDataModel> GetAllMedia();
    }
}

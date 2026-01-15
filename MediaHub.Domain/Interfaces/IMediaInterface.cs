
using MediaHub.Domain.Entities;
using MediaHub.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Domain.Interfaces
{
    public interface IMediaInterface
    {
        Task<ResponseDataModel> Create(Media model);
        Task<ResponseDataModel> Read(long id);
        Task<ResponseDataModel> Update(Media model);
        Task<ResponseDataModel> Delete(long id);
        Task<ResponseDataModel> GetAll();
    }
}

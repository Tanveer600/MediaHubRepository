
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
        Task<Media> Create(Media model);
        Task<Media?> Read(long id);
        Task<Media> Update(Media model);
        Task<bool> Delete(long id);
        Task<List<Media>> GetAll();
    }
}

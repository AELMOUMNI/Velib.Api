using System.Collections.Generic;
using System.Threading.Tasks;
using Velib.Core.Entities;

namespace Velib.Core.Services
{
    public interface IVelibService
    {
        Task<VelibResponse<List<VelibAvailableReelTime>>> GetAllVelibDisponibiliteEnTempsReel(int? total);
        Task<VelibResponse<List<VelibAvailableReelTime>>> GetVelibs();
    }
}

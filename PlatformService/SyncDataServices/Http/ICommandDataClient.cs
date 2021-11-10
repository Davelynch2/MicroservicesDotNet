using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlateformService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}
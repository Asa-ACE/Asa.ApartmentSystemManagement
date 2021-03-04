using System.Threading.Tasks;

namespace Asa.ApartmentSystemManagement.Core.BaseInfo.Gateways
{
    public interface IAdminTableGateway
    {
        Task InsertAdminAsync(int userId, int buildingId);
    }
}
using PocAPI.DTOs;
using PocAPI.Entities;

namespace PocAPI.Services
{
    public interface IDemoEntityService
    {
        Task<List<DemoDto>> GetDemoEntitiesAsync();
        Task<DemoDto> GetDemoEntityByIdAsync(int id);
        Task<DemoEntity> CrateDemoEntityAsync(CreateDemoDto createDemoDto);
        Task<DemoEntity> UpdateEntityAsync(UpdateDemoDto updateDemoDto);
        Task<bool> DeleteEntityAsync(int id);
    }
}

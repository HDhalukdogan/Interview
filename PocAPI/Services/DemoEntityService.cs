using Microsoft.EntityFrameworkCore;
using PocAPI.Data;
using PocAPI.DTOs;
using PocAPI.Entities;
using System.Threading;

namespace PocAPI.Services
{
    public class DemoEntityService(DemoDbContext context) : IDemoEntityService
    {
        public async Task<DemoEntity> CrateDemoEntityAsync(CreateDemoDto createDemoDto)
        {
            var entityEntry = await context.DemoEntities.AddAsync(new DemoEntity
            {
                Name = createDemoDto.Name
            });
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteEntityAsync(int id)
        {
            var entity = await context.DemoEntities.FirstOrDefaultAsync(x => x.Id == id);
            context.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<DemoDto>> GetDemoEntitiesAsync()
        {
            var entities = await context.DemoEntities.ToListAsync();
            return entities.Select(s=> new DemoDto { Id = s.Id, Name = s.Name }).ToList();
        }

        public async Task<DemoDto> GetDemoEntityByIdAsync(int id)
        {

            var entity = await context.DemoEntities.FirstOrDefaultAsync(x => x.Id == id);
            return new DemoDto { Id= entity.Id , Name = entity.Name };
        }

        public async Task<DemoEntity> UpdateEntityAsync(UpdateDemoDto updateDemoDto)
        {
            var entityEntry = context.Update(new DemoEntity
            {
                Id = updateDemoDto.Id,
                Name = updateDemoDto.Name
            });
            await context.SaveChangesAsync();
            return entityEntry.Entity;
        }
    }
}

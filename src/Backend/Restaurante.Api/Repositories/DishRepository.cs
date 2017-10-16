using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Restaurante.Api.DataMappers;
using Restaurante.Api.Models;
using Restaurante.Persistence;
using Restaurante.Persistence.Models;

namespace Restaurante.Api.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private AppDbContext _db = new AppDbContext();

        public async Task<List<Dish>> List()
        {
            try {
                var entities = await _db.Restaurants.Where(p => p.Active == true)
                                                    .Where(p => p.Dishes.Count > 0)
                                                    .Include(p => p.Dishes)
                                                    .ToListAsync();

                if (entities == null) {
                    return new List<Dish>();
                }

                return entities.MapToDishDto();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<int> Create(Dish model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            try {
                if ((await FindByName(model.Name, model.RestaurantId, true)).Count > 0) {
                    return -1;
                }

                var entity = model.MapToEntity();

                _db.Dishes.Add(entity);
                int x = await _db.SaveChangesAsync();

                return entity.Id;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<Dish> Find(int id)
        {
            if (id < 1) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            try {
                var entity = await FindById(id);

                if (entity == null) {
                    return null;
                }

                return entity.MapToDto();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<List<Dish>> Find(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Dish model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            try {
                var entity = await FindById(model.Id);

                if (entity == null) {
                    return false;
                }

                entity.Name = model.Name;
                entity.Price = model.Price;
                entity.UpdatedAt = DateTime.Now;

                _db.Entry(entity).State = EntityState.Modified;
                int x = await _db.SaveChangesAsync();

                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            if (id < 1) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            try {
                var entity = await FindById(id);

                if (entity == null) {
                    return false;
                }

                entity.Active = false;
                entity.DeletedAt = DateTime.Now;

                _db.Entry(entity).State = EntityState.Modified;
                int x = await _db.SaveChangesAsync();

                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }

        private async Task<List<DishEntity>> FindByName(string name, int restaurantId, bool exactMatch = false)
        {
            try {
                var query = _db.Dishes.Where(p => p.Active == true)
                                      .Where(p => p.RestaurantId == restaurantId);

                if (exactMatch == false) {
                    query = query.Where(p => p.Name.Contains(name));
                } else {
                    query = query.Where(p => p.Name == name);
                }

                return await query.ToListAsync();
            } catch (Exception ex) {
                throw ex;
            }
        }

        private async Task<DishEntity> FindById(int id)
        {
            if (id < 1) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            try {
                return await _db.Dishes.Where(p => p.Active == true)
                                       .Where(p => p.Id == id)
                                       .FirstOrDefaultAsync();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
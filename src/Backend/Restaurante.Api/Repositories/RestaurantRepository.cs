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
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private AppDbContext _db = new AppDbContext();

        public async Task<List<Restaurant>> List()
        {
            try {
                var entities = await _db.Restaurants.Where(p => p.Active == true).ToListAsync();

                if (entities == null) {
                    return new List<Restaurant>();
                }

                return entities.MapToDto();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<int> Create(Restaurant model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }

            try {
                if ((await FindByName(model.Name, true)).Count > 0) {
                    return -1;
                }

                var entity = model.MapToEntity();

                _db.Restaurants.Add(entity);
                int x = await _db.SaveChangesAsync();

                return entity.Id;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<Restaurant> Find(int id)
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

        public async Task<List<Restaurant>> Find(string name)
        {
            try {
                var entity = await FindByName(name);

                if (entity == null) {
                    return new List<Restaurant>();
                }

                return entity.MapToDto();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<bool> Update(Restaurant model)
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

        private async Task<List<RestaurantEntity>> FindByName(string name, bool exactMatch = false)
        {
            try {
                var query = _db.Restaurants.Where(p => p.Active == true);

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

        private async Task<RestaurantEntity> FindById(int id)
        {
            if (id < 1) {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            try {
                return await _db.Restaurants.Where(p => p.Active == true)
                                            .Where(p => p.Id == id)
                                            .FirstOrDefaultAsync();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class LocalDbRestaurantData : IRestaurantData
    {
        OdeToFoodDbContext dbContext;
        public LocalDbRestaurantData(OdeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Restaurant restaurant)
        {
            dbContext.Restaurants.Add(restaurant);
            dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var model = Get(Id);
            dbContext.Restaurants.Remove(model);
            dbContext.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return dbContext.Restaurants.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from p in dbContext.Restaurants
                   orderby p.Name
                   select p;

            // return dbContext.Restaurants.ToList().OrderBy(p => p.Name);
        }

        public void Update(Restaurant restaurant)
        {
            // concurreny issue will create here... last write will win as it's Unit of work model
            var filteredRestaurant = Get(restaurant.Id);
            if (filteredRestaurant != null)
            {
                filteredRestaurant.Name = restaurant.Name;
                filteredRestaurant.Cuisine = restaurant.Cuisine;
                dbContext.SaveChanges();
            }


            // another solution
            /*            var entry = dbContext.Entry(restaurant);
                        entry.State = EntityState.Modified;
                        dbContext.SaveChanges();*/
        }
    }
}

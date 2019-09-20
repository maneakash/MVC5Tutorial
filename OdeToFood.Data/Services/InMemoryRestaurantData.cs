using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant{ Id=1, Name="test restaurant1", Cuisine = CuisineType.Indian},
                new Restaurant{ Id=2, Name="test restaurant2", Cuisine = CuisineType.French},
                new Restaurant{ Id=3, Name="test restaurant3", Cuisine = CuisineType.Italian}
            };
        }

        public void Create(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(p => p.Id) + 1;
        }

        public void Delete(int Id)
        {
            var model = Get(Id);
            restaurants.Remove(model);
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(p => p.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var model = Get(restaurant.Id);
            if (model != null)
            {
                model.Name = restaurant.Name;
                model.Cuisine = restaurant.Cuisine;
            }
        }
    }
}

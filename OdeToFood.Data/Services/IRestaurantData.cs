﻿using OdeToFood.Data.Models;
using System.Collections.Generic;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();

        Restaurant Get(int id);

        void Create(Restaurant restaurant);

        void Update(Restaurant restaurant);

        void Delete(int Id);
    }
}
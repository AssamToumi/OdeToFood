using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Il Ritrovo Degli Artisti", Location= "12 Rue Mohamed Triki | Ennasr ll, Tunis 2035, Tunisia", Cuisine=CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Chili's American Grill", Location= "Rue Azouz Erbaii | El Manar 2, Tunis 2079, Tunisia", Cuisine=CuisineType.Mexican},
                new Restaurant {Id = 3, Name = "Dum Pukht", Location= "3, Avenue du Boulevard | 1053 Le Berges du Lac, Tunis, Tunisia", Cuisine=CuisineType.Indian}
            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
         }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
                if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public int Commit()
            {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
            where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                select r;       
                   }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
    }


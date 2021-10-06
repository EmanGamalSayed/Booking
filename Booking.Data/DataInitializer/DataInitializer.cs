using Booking.Core.Models;
using Booking.Core.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Booking.Data.DataInitializer
{
    public class DataInitializer : IDataInitializer
    {
        public List<User> SeedUsers()
        {
            var userList = new List<User>();
            User user = new User()
            {
                Id = new Guid("b74ddd14-6340-4840-95c2-db12554843e5"),
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            userList.Add(user);

            user = new User()
            {
                Id = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                UserName = "HR",
                Email = "hr@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "HR*123");

            userList.Add(user);
            return userList;
        }

        public List<Role> SeedRoles()
        {
            var roleList = new List<Role>();
            Role role = new Role()
            {
                Id = new Guid("fab4fac1-c546-41de-aebc-a14da6895711"),
                Name = "Admin",
                ConcurrencyStamp = "1",
                NormalizedName = "Admin" 
            };

            roleList.Add(role);
            role = new Role()
            {
                Id = new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"),
                Name = "HR",
                ConcurrencyStamp = "2",
                NormalizedName = "Human Resource"
            };
            roleList.Add(role);
            return roleList;
        }

        public List<UserRole> SeedUserRoles()
        {
            var userRoleList = new List<UserRole>();
            var userRole = new UserRole()
            {
                RoleId = new Guid("fab4fac1-c546-41de-aebc-a14da6895711"),
                UserId = new Guid("b74ddd14-6340-4840-95c2-db12554843e5")
            };
            userRoleList.Add(userRole);

            userRole = new UserRole()
            {
                RoleId = new Guid("c7b013f0-5201-4317-abd8-c211f91b7330"),
                UserId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482")
            };

            userRoleList.Add(userRole);
            return userRoleList;
        }

        public List<Trip> SeedTrips()
        {
            var tripList = new List<Trip>();
            Trip trip = new Trip()
            {
                Id = 1,
                Name = "India Trip",
                CityName = "India",
                Content = WebUtility.HtmlEncode("<h3>India<h3> <p> Most people agree travelling is a good thing. People think it’s exciting, almost invigorating to travel. Travelling is the best way to learn new things. </p>"),
                Price = 50000,
                ImageUrl = "Assets/Imgs/india.jpg",
                CreationDate = DateTime.Now
            };
            tripList.Add(trip);

            trip = new Trip()
            {
                Id = 2,
                Name = "Giza Trip",
                CityName = "Giza",
                Content = WebUtility.HtmlEncode("<h4>Giza<h4> <p> The Great Pyramid of Giza is a huge pyramid built by the Ancient Egyptians. It stands 18.4 km from Cairo, Egypt. It is the oldest of the Seven Wonders of the Ancient World, and the only one to remain mostly intact. </p>"),
                Price = 200,
                ImageUrl = "Assets/Imgs/Giza.jpg",
                CreationDate = DateTime.Now
            };
            tripList.Add(trip);

            trip = new Trip()
            {
                Id = 3,
                Name = "Alex Trip",
                CityName = "Alex",
                Content = WebUtility.HtmlEncode("<h4>Alex<h4> <p> The Great Pyramid of Giza is a huge pyramid built by the Ancient Egyptians. It stands 18.4 km from Cairo, Egypt. It is the oldest of the Seven Wonders of the Ancient World, and the only one to remain mostly intact. </p>"),
                Price = 400,
                ImageUrl = "Assets/Imgs/Alex.jpg",
                CreationDate = DateTime.Now
            };
            tripList.Add(trip);
            return tripList;
        }
    }
}

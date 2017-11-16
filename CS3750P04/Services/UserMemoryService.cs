using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS3750P04.Models;

namespace CS3750P04.Services
{
    public class UserMemoryService : IUserService
    {
        private readonly List<UserModel> users = new List<UserModel>();

        public UserMemoryService()
        {
            users.Add(new UserModel
            {
                UserId = 1,
                ScreenName = "smokey420",
                FirstName = "John",
                LastName = "Doe",
                IsActive = true,
                UserHash = "7cd4b923d01c3d91d030e3a244d2386a483f8b6d57b20281e03dd6231ba25570" //sha256 hash of ScreenName:password
            });
            users.Add(new UserModel
            {
                UserId = 2,
                ScreenName = "apeLover88",
                FirstName = "Alice",
                LastName = "Anderson",
                IsActive = true,
                UserHash = "1d7d2211423d9ffc8bc743567edd3ce805034c022218420148be98f6176fb0d2"
            });
            users.Add(new UserModel
            {
                UserId = 3,
                ScreenName = "badboil337",
                FirstName = "Bob",
                LastName = "Robertson",
                IsActive = true,
                UserHash = "e1c71b92f37d8120c5406bf5757fa9418bd054cddf7726d3cb96bd9d05615243"
            });
        }

        public Task Add(UserModel model)
        {
            model.UserId = users.Max(u => u.UserId) + 1;
            users.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<UserModel>> GetAll()
        {
            return Task.Run(() => users.AsEnumerable());
        }

        public Task<UserModel> GetById(int id)
        {
            return Task.Run(() =>
            {
                return users.First(u => u.UserId == id);
            });
        }
    }
}

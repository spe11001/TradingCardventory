using MongoDB.Driver;
using System;
using System.Linq;
using TradingCardventory.Models;

namespace TradingCardventory.Utilites
{
    public class DataBaseAccessUtility
    {
        IMongoDatabase _db;

        public DataBaseAccessUtility()
        {
            var connectionString = "mongodb+srv://live2020:live2020pass@cluster0.bacm3.mongodb.net/MySiteDB?retryWrites=true&w=majority";

            var _databaseName = MongoUrl.Create(connectionString).DatabaseName; //this is a string of the database name set up on MongoDB

            //an implementation of the database of type IMongoDatabase
            _db = new MongoClient("mongodb+srv://live2020:live2020pass@cluster0.bacm3.mongodb.net/MySiteDB?retryWrites=true&w=majority").GetDatabase(_databaseName);
        }

        public User GetLoggedInUser(string userName, string password)
        {
            var collection = _db.GetCollection<User>("Users");
            var result = collection.Find(x => x.UserName == userName && x.Password == password).ToList(); //shorthand for doing foreach loop 

            if (result.Count > 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }

        public User GetUserById(string userId)
        {
            var collection = _db.GetCollection<User>("Users");
            var result = collection.Find(x => x.UserId == userId).ToList();

            if (result.Count > 0)
            {
                return result.First();
            }
            else
            {
                return null;
            }
        }
        public void CreateUserAccount(User user)
        {
            var collection = _db.GetCollection<User>("Users");
            if (user.UserId == null)
            {
                user.UserId = Guid.NewGuid().ToString();
            }
            user.UserName.Trim();
            user.Password.Trim();
            collection.InsertOne(user);
        }

    }
}

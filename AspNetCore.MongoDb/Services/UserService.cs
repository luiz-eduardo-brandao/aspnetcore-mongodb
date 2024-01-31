using AspNetCore.MongoDb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AspNetCore.MongoDb.Services;

public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UserService(IOptions<UserDatabaseConfiguration> userConfiguration)
    {
        var mongoClient = new MongoClient(userConfiguration.Value.ConnectionString);

        var projectDatabase = mongoClient.GetDatabase(userConfiguration.Value.DatabaseName);

        _usersCollection = projectDatabase.GetCollection<User>(userConfiguration.Value.UsersCollectionName);
    }

    public async Task<List<User>> GetUsersAsync() => await _usersCollection.Find(_ => true).ToListAsync();

    public async Task CreateAsync(User user) => await _usersCollection.InsertOneAsync(user);

    public async Task ReplaceAsync(string id, User user) => await _usersCollection.ReplaceOneAsync(u => u.Id == id, user); 

    public async Task RemoveAsync(string id) => await _usersCollection.DeleteOneAsync(u => u.Id == id);
}

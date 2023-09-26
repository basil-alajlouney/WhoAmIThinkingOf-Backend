using Connector;
using ContextMenu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ControllerMenu;
[Controller]
[Route("/[controller]")]
public class UserController:ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly ConnectionPoint db = new();
    public UserController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    [HttpGet(Name = "Login")]
    public IActionResult Get([FromHeader] string IP,[FromHeader] string username, [FromHeader] string password)
    {
        var UserData = db.Users.Where(
        a=>a.username == username
        && a.password == password);
        if(!UserData.Any())
        throw new Exception("wrong username or password");

        if(IP is null)
        throw new Exception("the IP is required");
        _memoryCache.Set(IP,UserData.First(),TimeSpan.FromMinutes(20));
        return Ok(UserData.First());
    }
    [HttpPost(Name = "Sign up")]
    public IActionResult Post([FromBody] UserContext NewUser)
    {
        if(NewUser is null
        || NewUser.password is null)
        throw new Exception("somthing wrong with credentials");

        db.Users.Add(NewUser);
        db.SaveChanges();
        return Ok("Added successfully");
    }
}
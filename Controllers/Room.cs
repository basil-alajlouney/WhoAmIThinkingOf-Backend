using ContextMenu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Caching.Memory;
using SQLitePCL;
namespace ControllerMenu;
[Controller]
[Route("Room/{RoomID}")]
public class Room:ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    public Room(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    private string AddQuestion(int RoomId,string Question)
    {
        var Room = _memoryCache.Get<RoomContext>(RoomId)
        ?? throw new Exception("Wrong Room ID");

        Room.Questions.Add(Question);
        return "Question Added";
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromHeader] string IP)
    {
        var Room = new RoomContext();
        var rand  = new Random();
        Room.RoomID =  rand.Next(10000,100001);
        while(_memoryCache.Get(Room.RoomID) is not null)
        Room.RoomID = rand.Next(10000,100001);
        Room.Participants.Add(
             ParticipantsContext
            .FromUser(_memoryCache.Get<UserContext>(IP)!));
        Room.Urls = await Room.FetchData();
        Room.CharacterPicker = Room.Participants[0];
        _memoryCache.Set(Room.RoomID, Room,TimeSpan.FromHours(1));
        return Ok(Room);
    }
    [HttpGet]
    public IActionResult Get(int RoomID,[FromHeader] string IP)
    {
        System.Console.WriteLine(RoomID);
        var Room = _memoryCache.Get<RoomContext>(RoomID)
        ?? throw new Exception("this Room Doesn't Exist");
        
        var user = ParticipantsContext.FromUser(_memoryCache.Get<UserContext>(IP)!);

        if(Room.Participants.Any(a=>a.username == user.username))
        throw new Exception("this user has already Joined this room");

        Room.Participants.Add(user);

        return Ok("Joined the Room Successfully");
    }
    [HttpPatch]
    public IActionResult Patch(int RoomID,[FromHeader] string IP,string? Question)
    {
        if( Question is not null)
        return Ok(AddQuestion(RoomID,Question));

        var Room = _memoryCache.Get<RoomContext>(RoomID) 
        ?? throw new Exception("Wrong room ID");
        
        var user = ParticipantsContext.FromUser(_memoryCache.Get<UserContext>(IP)!);
        Room.CharacterPicker = user;
        
        return Ok("Character Picker Changed");
    }
    [HttpPut]
    public IActionResult Put(int RoomID,[FromHeader] string IP,string Name)
    {
        var Room = _memoryCache.Get<RoomContext>(RoomID)
        ?? throw new Exception("Wrong room ID");

        if(Name is null
        || Name == "")
        throw new Exception("invalid name");

        Room.ChoosenName = Name;
        return Ok("Character choosen");
    }
    [HttpOptions]
    public IActionResult Options(int RoomID)
    {
        var Room = _memoryCache.Get<RoomContext>(RoomID)
        ?? throw new Exception("Wrong Room ID");
        return Ok();
    }
}
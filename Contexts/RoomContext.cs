using System.Text;
using Newtonsoft.Json;

namespace ContextMenu;
public class RoomContext
{
    public int RoomID {get;set;}
    public async Task<List<string>> FetchData()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri("https://randommer.io/api/Name?nameType=firstname&quantity=32"),
            Method = HttpMethod.Get
        };
        request.Headers.Add("Accept", "*/*");
        request.Headers.Add("User-Agent", "Thunder Client (https://www.thunderclient.com)");
        request.Headers.Add("X-Api-Key", "2afbea7ca896480b8e65ed06b71dadda");

        var bodyString = "{\r  \"username\": \"userMax4\",\r  \"password\": \"userMax4\",\r  \"pfp\": \"https://wallpapers.com/images/hd/anime-pfp-pictures-w4oe52ev7wyjtpgh.jpg\"\r}";
        var content = new StringContent(bodyString, Encoding.UTF8, "application/json");
        request.Content = content;

        var response = await client.SendAsync(request);
        var result = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
        string BaseUrl = "https://api.dicebear.com/7.x/micah/svg?seed=";
        for(int i=0;i<result!.Count;i++)
        result[i] = BaseUrl + result[i]; 
return result;
    }
    public List<ParticipantsContext> Participants {get;set;} = new();
    public List<string> Urls {get;set;} =new();
    public List<string> Questions {get;set;} =new();
    public string ChoosenName {get;set;} = null!;
    public ParticipantsContext? CharacterPicker {get;set;}

}
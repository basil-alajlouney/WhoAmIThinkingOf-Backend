namespace ContextMenu;
public class ParticipantsContext
{
    public static ParticipantsContext FromUser(UserContext user)
    {
        var Participant = new ParticipantsContext
        {
        username = user.username,
        PFP = user.PFP
        };
        return Participant;
    }
    public int ParticipantsId {get;set;}
    public string username {get;set;} = null!;
    public string PFP {get;set;} = null!;
}
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ContextMenu;
[Index("username", IsUnique = true)]
public class UserContext
{
    // public static readonly string[] urls = new string[] {"https://wallpapers.com/images/hd/anime-pfp-pictures-w4oe52ev7wyjtpgh.jpg","https://i.waifu.pics/vgJwe~S.png","https://i.waifu.pics/Effxs2Y.png","https://i.waifu.pics/aeaqU4~.png","https://i.waifu.pics/U0xGNIS.jpg","https://i.waifu.pics/TLXAu4x.jpg","https://i.waifu.pics/LxQqHTp.jpg","https://i.waifu.pics/YakDEzc.jpg","https://i.waifu.pics/V_kQGSb.jpg","https://i.waifu.pics/U0xGNIS.jpg","https://i.waifu.pics/99JnWv_.jpg","https://i.waifu.pics/~x_fuOj.jpg","https://i.waifu.pics/F9xv3El.png","https://i.waifu.pics/0QQH_hp.jpg","https://i.waifu.pics/9hJVqI3.png","https://i.waifu.pics/ba4bEn3.jpg","https://i.waifu.pics/q3sr37h.jpg","https://i.waifu.pics/iW-ZW5_.png","https://i.waifu.pics/ZQg83vI.png","https://i.waifu.pics/L-4PQZR.png","https://i.waifu.pics/agX5iAg.png","https://i.waifu.pics/DvtJuMI.jpg","https://i.waifu.pics/7btS~wY.png","https://i.waifu.pics/__4K~dM.png","https://i.waifu.pics/q3sr37h.jpg","https://i.waifu.pics/lZhWeFl.png","https://i.waifu.pics/jnd729D.png","https://i.waifu.pics/~GU3yab.jpg","https://i.waifu.pics/zlXktxX.png","https://i.waifu.pics/9Hbm0kw.jpg","https://i.waifu.pics/tehmxsk.jpg","https://i.waifu.pics/3d5okka.jpg","https://i.waifu.pics/LAdbipm.png","https://i.waifu.pics/9gw4QEi.jpg","https://i.waifu.pics/4i_lD8H.jpg","https://i.waifu.pics/Y0EV-hA.jpg","https://i.waifu.pics/OXLoARS.jpg","https://i.waifu.pics/jnd729D.png","https://i.waifu.pics/W13nei-.jpg","https://i.waifu.pics/eDeP1X9.jpg","https://i.waifu.pics/vuoObNw.jpg","https://i.waifu.pics/UDhO2-p.png","https://i.waifu.pics/hd-3qtP.jpg","https://i.waifu.pics/YDcsFhc.jpg","https://i.waifu.pics/Nc1m4wr.jpg","https://i.waifu.pics/XUitirw.png","https://i.waifu.pics/xuZ4X43.jpg","https://i.waifu.pics/L-4PQZR.png","https://i.waifu.pics/50IFPKx.png","https://i.waifu.pics/tehmxsk.jpg","https://i.waifu.pics/9PfVrRo.jpg","https://i.waifu.pics/jnd729D.png","https://i.waifu.pics/cI9gyIW.jpg","https://i.waifu.pics/aeaqU4~.png","https://i.waifu.pics/c1Kbn5o.jpg","https://i.waifu.pics/Y0EV-hA.jpg","https://i.waifu.pics/upHplLk.jpg","https://i.waifu.pics/cI9gyIW.jpg","https://i.waifu.pics/lm9Ir5i.jpg","https://i.waifu.pics/KAWTYus.jpg","https://i.waifu.pics/f2krp4Y.png"};
    [Key]
    public int userId {get;set;}
    public string username {get;set;} = null!;
    public string password {get;set;} = null!;
    public string PFP {get;set;} = null!;
    public DateTime AccountCreated {get;set;} = DateTime.Now;
}
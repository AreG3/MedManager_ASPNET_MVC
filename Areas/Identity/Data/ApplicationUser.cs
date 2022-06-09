using Microsoft.AspNetCore.Identity;

namespace ASP.NETCoreIdentityCustom.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    public string Nickname { get; set; }
}

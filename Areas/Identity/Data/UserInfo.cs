using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Starpholio.Models;
using Starpholio.Areas.Identity.Data;



namespace Starpholio.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UserInfo class
public class UserInfo : IdentityUser
{

   // public DateTime DateOfBirth { get; set; }
   // public string Location { get; set; }

}

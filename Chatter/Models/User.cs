using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Models
{
    public class User : IdentityUser
    {
        public List<Blog> Blogs{ get; set; }
    }
}

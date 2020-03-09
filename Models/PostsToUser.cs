using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EF_CoreApp.Models
{
    public class PostsToUser
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public IdentityUser User { get; set; }
    }
}

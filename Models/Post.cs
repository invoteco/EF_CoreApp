using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EF_CoreApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostCategory { get; set; }
        public string PostAutor { get; set; }
        public string PostContent { get; set; }
        public DateTime CreationDateTime { get; set; }

        //public string AutorID {
        //    get; set; } = GetUserId(ClaimsPrincipal.Current.Identity.Name);

        //public ICollection<Category> Categories { get; set; }

        public static string GetUserId(string name)
        {
            var user = new IdentityUser(name);
            return user.Id;
        }

    }
}

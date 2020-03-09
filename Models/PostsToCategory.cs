using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_CoreApp.Models
{
    public class PostsToCategory
    {
        public int CategoryId { get; set; }
        public int PostId { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfGetStartedNew
{
    public class Blog
    {

        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}

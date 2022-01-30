using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMuNG.Models;

namespace WebMuNG.Data
{
    public class WebMuNGContext : DbContext
    {
        public WebMuNGContext (DbContextOptions<WebMuNGContext> options)
            : base(options)
        {
        }
    }
}

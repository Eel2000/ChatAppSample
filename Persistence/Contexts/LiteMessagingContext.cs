using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class LiteMessagingContext : DbContext
    {
        public LiteMessagingContext()
        {
        }

        public LiteMessagingContext(DbContextOptions<LiteMessagingContext> options) : base(options)
        {

        }
    }
}

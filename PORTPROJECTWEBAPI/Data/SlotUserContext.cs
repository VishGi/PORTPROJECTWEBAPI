using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PORTPROJECTWEBAPI.Data
{
    public class SlotUserContext : DbContext
    {
        public SlotUserContext(DbContextOptions<SlotUserContext> options) : base(options)
        { }
        public DbSet<UserData> PortUserTable { get; set; }
        public DbSet<SlotData> PortSlotTable { get; set; }

    }
}

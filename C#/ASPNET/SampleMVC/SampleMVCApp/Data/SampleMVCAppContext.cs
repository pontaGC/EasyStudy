using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleMVCApp.Models;

namespace SampleMVCApp.Data
{
    public class SampleMVCAppContext : DbContext
    {
        public SampleMVCAppContext (DbContextOptions<SampleMVCAppContext> options)
            : base(options)
        {
        }

        // DbSet: DbContextで実際にデータベースへアクセスするための機能を提供しているクラス

        public DbSet<SampleMVCApp.Models.Person> Person { get; set; }
    }
}

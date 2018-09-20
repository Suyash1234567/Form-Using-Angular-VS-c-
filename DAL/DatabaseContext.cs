using DBTable.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<States> States { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Constituency> Constituency { get; set; }
        public DbSet<WardNo> WardNo { get; set; }
        public DbSet<VoterEnrollmentt> VoterEnrollment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DBTable.Models;
using System.Linq;

using DAL;
using Microsoft.Extensions.Configuration;

using System.Net;
using System.Net.Mail;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class DBOperations : IDBOperations
    {
        private readonly DatabaseContext _context;

        public DBOperations()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            _context = new DatabaseContext(optionsBuilder.Options);
        }

        public DBOperations(DatabaseContext context)
        {
            _context = context;
        }

       
       
        public List<States> GetStates(DatabaseContext context)
        {
            //using (var context = new DatabaseContext())
            //{ 
                List<States> stateList = new List<States>();
           // _context = context;
            // ------- Getting Data from Database Using EntityFrameworkCore -------
            stateList = (from state in context.States
                         select state).ToList(); // For getting list of states from dbcontext

            // ------- Inserting Select Item in List -------
            stateList.Insert(0, new States { StateId = 0, StateName = "Select" });


            return stateList;
            //    }
        }
    }
}

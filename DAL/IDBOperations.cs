using DBTable.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IDBOperations
    {
        List<States> GetStates(DatabaseContext context);
    }
}

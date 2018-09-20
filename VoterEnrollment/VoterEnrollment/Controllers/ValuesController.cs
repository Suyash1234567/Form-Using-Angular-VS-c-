using DAL;
using DBTable.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;
using System.Threading.Tasks;
using log4net.Config;
using log4net;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using log4net.Core;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace VoterEnrollment.Controllers
{
    [EnableCors("CORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        DatabaseOperations operations;

        public ValuesController(DatabaseContext databaseContext)
        {
            operations = new DatabaseOperations(databaseContext);
        }

        [HttpGet("[action]")]
        public List<States> GetStates()
        {

            return operations.GetStatesByList();
        }

        [HttpGet("[action]")]
        public List<City> GetCity(int StateId)
        {
            return operations.GetCityByList(StateId);
        }

        [HttpGet("[action]")]
        public List<Constituency> GetConstituency(int CityId)
        {
            return operations.GetConstituenciesByList(CityId);
        }

        [HttpGet("[action]")]
        public List<WardNo> GetWard(int constituencyId)
        {
            return operations.GetWardByList(constituencyId);
        }

        [HttpGet("[action]")]
        public string GetEnrollmentNumber(int StateId, int CityId,string PhoneNumber,  int ConstituencyId,int WardNumberId,string EnrollerName, string Email, DateTime DOB, string FatherName)
        {
            return operations.GetEnrollmentNumberByParams( StateId, CityId, PhoneNumber, ConstituencyId, WardNumberId, EnrollerName,Email,DOB,FatherName);
        }
    }
}

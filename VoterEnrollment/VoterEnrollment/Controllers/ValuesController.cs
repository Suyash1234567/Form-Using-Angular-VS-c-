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



namespace VoterEnrollment.Controllers
{
    [EnableCors("CORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //public DBOperations dBOperations;
        private readonly DatabaseContext _context;

        public ValuesController(DatabaseContext context)
        {
            _context = context;
        }

        //[HttpGet("[action]")]
        //public List<States> GetStates()
        //{

        //    List<States> stateList = new List<States>();

        //    //dBOperations = new DBOperations();

        //    stateList = dBOperations.GetStates(_context);


        //    return stateList;
        //}


        [HttpGet("[action]")]
        public List<States> GetStates()
        {
            List<States> stateList = new List<States>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            stateList = (from state in _context.States
                         select state).ToList(); // For getting list of states from dbcontext

            // ------- Inserting Select Item in List -------
            stateList.Insert(0, new States { StateId = 0, StateName = "Select" });


            return stateList;
        }


        [HttpGet("[action]")]
        public List<City> GetCity(int StateId)
        {
            List<City> cityList = new List<City>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            cityList = (from city in _context.City
                        where city.StateId == StateId
                        select city).ToList();

            // ------- Inserting Select Item in List -------
            cityList.Insert(0, new City { CityId = 0, CityName = "Select" });


            return cityList;
        }
        [HttpGet("[action]")]
        public List<Constituency> GetConstituency(int cityId)
        {
            List<Constituency> constituencyList = new List<Constituency>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            constituencyList = (from constituency in _context.Constituency
                                where constituency.CityId == cityId
                                select constituency).ToList();

            // ------- Inserting Select Item in List -------
            constituencyList.Insert(0, new Constituency { ConstituencyId = 0, ConstituencyName = "Select" });


            return constituencyList;
        }

        [HttpGet("[action]")]
        public List<WardNo> GetWard(int constituencyId)
        {
            List<WardNo> wardList = new List<WardNo>();

            // ------- Getting Data from Database Using EntityFrameworkCore -------
            wardList = (from WardNo in _context.WardNo
                        where WardNo.ConstituencyId == constituencyId
                        select WardNo).ToList();

            // ------- Inserting Select Item in List -------
            wardList.Insert(0, new WardNo { WardNumberId = 0, WardNumber = "Select" });


            return wardList;
        }


        [HttpGet("[action]")]
        public string GetEnrollmentNumber(int StateId, int CityId,string PhoneNumber,  int ConstituencyId,int WardNumberId,string EnrollerName, string Email, DateTime DOB, string FatherName)
        {
            string EnrollNumber = generateEnrollmentNumber();
            VoterEnrollmentt enrollment = new VoterEnrollmentt();
            enrollment.CityId = CityId;
            enrollment.StateId = StateId;
            enrollment.ConstituencyId = ConstituencyId;
            enrollment.EnrollerName = EnrollerName;
            enrollment.WardNumberId = WardNumberId;
            enrollment.Email = Email;
            enrollment.DOB = DOB;
            enrollment.FatherName = FatherName;
            enrollment.PhoneNumber = PhoneNumber;
            enrollment.EnrollmentNumber = EnrollNumber;
            enrollment.DateCreated = DateTime.Now;
            _context.Update(enrollment);
            _context.SaveChanges();
            SendEmail(enrollment.Email, enrollment.EnrollmentNumber, enrollment.EnrollerName);
            //ViewBag.EnrollNumber = EnrollNumber;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(enrollment.EnrollmentNumber);
            //return Json(enrollment.EnrollmentNumber);
            return json;
            //return Json(enrollment.EnrollmentNumber);
            //return "";

        }

        //[HttpGet("[action]")]
        //public string GetEnrollmentNumber(VoterEnrollmentt enrollment)
        //{
        //    string EnrollNumber = generateEnrollmentNumber();
        //    enrollment.EnrollmentNumber = EnrollNumber;
        //    enrollment.DateCreated = DateTime.Now;
        //    _context.Update(enrollment);
        //    _context.SaveChanges();
        //    SendEmail(enrollment.Email, enrollment.EnrollmentNumber, enrollment.EnrollerName);
        //    //ViewBag.EnrollNumber = EnrollNumber;
        //    string json = Newtonsoft.Json.JsonConvert.SerializeObject(enrollment.EnrollmentNumber);
        //    //return Json(enrollment.EnrollmentNumber);
        //    return json;

        //}

        private string generateEnrollmentNumber()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        private void SendEmail(string emailId, string EnrollmentNumber, string name)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("testkelltonprogram@gmail.com");
                    mail.To.Add(emailId);
                    mail.Subject = "Your Enrollment ID";
                    mail.Body = "Hi " + name + ", Your Enrollment ID is " + EnrollmentNumber;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("testkelltonprogram@gmail.com", "TestKellton@123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

using DBTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace DAL
{
    public class DatabaseOperations
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(DatabaseOperations));
        private readonly DatabaseContext _context;

        public DatabaseOperations(DatabaseContext context)
        {
            _context = context;
        }

        public List<States> GetStatesByList()
        {
            try
            {
                List<States> stateList = new List<States>();

                // ------- Getting Data from Database Using EntityFrameworkCore -------
                stateList = (from state in _context.States
                             select state).ToList(); // For getting list of states from dbcontext

                // ------- Inserting Select Item in List -------
                stateList.Insert(0, new States { StateId = 0, StateName = "Select" });
                log.Debug("test");
                //throw new Exception();
                //throw new DivideByZeroException();
                return stateList;
            }
            catch (Exception ex)
            {
                log.Error("Error occourred in GetStates Function on" + DateTime.Now + ":" + ex.Message);
                //throw ex;
                return null;
            }
        }

        public List<City> GetCityByList(int StateId)
        {
            try
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
            catch (Exception ex)
            {
                log.Error("Error occured in GetCity Function on" + DateTime.Now + ":" + ex.Message);
                return null;
            }
        }

        public List<Constituency> GetConstituenciesByList(int CityId)
        {
            try
            {
                List<Constituency> constituencyList = new List<Constituency>();

                // ------- Getting Data from Database Using EntityFrameworkCore -------
                constituencyList = (from constituency in _context.Constituency
                                    where constituency.CityId == CityId
                                    select constituency).ToList();

                // ------- Inserting Select Item in List -------
                constituencyList.Insert(0, new Constituency { ConstituencyId = 0, ConstituencyName = "Select" });


                return constituencyList;
            }
            catch (Exception ex)
            {
                log.Error("Error accourred in GetConstituency Function on" + DateTime.Now + ":" + ex.Message);
                return null;
            }
        }

        public List<WardNo> GetWardByList(int constituencyId)
        {
            try
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
            catch (Exception ex)
            {
                log.Error("Error accourred in GetWard Function on" + DateTime.Now + ":" + ex.Message);
                return null;
            }
        }

        public string GetEnrollmentNumberByParams(int StateId, int CityId, string PhoneNumber, int ConstituencyId, int WardNumberId, string EnrollerName, string Email, DateTime DOB, string FatherName)
        {
            try
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
            catch
            {
                log.Error("Error accourred in GetEnrollmentNumber Function on" + DateTime.Now);
                return "";
            }
        }
       
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
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        log.Error("Error accourred in Send Email Function on " + DateTime.Now + ":" + ex.Message);
                    }
                }
            }
            
        }
    }
}

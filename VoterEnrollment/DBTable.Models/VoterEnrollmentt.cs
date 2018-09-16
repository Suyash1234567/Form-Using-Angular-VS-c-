using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DBTable.Models
{
    public class VoterEnrollmentt
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int ConstituencyId { get; set; }
        public int WardNumberId { get; set; }
        public string EnrollerName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string EnrollmentNumber { get; set; }
    }
}

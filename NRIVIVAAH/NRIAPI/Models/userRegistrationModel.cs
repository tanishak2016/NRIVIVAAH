using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NRIAPI.Models
{
    public class userRegistrationModel
    {
       [Required]
        public String Email { get; set; }

        
        [DataType(DataType.Password)]
        [Required]
        public String Password { get; set; }

        [Required]
        public String CreateProfileFor { get; set; }

        [Required]
        public String DateOfBirth { get; set; }

        [Required]
        public String  Height { get; set; }

        [Required]
        public String  MaritalStatus { get; set; }

        [Required]
        public String MotherTongue { get; set; }

        [Required]
        public String Religion { get; set; }


        [Required]
        public String City { get; set; }

        [Required]
        public String PinCode { get; set; }

        [Required]
        public String MobileNumber { get; set; }

        public Boolean? IsActive { get; set; }

        public Boolean? IsVerified { get; set; }

        public Boolean? IsPaid { get; set; }

        public DateTime? CreatedAt { get; set; }

        public String Gender { get; set; }

        public String ProfilePicture { get; set; }
        public String OTP { get; set; }
    }
}
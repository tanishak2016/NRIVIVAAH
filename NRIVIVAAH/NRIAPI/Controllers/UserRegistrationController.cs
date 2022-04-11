using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NRIAPI.Models;
using BusinessLayer;


namespace NRIAPI.Controllers
{

    
   // [Route("api/[controller]/[action]")]
    public class UserRegistrationController : ApiController
    {


        String OTP = string.Empty;


        private static DKEntities context;
        public UserRegistrationController()
        {
            context = new DKEntities();
        }

        [HttpPost]
        public IHttpActionResult SaveUserRegistration(userRegistrationModel model)
        {            

            try
            {
                if (ModelState.IsValid)
                {
                      GenerateOTP();
                   //using(var context=new DKEntities())
                   // {
                       
                   //     context.userRegistrations.Add(new userRegistration() { 
                   //     Email=model.Email,
                   //     Password=model.Password,
                   //     CreateProfileFor=model.CreateProfileFor,
                   //     DateOfBirth=model.DateOfBirth,
                   //     Height=model.Height,
                   //     MaritalStatus=model.MaritalStatus,
                   //     MotherTongue=model.MotherTongue,
                   //     Religion=model.Religion,
                   //     City=model.City,
                   //     PinCode=model.PinCode,
                   //     MobileNumber=model.MobileNumber,
                   //     IsActive=false,
                   //     IsVerified=false,
                   //     IsPaid=false,
                   //     CreatedAt=DateTime.Now,
                   //     Gender=model.Gender,
                   //     ProfilePicture=model.ProfilePicture,
                   //     OTP=OTP                      
                       
                   //     });
                   //      context.SaveChanges();
                   // }


                }

            }

            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return Ok();

        }

        [HttpPost]
        public IHttpActionResult LoginUser(userRegistrationModel model)
        {           
            String message = string.Empty;           

            if (ModelState.IsValid)
            {               
                   var  isValid = context.userRegistrations.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                    if(isValid!=null)
                    {
                        return  Ok(new ResponseFormat {
                        IsSuccess = true,
                        Status = true,
                        ResponseMessage = "Login success",
                        ResponseData = isValid });
                    }
                    else
                    {
                        return Ok(new ResponseFormat {
                        IsSuccess = false, 
                        Status = false,
                        ResponseMessage = "Login failed", ResponseData = { } });
                    }              

            }
            return Ok(new ResponseFormat { 
            IsSuccess = false,
            Status = false,
            ResponseMessage = "Login failed", ResponseData = { } });

        }
       
        public IHttpActionResult  GenerateOTP()
        {

            string strrandom = string.Empty;
            char[] charArr = "0123456789".ToCharArray();
            Random objran = new Random();
            for(int i = 0; i < 4; i++)
            {
                int pos = objran.Next(1, charArr.Length);
                if (!strrandom.Contains(charArr.GetValue(pos).ToString())) strrandom += charArr.GetValue(pos);
                else i--;
            }

           using(var context=new DKEntities())
            {
               
                context.userRegistrations.Add(new userRegistration()
                {
                    IsActive = false,
                    IsVerified = false,
                    IsPaid = false,
                    CreatedAt = DateTime.Now,
                    OTP = strrandom

                });
                context.SaveChanges();

            }
            return Ok();
             
            
        }

        [HttpPost]
        public IHttpActionResult VerifyOTP(String clientOPT)
        {

            var query = context.userRegistrations.Select(a => a.OTP).ToList();           
            
           if(query.Contains(clientOPT))
            {
                var userData = context.userRegistrations.Where(otp => otp.OTP == clientOPT).SingleOrDefault();                
            }
            else
            {
                return Ok("opt not match");
            }
           
            return Ok();
               


        }


        







    }
}

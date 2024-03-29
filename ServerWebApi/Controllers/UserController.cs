﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;
using Newtonsoft.Json;
using Dal;
using Entity2;
using System.Net;

namespace ServerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IuserBll UserBll;
        public UserController(IuserBll UserBll)
        {
            this.UserBll = UserBll;
        }
        //get-שליפה
        // GET: api/<UserController>
        [HttpGet]
        public List<CustomerDto> Get()
        {
            return UserBll.GetUserList();
        }

        // GET api/<UserController1>/5
        [HttpGet("/api/user/GetUserById/{id}")]
        public CustomerDto Get(int id)
        {
            return UserBll.GetUser(id);
        }
        // GET api/<UserController1>/5
        [HttpGet("/api/user/GetUserByTz/{id}")]
        public CustomerDto Get(string id)
        {
            return UserBll.GetUserByTz(id);
        }

        [HttpGet("/api/user/GetUserByMail/{mail}")]
        public CustomerDto GetUserByMail(string mail)
        {
            return UserBll.GetUserByMail(mail);
        }


        // GET api/<UserController1>/5
        [HttpGet("GetUserByTzAndPass/{id}/{password}")]
        public CustomerDto GetUserAndPassword(string id, string password)
        {
            return UserBll.GetUserAndPassword(id, password);
        }

        //post-הוספה
        // POST api/<UserController1>
        [HttpPost("/api/User/Connect/")]
        public CustomerDto Post([FromBody] Connect c)
        {
            return UserBll.GetUserAndPassword(c.Id, c.Password);
        }
        [HttpPost("/api/User/ConnectMail/")]
        public CustomerDto GetMailAndPassword([FromBody] MailAndPassword dto)
        {

            return UserBll.GetMailAndPassword(dto.Password, dto.Mail);

        }

        [HttpPost("/api/User/SendEmailOnly/{to}/{name}/{subject}/{text}")]
        public void SendEmailOnly(string to, string name, string subject, string text)
        {

            UserBll.SendEmailOnly(to, name, subject, text);
        }


        [HttpPost]
        public CustomerDto Post([FromBody] object b)
        {
            try
            {
                // המרת ה-object לסוג UserData
                var userData = JsonConvert.DeserializeObject<Customer>(b.ToString());

                // כעת תוכל לגשת לערכים באופן קונקרטי
                string name = userData.Name;
                string email = userData.Mail;
                string address = userData.Address;
                string password = userData.Password;
                string toun = userData.Toun;
                string phon = userData.Phon;
                string tz = userData.Tz;
                DateTime dateBirth = userData.DateBirth != null ? (DateTime)userData.DateBirth : DateTime.Now;
                //   string fileContent = File.ReadAllText(userData.Pic);

                //string pic = ((string)userData.Pic);
                // string pic = " ";

                bool isManager = userData.IsManager;
                bool status = true;
                bool readTerms = true;

                CustomerDto dto = new CustomerDto()
                {
                    Mail = email,
                    Name = name,
                    Address = address,
                    Password = password,
                    Toun = toun,
                    Phon = phon,
                    Tz = tz,
                    DateBirth = dateBirth,
                    Pic = "",
                    IsManager = isManager,
                    Status = status,
                    ReadTerms = readTerms,

                };


                return UserBll.AddUser(dto);


            }
            catch (JsonException ex)
            {
                return null;
            }
            //UserBll.AddUser(b);
        }



        //put-עדכון
        // PUT api/<UserController1>/5
        //[HttpPut("UpdateUser/{id}")]
        //public void Put(int id, [FromBody] CustomerDto b)
        //{
        //    UserBll.UpdateUser(b, id);
        //}

        //[HttpPut("ChangePassword")]
        //public void Put([FromBody] CustomerDto id)
        //{
        //    UserBll.ChangePassword(id);
        //}

        [HttpPut("UpdateUser/{id}")]
        public void UpdateUser(int id, [FromBody] object b)
        {
            var userData = JsonConvert.DeserializeObject<Customer>(b.ToString());

            try
            {
                // המרת ה-object לסוג UserData
                DateTime dateBirth =DateTime.Now;
                bool status=false ;
                string pic="";
                string name = "";
                string tz="";
                string toun="";
                string phon= "";
                string address="";
                string password = "";
                string mail="";
                bool isManager=false;

                if (userData.Name == "change pic")
                {
                     pic = userData?.Pic;
                     name = userData?.Name;
                }
                else
                {
                     dateBirth = userData.DateBirth != null ? (DateTime)userData.DateBirth : DateTime.Now;
                     status = (bool)userData?.Status;
                     pic = userData?.Pic;
                     name = userData?.Name;
                     tz = userData?.Tz;
                     toun = userData?.Toun;
                     phon = userData?.Phon;
                     address = userData?.Address;
                     password = userData?.Password;
                     mail = userData?.Mail;
                     isManager = (bool)userData?.IsManager;
                }



                CustomerDto dto = new CustomerDto()
                {
                    Pic = pic,
                    Name = name,
                    Address = address,
                    Password = password,
                    Toun = toun,
                    Phon = phon,
                    Tz = tz,
                    Mail = mail,
                    IsManager = isManager,
                    Status = status,
                };


                UserBll.UpdateUser(dto, id);


            }
            catch (JsonException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [HttpPut("ChangePassword")]
        public void ChangePassword([FromBody] MailAndPassword k)
        {
            CustomerDto dto = new CustomerDto()
            {
                Mail = k.Mail,
                Password = k.Password,
            };

            try
            {
                UserBll.ChangePassword(dto);

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //delete-מחיקה
        // DELETE api/<UserController1>/5

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            UserBll.DeleteUser(id);
        }
    }
}

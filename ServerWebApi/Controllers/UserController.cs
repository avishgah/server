using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bll;
using Dto;
using Newtonsoft.Json;
using Dal;
using Entity2;

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

                bool isManager = false;
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
        public IActionResult UpdateUser(int id, [FromBody] CustomerDto b)
        {
            try
            {
                UserBll.UpdateUser(b, id);
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating user: {ex.Message}");
            }
        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword([FromBody] CustomerDto id)
        {
            try
            {
                UserBll.ChangePassword(id);
                return Ok("Password changed successfully");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating user: {ex.Message}");
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

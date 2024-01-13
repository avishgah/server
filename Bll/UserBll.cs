using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal;
using Entity2;
using GemBox.Spreadsheet;
using MailKit.Net.Smtp;
using MimeKit;



namespace Bll
{
    public class UserBll : IuserBll
    {
        IUserDal UserDal;

        IMapper mapper;

        public UserBll(IUserDal b, IMapper m)
        {
            UserDal = b;
            mapper = m;
        }
        List<CustomerDto> CustomerList;

        public CustomerDto AddUser(CustomerDto b)
        {
            var userList = mapper.Map<List<CustomerDto>>(UserDal.GetUserList());

            // Check if Tz or Mail already exists in the user list
            foreach (var customer in userList)
            {
                if (customer.Tz == b.Tz || customer.Mail == b.Mail)
                {
                    return null;
                }
            }

            // If Tz and Mail are unique, proceed to add the user
            return mapper.Map<CustomerDto>(this.UserDal.AddUser(mapper.Map<Customer>(b)));
        }

        public void DeleteUser(int id)
        {
            this.UserDal.DeleteUser(id);
        }

        public CustomerDto GetUser(int id)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUser(id));
        }
        public CustomerDto GetUserByMail(string mail)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUserByMail(mail));
        }

        public CustomerDto GetUserByTz(string id)
        {
            return mapper.Map<CustomerDto>(this.UserDal.GetUserByTz(id));
        }

        public CustomerDto GetUserAndPassword(string id, string pas)
        {
            return mapper.Map<CustomerDto>(UserDal.GetUserAndPassword(id, pas));
        }
        public CustomerDto GetMailAndPassword(string id, string mail)
        {
            return mapper.Map<CustomerDto>(UserDal.GetMailAndPassword(id, mail));
        }

        public List<CustomerDto> GetUserList()
        {

            return mapper.Map<List<CustomerDto>>(UserDal.GetUserList());
        }
        public void ChangePassword(CustomerDto user)
        {
            UserDal.ChangePassword(mapper.Map<Customer>(user));
        }

        public void UpdateUser(CustomerDto b, int ID)
        {
            UserDal.UpdateUser(mapper.Map<Customer>(b), ID);
        }


        public void SendEmailOnly(string to, string name, string subject, string text)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Pedal", "pedalsite@gmail.com"));
            email.To.Add(new MailboxAddress(name, to));

            email.Subject = subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"שלום {name}," +
              $"\n" + // Adding a new line for better readability
              $"\tPEDAL אנו מודים לך שבחרת ברשת " +
              $"\n" + // Adding a new line for better readability
              $"\tבמקרה של תקלה או שגיאה פנו אל שירות הלקוחות *2670"
        };


            using (var s = new SmtpClient())
            {
                s.CheckCertificateRevocation = false;
                s.Connect("smtp.gmail.com", 587, false);
                s.Authenticate("pedalsite@gmail.com", "rssvdyxcigstnard");
                s.Send(email);
                s.Disconnect(true);
            }
        }


    }
}

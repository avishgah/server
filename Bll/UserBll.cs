using Dto;

using AutoMapper;
using Dal;
using Entity2;
using MimeKit;
using System.Reflection;
using System.Net.Mail;
using System.Net.Mime;
using Org.BouncyCastle.Utilities;

//using Newtonsoft.Json;

namespace Bll
{
    public class UserBll : IuserBll
    {
        IUserDal UserDal;

        IOrderDal OrderDal;


        IOrderBikeDal OrderBikeDal;

        IMapper mapper;



        List<Order> lst = new List<Order>();
        List<OrderBike> lst3 = new List<OrderBike>();


        public UserBll(IUserDal b, IMapper m, IOrderDal orderDal, IOrderBikeDal orderBikeDal)
        {
            UserDal = b;
            mapper = m;
            OrderDal = orderDal;
            OrderBikeDal = orderBikeDal;
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


        public void SendEmailOnly(string to, string name, string station, string text)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Pedal", "pedalsite@gmail.com"));
            email.To.Add(new MailboxAddress(name, to));

            if (text == "קבלה")
            {

                CustomerDto cust = mapper.Map<CustomerDto>(this.UserDal.GetUserByMail(to));

                List<OrderDto> orders = mapper.Map<List<OrderDto>>(OrderDal.GetOrderList()).Where(x => x.IdCust == cust.Id && x.IsPay != true && x.DatePay != null).ToList();

                List<OrderBikeDto> AllBikes = mapper.Map<List<OrderBikeDto>>(OrderBikeDal.GetOrderBikeList());
                List<TimeSpan> calcTime = new List<TimeSpan>();

                DateTime currentDate = DateTime.Now;

                // הצגת התאריך בפורמט המבוקש
                string formattedDate = currentDate.ToString("dddd, dd.MM.yyyy");
                Console.WriteLine(formattedDate);


                //List<Order> lst = new List<Order>();

                string data1 = "";
                int id = 1;
                foreach (OrderDto b in orders)
                {
                    //  data1 += $"<tr>{b.Code}</tr>";
                    AllBikes.Where(x => x.IdPay == b.Id).ToList().ForEach(order2 =>
                    {
                        //int time2 = o.DateStart.Value;
                        DateTime datestart = order2.DateStart.Value;
                        DateTime dateend = order2.DateEnd.Value;
                        TimeSpan span = dateend.Subtract(datestart);
                        string formattedTime = $"{(int)span.TotalHours:D2}:{span.Minutes:D2}:{span.Seconds:D2}";

                        data1 += $"<tr><td><p>{id++}</p></td><td><p>{order2.DateStart}</p></td><td><p>{order2.DateEnd}</p></td> <td><p>{formattedTime}</p></td><td><p>{(int)order2.Sum}</p></td></tr>";

                    });
                    b.IsPay = true;
                    OrderDal.UpdateOrder(mapper.Map<Order>(b), b.Id);

                }



                int amount = (int)orders.Sum(x => x.EndSum);



                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string pat = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));
                string full = Path.Combine(pat, "html/htmlpage.html");
                string htmlBody = "";
                using (var reader = new StreamReader(full))
                {
                    htmlBody = reader.ReadToEnd();
                }
            ;
                htmlBody = htmlBody.Replace("{body}", data1);
                htmlBody = htmlBody.Replace("{amount}", amount.ToString());
                htmlBody = htmlBody.Replace("{date}", formattedDate);


                email.Subject = "  קבלה עבור שימוש ב - PEDAL!";


                string attachmentPath = Path.Combine(pat, "img/kiki.png");
                byte[] dataread = File.ReadAllBytes(attachmentPath);

                string imgData = Convert.ToBase64String(dataread);
                htmlBody = htmlBody.Replace("{imgData}", imgData);


                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;

                email.Body = bodyBuilder.ToMessageBody();



             
            }
            else
            {
                email.Subject = "סיכום הזמנה";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = station.ToString()
                };


            }
            using (var s = new MailKit.Net.Smtp.SmtpClient())
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


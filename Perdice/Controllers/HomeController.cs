using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Perdice.Models;
using System.Diagnostics;
using System.Net.Mail;

namespace Perdice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _config;

		public HomeController(ILogger<HomeController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
		}

		public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
		}
		//[HttpPost]
		//public ActionResult Contact(Contact obj)
		//{
		//	ViewBag.Contact = "";
		//	string ToEmail, SubJect, cc, Bcc;
		//	cc = "";
		//	Bcc = "";
		//	ToEmail = _config["To"];
		//	SubJect = "New Query From Customer";
		//	string BodyEmail = System.IO.File.ReadAllText(Server.MapPath("~/Template") + "\\" + "contact.txt");
		//	DateTime dateTime = DateTime.UtcNow.Date;
		//	BodyEmail = BodyEmail.Replace("#Date#", dateTime.ToString("dd/MMM/yyyy"))
		//		.Replace("#Name#", obj.Name.ToString())
		//		.Replace("#lastName#", obj.Name.ToString())
		//		.Replace("#Email#", obj.Email.ToString())
		//		.Replace("#Phone#", obj.Phone.ToString())
		//		.Replace("#Message#", obj.Message.ToString());
		//	try
		//	{
		//		MailMessage mail = new MailMessage();
		//		mail.To.Add(ToEmail);
		//		mail.From = new MailAddress(_config["From"]);
		//		mail.Subject = SubJect;
		//		string Body = BodyEmail;
		//		mail.Body = Body;
		//		mail.IsBodyHtml = true;

		//		SmtpClient smtp = new SmtpClient();
		//		smtp.UseDefaultCredentials = false;
		//		smtp.Port = int.Parse(_config["SmtpPort"]);
		//		smtp.Host = _config["SmtpServer"]; //Or Your SMTP Server Address
		//		smtp.Credentials = new System.Net.NetworkCredential
		//			 (_config["From"], _config["Password"]);
		//		//Or your Smtp Email ID and Password
		//		smtp.EnableSsl = false;

		//		smtp.Send(mail);
		//		ViewBag.Contact = "Your Query is received. Our support department contact you soon.";
		//	}
		//	catch (Exception ex)
		//	{
		//		ViewBag.Contact = "";
		//	}
		//	return View();
		//}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
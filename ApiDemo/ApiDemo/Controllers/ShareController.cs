using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;

namespace ApiDemo.Controllers
{
    public class ShareController : ApiController
    {
        // POST api/questions
        public IHttpActionResult Share(string destination_email, string content_url)
        {
            if (!ModelState.IsValid)
                return BadRequest("Bad Request. Either destination_email not valid or empty content_url");
            
            
            MailMessage email = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "SomeHost";
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("SomeUser", "SomePass");
            email.From = new MailAddress("SomeEmail");
            email.To.Add(new MailAddress(destination_email));
            email.Subject = "SomeSubject";
            email.Body = "SomeBody";
            client.Send(email);

            return Ok();
        }
    }
}

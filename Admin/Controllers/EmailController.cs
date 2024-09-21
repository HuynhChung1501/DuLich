using Dulich.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Travel.Application.InterfaceService;

namespace Travel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : BaseController
    {
        private readonly IEmailSenderService _emailSender;

        public EmailController(IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost]
        [Route("SendEmail")]
        public async Task<IActionResult> SendEmail()
        {
            // làm thêm table Acount để phục vụ cho gửi email qua tài khoản admin
            //chỗ này làm thêm gửi email đến các tài khoản có quyền là admin

            string toEmail = "chung.tq.9999@gmail.com";
            string subject = "";
            string htmlMessage = "<p>This is the body of the email.</p>";

            await _emailSender.SendEmailAsync(toEmail, subject, htmlMessage);
            return JSSuccessResult("Gửi email thành công");
        }
    }
}

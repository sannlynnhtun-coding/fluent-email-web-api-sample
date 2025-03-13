using FluentEmail.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentEmailWebApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailController(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] EmailRequestModel requestModel)
        {
            var response = await _fluentEmail
                .To(requestModel.toEmail)
                .Subject(requestModel.subject)
                .Body(requestModel.content)
                .SendAsync();
            return Ok(response);
        }
    }

    public record EmailRequestModel(string toEmail, string subject, string content);
}

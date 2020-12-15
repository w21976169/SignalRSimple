using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace BizServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<MessageHub> _messageHub;

        public HomeController(ILogger<HomeController> logger, IHubContext<MessageHub> messageHub)
        {
            _logger = logger;
            _messageHub = messageHub;
        }

        [HttpPost]
        [Route("send")]
        public async Task SendTestMessageToAllClients()
        {
            await _messageHub.Clients.All.SendAsync("ReceiveMessage", new
            {
                Title = "this is a title!",
                Content = "this is a content"
            });
        }
    }
}
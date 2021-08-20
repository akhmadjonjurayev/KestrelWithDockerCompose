using GrpcExtention;
using GrpcServiseFirst;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xacton.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public async Task<string> GetValues([FromQuery]string value = "Akhmadjon")
        {
            var GRPCConnection = await GrpcCallerService.CallService("http://localhost:6000", async channel =>
            {
                var client = new AstroilServiceGrpc.AstroilServiceGrpcClient(channel);
                var result = await client.SayHelloAsync(new HelloRequest() { Name = value });
                return result.Message;
            });
            return GRPCConnection;
        }
    }
}

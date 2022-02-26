using Accemo.GrpcService;
using GrpcExtention;
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
        //[HttpGet]
        //public async Task<string> GetValues([FromQuery]string value = "Akhmadjon")
        //{
        //    var GRPCConnection = await GrpcCallerService.CallService("http://localhost:6000", async channel =>
        //    {
        //        var client = new AstroilServiceGrpc.AstroilServiceGrpcClient(channel);
        //        var result = await client.SayHelloAsync(new GrpcServiseFirst.HelloRequest() { Name = value });
        //        return result.Message;
        //    });
        //    return GRPCConnection;
        //}
        [HttpGet]
        public async Task<IActionResult> GetGrpc([FromQuery] string value = "Akhmadjon")
        {
            var GRPCConnection = await GrpcCallerService.CallService("http://accemo:4000", async channel =>
             {
                 var client = new AccemoServieGrpc.AccemoServieGrpcClient(channel);
                 var result = await client.SayHelloAsync(new Accemo.GrpcService.HelloRequest() { Name = $"Salom {value}" });
                 return result.Message;
             });
            return Ok(new { IsSuccess = true, Message = "All Done !", Data = GRPCConnection });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accemo.GrpcService;
using Grpc.Core;
using GrpcExtention;
using GrpcServiseFirst;
using HelloReply = GrpcServiseFirst.HelloReply;
using HelloRequest = GrpcServiseFirst.HelloRequest;

namespace Astriol.Controllers
{
    public class AstriolGrpcBaseSerice : AstroilServiceGrpc.AstroilServiceGrpcBase
    {
        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var data = new BaseAstroilService();
            var result = await data.GetAccemo(request.Name);
            return new HelloReply() { Message = result };
        }
    }
    public class BaseAstroilService
    {
        public async Task<string> GetAccemo(string hello)
        {
            var GRPCConnection = await GrpcCallerService.CallService("http://localhost:4000", async channel =>
            {
                var client = new AccemoServieGrpc.AccemoServieGrpcClient(channel);
                var result = await client.SayHelloAsync(new Accemo.GrpcService.HelloRequest() { Name = hello });
                return result.Message;
            });
            return GRPCConnection;
        }
    }
}

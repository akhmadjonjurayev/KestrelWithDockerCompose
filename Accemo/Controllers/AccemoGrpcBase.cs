using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accemo.GrpcService;
using Grpc.Core;
using GrpcExtention;
using YakhyoGrpc;
using HelloReply = Accemo.GrpcService.HelloReply;
using HelloRequest = Accemo.GrpcService.HelloRequest;

namespace Accemo.Controllers
{
    public class AccemoGrpcBase : AccemoServieGrpc.AccemoServieGrpcBase
    {
        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return new HelloReply() { Message = $"Salom! { await GetFromYakhyo(request.Name)}" };
        }

        public async Task<string> GetFromYakhyo(string message)
        {
            var GRPCConnection = await GrpcCallerService.CallService("http://localhost:6000", async channel =>
             {
                 var client = new YakhyoServiceGrpc.YakhyoServiceGrpcClient(channel);
                 var result = await client.SayHelloAsync(new YakhyoGrpc.HelloRequest() { Name = message });
                 return result.Message;
             });
            return GRPCConnection;
        }
    }
}

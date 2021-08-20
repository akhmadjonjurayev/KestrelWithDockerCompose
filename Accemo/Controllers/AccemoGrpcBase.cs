using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accemo.GrpcService;
using Grpc.Core;

namespace Accemo.Controllers
{
    public class AccemoGrpcBase : AccemoServieGrpc.AccemoServieGrpcBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply() { Message = $"Salom! {request.Name}"});
        }
    }
}

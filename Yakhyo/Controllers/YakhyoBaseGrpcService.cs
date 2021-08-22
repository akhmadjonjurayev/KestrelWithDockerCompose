using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YakhyoGrpc;

namespace Yakhyo.Controllers
{
    public class YakhyoBaseGrpcService : YakhyoServiceGrpc.YakhyoServiceGrpcBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply() { Message = $"Hello From Yakho to {request.Name}" });
        }
    }
}

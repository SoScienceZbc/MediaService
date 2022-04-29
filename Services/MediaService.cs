using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto;
using SoScienceMediaService.MediaClasses;
using Grpc.Core;

namespace SoScienceMediaService.Services
{
    public class MediaService : RemoteMediaService.RemoteMediaServiceBase
    {
        private MediaManager mem = new MediaManager();

        public override Task<MediaReply> SendMedia(MediaRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            MediaReply vr = mem.SendMedia(request).Result;
            Console.WriteLine("MediaReply: " + vr.ReplySuccessfull);
            return Task.FromResult(vr);
        }
    }
}

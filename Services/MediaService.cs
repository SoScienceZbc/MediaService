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

        public override Task<VideoReply> SendVideo(VideoRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host}\nMethod: {context.Method}");
            return mem.SendMedia(request);
        }
    }
}

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
        private MediaManager mediaHandler = new MediaManager();

        public override Task<MediaReply> SendMedia(MediaRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            MediaReply vr = mediaHandler.SendMedia(request).Result;
            Console.WriteLine("MediaReply: " + vr.ReplySuccessfull);
            return Task.FromResult(vr);
        }
        public override Task<MediaRequests> GetMedias(UserDbInformation user, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            return mediaHandler.GetMedias(user);
        }
    }
}

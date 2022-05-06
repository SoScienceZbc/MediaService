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
        public override Task<MediaRequests> GetMedias(ProjectInformation project, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            return mediaHandler.GetMedias(project);
        }
        public override Task<RetrieveMediaReply> RetrieveMedia(RetrieveMediaRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            return mediaHandler.RetrieveMedia(request);
        }
        public override Task<MediaReply> DeleteMedia(RetrieveMediaRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            return mediaHandler.DeleteMedia(request);
        }
        public override Task<MediaReply> UpdateMedia(ChangeTitleRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Host:{context.Host} called Method:{context.Method}");
            return mediaHandler.UpdateMedia(request);
        }
    }
}

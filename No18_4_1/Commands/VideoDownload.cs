namespace No18_4_1.Commands
{
    internal class VideoDownload : AbstractVideoCommand
    {
        public VideoDownload(VideoSaver videoSaver) : base(videoSaver)
        {
        }

        public override void Execute() =>
            VideoSaver.DownloadVideo();
    }
}

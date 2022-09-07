namespace No18_4_1.Commands
{
    internal class VideoSearch : AbstractVideoCommand
    {
        public VideoSearch(VideoSaver videoSaver) : base(videoSaver)
        {
        }

        public override void Execute() =>
            VideoSaver.SearchVideo();
    }
}
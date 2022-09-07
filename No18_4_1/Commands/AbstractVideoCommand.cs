namespace No18_4_1.Commands
{
    internal abstract class AbstractVideoCommand : ICommand
    {
        public VideoSaver VideoSaver { get; set; }

        protected AbstractVideoCommand(VideoSaver videoSaver) =>
            VideoSaver = videoSaver;

        public abstract void Execute();
    }
}
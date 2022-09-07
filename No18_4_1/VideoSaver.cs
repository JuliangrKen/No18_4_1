using YoutubeExplode.Videos;
using YoutubeExplode;
using YoutubeExplode.Converter;

namespace No18_4_1
{
    internal class VideoSaver
    {
        public string Url { get; }
        public Video? Video { get; private set; }

        private readonly YoutubeClient youtubeClient = new();

        public VideoSaver(string url) =>
            Url = url;

        public void SearchVideo() =>
            Video = youtubeClient.Videos.GetAsync(Url).Result;

        public void DownloadVideo()
        {
            var videoPath = $@"{Environment.CurrentDirectory}\{Video?.Title}.mp4";
            youtubeClient.Videos.DownloadAsync(Url, videoPath, builder => builder.SetPreset(ConversionPreset.UltraFast)).GetAwaiter().GetResult();
        }
    }
}
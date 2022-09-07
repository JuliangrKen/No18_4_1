using No18_4_1;
using No18_4_1.Commands;

const string exitKeyword = "exit";

while (true)
{
    var input = Input("Введите полный URL видео с YouTube");
    
    if (input == exitKeyword) return;

    try
    {
        DownloadVideo(input);
    }
    catch (ArgumentException)
    {
        Console.WriteLine("Некорректный Url");
    }

    Console.WriteLine();
    Console.WriteLine("Чтобы выйти из приложения, введите exit");
}

static void DownloadVideo(string url)
{
    var videoSaver = new VideoSaver(url);
    var commandSender = new CommandSender();

    ICommand search = new VideoSearch(videoSaver);
    commandSender.SetCommand(search);
    commandSender.Started += () => Console.WriteLine("Начат поиск видео...");
    commandSender.Completed += () => Console.WriteLine($"Видео было найдено. \nНазвание: {videoSaver.Video?.Title}\nОписание:\n{videoSaver.Video?.Description}\n");
    commandSender.Execute();

    ICommand download = new VideoDownload(videoSaver);
    commandSender.SetCommand(download);
    commandSender.ClearEvents();
    commandSender.Started += () => Console.WriteLine("Установка началась.");
    commandSender.Completed += () => Console.WriteLine($"Видео было загружено");
    commandSender.Execute();
}

static string Input(string text)
{
    Console.WriteLine(text);
    Console.Write("Ввод: ");
    return Console.ReadLine() ?? "";
}
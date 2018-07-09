using AngleSharp;

namespace ReKreator.HtmlParser.Config
{
    public interface IParserConfigProvider
    {
        Url GetConcertUrl();
        Url GetSpectacleUrl();
        Url GetMovieUrl();
    }
}
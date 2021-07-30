namespace WeatherApp
{
    public interface IBreakApplicationService
    {
        bool IsApplicationBroken { get; }

        void BreakMyApplication();
    }
}

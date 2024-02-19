namespace SecurityAPI
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public record Student
    {
        public string Name { get; init; }
        public int Age { get; init; }
        public string Grade { get; init; }
    }
}

using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeUrl = "https://api.kanye.rest/";
            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            for (int i = 0; i < 5; i++)
            {

                var kanyeResponseJson = client.GetStringAsync(kanyeUrl).Result;

                var kanyeQuote = JObject.Parse(kanyeResponseJson).GetValue("quote").ToString();

                Console.WriteLine($"Kanye:{kanyeQuote}");



                var ronResponseJson = client.GetStringAsync(ronUrl).Result;

                var ronQuote = JArray.Parse(ronResponseJson);
                Console.WriteLine($"Ron: {ronQuote[0]}");
            }




            var appsettingsText = File.ReadAllText("appsettings.json");
            
            var apiKey = JObject.Parse(appsettingsText)["key"].ToString();

            //Console.WriteLine("Please enter your zip code:");

            //var zip = Console.ReadLine();

           // var weatherUrl =
                //$"https://api.openweathermap.org/data/2.5/weather?zip={}&appid={apiKey}"; 
                
                Console.WriteLine("What is the weather like today in Bentonville, AR?");
                
                //var weather = Console.ReadLine();
                
                var weatherUrl =
                    $"https://api.openweathermap.org/data/2.5/weather?lat=36.372852&lon=-94.208817&appid={apiKey}&units=imperial";
                
                
                var weatherResponseJson = client.GetStringAsync(weatherUrl).Result;
                
                
                var weatherNumber = JObject.Parse(weatherResponseJson)["main"]["temp"].ToString();

                var weatherTemp = Math.Round(double.Parse(weatherNumber));
                
                var weatherDescription = JObject.Parse(weatherResponseJson)["weather"][0]["description"].ToString();
                
                Console.WriteLine($"{weatherNumber} degrees Fahrenheit with {weatherDescription}!");
                
                


        }
    }
}

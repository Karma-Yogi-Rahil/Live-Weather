using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using static Live_Weather_Backend.WeatherParameter;

namespace Live_Weather_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WetherController : ControllerBase
    {
        private const string UnsplashAccessKey = "ZavuRrrDHaD5ycWIFV6wJ_y2V6mQYc9OUSbdnBsFF6Q";
        private const string UnsplashApiUrl = "https://api.unsplash.com/search/photos";

        [HttpGet("{location}")]
        public IActionResult GetWeather(string location)
        {
            var client = new RestClient("https://api.weatherapi.com/v1");
            var request = new RestRequest("/current.json");
            request.Method = Method.Get;
            request.AddParameter("key", "e192f46a67df43688af141008231507");
            request.AddParameter("q", location);
            RestResponse response = client.Execute(request);
            WeatherData weatherData = new WeatherData();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Handle successful response
                var content = response.Content;
                weatherData = JsonConvert.DeserializeObject<WeatherData>(content);

                var imageClient = new RestClient(UnsplashApiUrl);
                var imageRequest = new RestRequest();
                imageRequest.Method = Method.Get;
                imageRequest.AddParameter("query", $"{weatherData.Current.Condition.Text}");
                imageRequest.AddParameter("client_id", UnsplashAccessKey);

                var imageResponse = imageClient.Execute(imageRequest);
                try
                {
                    if (imageResponse.IsSuccessful)
                    {
                        var imageContent = imageResponse.Content;

                        PhotoInfo photoInfo = JsonConvert.DeserializeObject<PhotoInfo>(imageContent);

                        weatherData.BagroundImage = GetRandomPhotoId(photoInfo.Results);

                        // Set Content-Type header to application/json
                        Response.Headers.Add("Content-Type", "application/json");

                        // Return weather data as JSON
                        return Ok(weatherData);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }
            else
            {
                // Handle error response
            }

            // Return weather data as JSON
            return Ok(weatherData);
        }

        // ... (rest of your code)

        static string GetRandomPhotoId(List<Photo> photos)
        {
            // Check if the list is not empty
            if (photos != null && photos.Count > 0)
            {
                // Generate a random index within the range of the list
                Random random = new Random();
                int randomIndex = random.Next(0, photos.Count);

                // Return the ID of the randomly selected photo
                return photos[randomIndex].Urls.Full;
            }

            // Return null if the list is empty or null
            return null;
        }
    }
}

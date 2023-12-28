namespace Live_Weather_Backend
{
    public class WeatherParameter
    {
        public class Location
        {
            public string Name { get; set; }
            public string Region { get; set; }
            public string Country { get; set; }
            public double Lat { get; set; }
            public double Lon { get; set; }
            public string tz_id { get; set; }
            public long localtime_epoch { get; set; }
            public string Localtime { get; set; }
        }

        public class Condition
        {
            public string Text { get; set; }
            public string Icon { get; set; }
            public int Code { get; set; }
        }

        public class Current
        {
            public long last_updated_epoch { get; set; }
            public string last_updated { get; set; }
            public double temp_c { get; set; }
            public double temp_f { get; set; }
            public int is_day { get; set; }
            public Condition Condition { get; set; }
            public double wind_mph { get; set; }
            public double wind_kph { get; set; }
            public int wind_degree { get; set; }
            public string wind_dir { get; set; }
            public double pressure_mb { get; set; }
            public double pressure_in { get; set; }
            public double precip_mm { get; set; }
            public double precip_in { get; set; }
            public int humidity { get; set; }
            public int cloud { get; set; }
            public double feelslike_c { get; set; }
            public double feelslike_f { get; set; }
            public double vis_km { get; set; }
            public double vis_miles { get; set; }
            public float uv { get; set; }
            public double gust_mph { get; set; }
            public double gust_kph { get; set; }
            public AirQuality AirQuality { get; set; }
        }

        public class AirQuality
        {
            public double Co { get; set; }
            public double No2 { get; set; }
            public double O3 { get; set; }
            public double So2 { get; set; }
            public double Pm25 { get; set; }
            public double Pm10 { get; set; }
            public int UsEpaIndex { get; set; }
            public int GbDefraIndex { get; set; }
        }

        public class WeatherData
        {
            public Location Location { get; set; }
            public Current Current { get; set; }

            public string BagroundImage { get; set; }

            
        }







        public class PhotoInfo
        {
            public double Total { get; set; }
            public double TotalPages { get; set; }
            public List<Photo> Results { get; set; }
        }

        public class Photo
        {
            public string Id { get; set; }
            public string Slug { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime PromotedAt { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string Color { get; set; }
            public string BlurHash { get; set; }
            public string Description { get; set; }
            public string AltDescription { get; set; }
            public Urls Urls { get; set; }
            public Links Links { get; set; }
            public int Likes { get; set; }
            public bool LikedByUser { get; set; }
            public List<object> CurrentUserCollections { get; set; }
            public object Sponsorship { get; set; }
            public Dictionary<string, object> TopicSubmissions { get; set; }
            public User User { get; set; }
            public List<Tag> Tags { get; set; }
        }

        public class Urls
        {
            public string Raw { get; set; }
            public string Full { get; set; }
            public string Regular { get; set; }
            public string Small { get; set; }
            public string Thumb { get; set; }
            public string SmallS3 { get; set; }
        }

        public class Links
        {
            public string Self { get; set; }
            public string Html { get; set; }
            public string Download { get; set; }
            public string DownloadLocation { get; set; }
        }

        public class User
        {
            public string Id { get; set; }
            public DateTime UpdatedAt { get; set; }
            public string Username { get; set; }
            public string Name { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string TwitterUsername { get; set; }
            public string PortfolioUrl { get; set; }
            public string Bio { get; set; }
            public string Location { get; set; }
            public Links Links { get; set; }
            public ProfileImage ProfileImage { get; set; }
            public string InstagramUsername { get; set; }
            public int TotalCollections { get; set; }
            public int TotalLikes { get; set; }
            public int TotalPhotos { get; set; }
            public int TotalPromotedPhotos { get; set; }
            public bool AcceptedTos { get; set; }
            public bool ForHire { get; set; }
            public Social Social { get; set; }
        }

        public class ProfileImage
        {
            public string Small { get; set; }
            public string Medium { get; set; }
            public string Large { get; set; }
        }

        public class Social
        {
            public string InstagramUsername { get; set; }
            public string PortfolioUrl { get; set; }
            public string TwitterUsername { get; set; }
            public object PaypalEmail { get; set; }
        }

        public class Tag
        {
            public string Type { get; set; }
            public string Title { get; set; }
        }

    }
}

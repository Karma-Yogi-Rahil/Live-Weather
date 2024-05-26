// Function to fetch weather data from the API based on user input
async function searchWeather() {
    const locationInput = document.getElementById('location-input').value;

    try {
        console.log("Search button clicked!");

        const response = await fetch(`https://localhost:7246/api/wether/${encodeURIComponent(locationInput)}`);

        if (!response.ok) {
            console.error('Error fetching weather data. Status:', response.status);
            return;
        }

        const data = await response.json();
        console.log('Received weather data:', data);

        // Update weather information
        updateWeather(data);
    } catch (error) {
        console.error('Error fetching weather data:', error);
    }
}

function updateWeather(weatherData) {
    // Check if the background image URL is available
    if (weatherData.bagroundImage) {
        // Create an image element to preload the background image
        const image = new Image();
        image.onload = function () {
            // Set background image once it is loaded successfully
            document.body.style.backgroundImage = `url('${weatherData.bagroundImage}')`;
            // Scale the background image to cover the entire screen
            document.body.style.backgroundSize = 'cover';
            // Set the background position to center
            document.body.style.backgroundPosition = 'center';
        };
        image.onerror = function () {
            console.error('Error loading background image:', weatherData.bagroundImage);
        };
        image.src = weatherData.bagroundImage;
    } else {
        console.error('No background image URL provided in weather data.');
    }

    // Create HTML content for weather information
    const htmlContent = `
    <div class="container">

        <div class="card">
            <h2>${weatherData.location.name}, ${weatherData.location.region}, <br>${weatherData.location.country}</h2>
            <p>${weatherData.current.condition.text}</p>
            <p>Temperature: ${weatherData.current.temp_c}°C / ${weatherData.current.temp_f}°F</p>
            <p>Wind: ${weatherData.current.wind_kph} km/h ${weatherData.current.wind_dir}</p>
            <p>Humidity: ${weatherData.current.humidity}%</p>
            <p>Last Updated: ${weatherData.current.last_updated}</p>
        </div>
        </div>
    `;

    // Set the HTML content
    document.getElementById('weather-info').innerHTML = htmlContent;
}
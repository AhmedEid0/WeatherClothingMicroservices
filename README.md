# Weather-Clothing Microservices
An integrated solution of two microservices: A weather prediction service and a clothing recommendation service based on the predicted weather. Developed using ASP.NET Core API.

## Overview
This project houses two distinct microservices that interact to provide clothing suggestions based on the current or predicted weather:

Weather Service: Provides the current or predicted weather for a given location.

Clothing Service: Based on the input from the Weather Service, it suggests appropriate clothing options.

Additionally, there is a shared library to ensure data consistency and streamline interaction between these services.

## Project Structure
WeatherService: The service responsible for fetching and providing weather information.

ClothingService: Suggests clothing based on the weather data it receives.

SharedLibrary: Contains shared classes or utilities used by both services.

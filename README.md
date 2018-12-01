# csc420620_fa2018_weather_monitoring

The goal of this project is to collect temperature, humidity, and barometric pressure data from multiple sources and use that data to create interesting visualizations, as well as weather predictions. These readings are stored as objects called records, and these records are tied to sources. Sources have a location and a flag that determines whether the sensor is outside or inside. Inside sensors are currently not used to make predictions, but the goal is to utilize their readings in conjunction with the outside readings to update a smart thermostat.

To collect the data, multiple python scripts are run at timed intervals. The openweathermap scripts are run once per hour. The weatherpy2 script is a python 2 script for a raspberry pi equipped with a sensehat. It was set to run every 5 minutes, though the exact frequency necessary to update the smart thermostat should be determined experimentally.

To run:
The weatherproject folder contains the backend. It needs to be running, a mysql database needs to be built and a connection string needs to be provided to connect to that database. This connection string needs to go in the web.config file. The configuration.cs file will automatically create the appropriate tables with entity framework. I ran the backend on a personal windows machine using IIS to host it. If you go this route, you will probably need to allow it through the windows firewall.

The front end needs to be run with node.js. A new project will need to be created using node.js, use npm install create-react-app and npm install react-chartjs-2. Then use create-react-app to make a new react app, and put the front end files into their matching directories in the newly created npm react app.

Currently this requires running 2 web servers: the npm one for the front end and the c# server for the backend. I believe it is possible to run all of this on the C# project, but I did not have the time to figure out how. Doing so might also require a different visualization library than chart js, or dropping react support and making a new front end.

The city specific python scripts will run on any system, but the weatherpy2 script needs to be run on a raspberry pi with a sensehat attached.
The python scripts need to be updated with an openweathermap api key, and the full url of the api host.
# Warsaw Stops

[![Build Status](http://kuznia-co.cloudapp.net:8111/app/rest/builds/buildType:id:WarsawStops_Build/statusIcon)](http://sebcza.pl)

It is a project with very simple idea: Easy access to collection of stops localizationin Warsaw. At http://warsaw-stops.azurewebsites.net/ can you see production version.  

Currently you can find a stop by part of name:  
 - api/BusStop?name={name}  
 
And get deatails about stop by id:  
 - api/BusStop/{id}

Solution include:  
 - WebService,  
 - Windows Phone Application,  
 - Angular2 (in future) 
 - Xamarin App (in future)

## Plan

1. Refactor endpoints to:
 - api/stop/search/{name}
 - api/stop/{id}
 - api/stop
 - api/stop?street={street-name}&city={city-name}&direction={name} 
2. Material design for GUI

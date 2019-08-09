# AudioProcessor - REST API
 
## Overview
TODO

## Setup & Running


You need to update ``src/appsettings.json``

Properties to be configured:


````
"DataAccessPostgreSqlProvider": "YOUR-DATABASE-CONNECTION-STRING",
````

### Run
run ``dotnet ef migrations add initial`` and ``dotnet ef database update`` inside ``src/Blip.Api.Flix``.
Just run ``dotnet run`` inside ``src/Blip.Api.Flix`` and voi'la.

## Authors
- José Nondas (jose.silva@take.net) 
- Renan Cunha (renan.santos@take.net)

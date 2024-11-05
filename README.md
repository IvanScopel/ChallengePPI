# ChallengePPI

## Pasos previos que hay que realizar

(Primero clonar el repo obvio, abrirlo con Visual Studio, etc)

Abrir una terminal en la capa Persistence --> DataAccess, y seguir los siguientes pasos:
1. Ejecutar el siguiente comando:
```sh
dotnet ef database update
```
Se creará una base de datos local llamada "ChallengePPIDatabase"

2. Ejecutar el script "PopulationChallengePPI" ubicado en la carpeta utils, dentro de la misma capa. 


## Adicionales que me hubieran gustado hacer

- Tests
- Mapear OrdenDTO con AutoMapper (comenzado en la capa de WebApi --> Middleware
- Organizar lo del Swagger en un archivo aparte
- Agregar las validaciones de models en esa capa

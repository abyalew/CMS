# CMS

Run the start.ps1 file to to start the application.

NB: auto start up assumes iisExpress installed and MsBuild installed and exists in "C:\Program Files (x86)\MSBuild\12.0\Bin\amd64".

Concepts from clean architecture is used. I've tried to decouple the buisness domain from lower level details.

Autofac is used as a inversion of control container.

Automapper is used to map entity models to DTOs.

## Remaining tasks

- End to end validation
- Global exception handling

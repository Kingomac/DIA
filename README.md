# DIA - Desarrollo Integrado de Aplicaciones

- [Apuntes C#](c-sharp.md)
- [Prácticas](practicas/)

# Clase 0: Cómo instalar .NET y JetBrains Rider (modo usuario)

## Linux

1. [Descargar binarios de Linux (x64)](https://dotnet.microsoft.com/es-es/download/dotnet/7.0)
2. Descomprimir fichero `.tar.gz` con GUI o con `tar -xf dotnet-sdk-7.0-linux-x64.tar.gz`
3. `mkdir ~/bin`
4. `mv dotnet-sdk-7.0-linux-x64 ~/bin/dotnet `
5. `cd && nano .bashrc`
6. Añadir al final de `.bashrc`: `export PATH=$PATH:~/bin/dotnet`. Al cerrar y abrir la terminal deberías poder ejecutar `dotnet -h`.
7. [Descargar JetBrains Rider para Linux x64](https://www.jetbrains.com/es-es/rider/download/#section=linux)
8. Descomprimir y entrar en la carpeta `bin` dentro de Rider.
9. Ejecutar `rider.sh`

## Windows

1. [Descargar binarios de Windows (x64)](https://dotnet.microsoft.com/es-es/download/dotnet/7.0)
2. Descomprimirlos y guardarlos en `C:/dotnet` o donde consideres.
3. Buscar en la barra de Windows `Editar las variables de entorno de esta cuenta` y añadir el directorio a `PATH`, debe ser en las de usuario porque no tienes permisos de administrador.
4. Probar a ejecutar `dotnet -h`
5. [Descargar JetBrains Rider para Windows como `.zip`](https://www.jetbrains.com/es-es/rider/download/#section=windows)
6. Ejecutar `.exe`

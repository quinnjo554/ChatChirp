to run docker server for apis
 docker run -p 8081:80 -e ASPNETCORE_URLS=http://+:80 chatchirp

to run docker db 
 docker-compose up --build


 to make migrations
 dotnet ef migrations add "post table init"
 dotnet ef database update
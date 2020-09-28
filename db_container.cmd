docker rm -f gui_pg
docker run --restart always -d -p 5432:5432 -e POSTGRES_PASSWORD=password --name gui_pg postgres

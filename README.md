## COMANDOS
<br>

### - IMAGEM
docker image ls <br>
docker image rm CONTAINER ID <br>
docker build -t nomeImagem:tagImagem . <br>

<br>

### - CONTAINER
 docker container ls -a <br>
 docker container rm CONTAINER ID <br>
 docker container stop CONTAINER ID <br>
 docker container start CONTAINER ID <br>
 docker inspect CONTAINER ID <br>
 docker run -d -p 3000:80 --name nomeContainer  nomeImagem:tagImagem <br>
 docker run -d -p 3000:80 --name nomeContainer -v nomeVolume:/data nomeImagem:tagImagem <br>

<br>

### - VOLUMES
docker run -d -p 3000:80 --name nomeContainer -v nomeVolume:/data nomeImagem:tagImagem <br> 

docker run -d -p 3000:80 --name nomeContainer -v D:\Estudos\Docker\src\DockerMaster.API\docs\:/app volumes:test <br>
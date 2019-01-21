#!/bin/bash

#*****************************************
#Teamcity BuildStep: Command Line
#chmod a+x teamcity_build_step.sh
#./teamcity_build_step.sh %build.number%
#*****************************************

#$1 Teamcity %build.number%

microservice="ftadverts/api"
registry_ip=192.168.99.100
registry_port=55000
build_number=$1
image=$registry_ip:$registry_port/$microservice:ci-$build_number
latest=$registry_ip:$registry_port/$microservice:latest

echo $image
echo $latest

docker build -t $image -t $latest .
docker push $image
docker push $latest

exit $(docker-compose ps -q | tr -d '[:space:]' |
     xargs docker inspect -f '{{ .State.ExitCode }}' | grep -v 0 | wc -l | tr -d '[:space:]')
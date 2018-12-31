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

docker build -t $image .
docker push $image
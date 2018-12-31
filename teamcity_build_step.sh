#!/bin/bash

#$1 Teamcity %build.number%

microservice="ftadverts/api"
registry_ip=192.168.99.100
registry_port=55000
build_number=$1
image=$registry_pi:$registry_port/$microservice:ci-$build_number

docker build -t $image .
docker push $image
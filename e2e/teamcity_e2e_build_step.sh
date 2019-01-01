#!/bin/bash

#*****************************************
#Teamcity BuildStep: Command Line
#chmod a+x teamcity_build_step.sh
#./teamcity_build_e2e_step.sh %build.number%
#*****************************************

docker-compose up --force-recreate --abort-on-container-exit --build
docker-compose down
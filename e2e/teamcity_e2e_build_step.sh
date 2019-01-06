#!/bin/bash
#https://stackoverflow.com/questions/29568352/using-docker-compose-with-ci-how-to-deal-with-exit-codes-and-daemonized-linked
set -e

#*****************************************
#Teamcity BuildStep: Command Line
#chmod a+x teamcity_e2e_build_step.sh
#./teamcity_e2e_build_step.sh %build.number%
#*****************************************

docker-compose --verbose up --force-recreate --abort-on-container-exit --build
docker-compose down

docker rmi 192.168.99.100:55000/ftadverts/e2e:ci-${BUILD_NUMBER-1}

exit $(docker-compose ps -q | tr -d '[:space:]' |
  xargs docker inspect -f '{{ .State.ExitCode }}' | grep -v 0 | wc -l | tr -d '[:space:]')
#!/bin/bash

#*****************************************
#Teamcity BuildStep: Command Line
#chmod a+x teamcity_update_service_test.sh
#./teamcity_update_service_test.sh
#*****************************************

docker service update --force --image 192.168.99.100:55000/ftadverts/api:ci-${UI_BUILD_NUMBER-1} fintech_test_ftadvert_api
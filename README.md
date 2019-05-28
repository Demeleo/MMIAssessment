#Temperature Conversion Project

Project Makeup
  mmi-assess - Angular 7 Frontend
  
  Dockerfile - docker for frontend app
  
  MMIAssess.API - Restful Api Service with one endpoint - api/convert/{type}/{from}/{to}/{value:decimal}
  
  MMIAssess.Core - All Conversion Business Logic and error handling
  
  MMIAssess.Infrastructure - Database ORM Logic to be done here - WIP
  
  MMIAssess.Test - Integration and Unit tests are here
  
  Dockerfile - docker for API
  
  docker-compose.yaml - run 'docker-compose up' to run both frontend and api in containers
  Note: No config file is setup for project yet. before running docker compose change apiURL in ApiService
  
      //apiURL = 'http://localhost:3004/api';//use for docker
      apiURL = 'https://localhost:44344/api';//use for dev
      
 containers-deploy.sh - to deploy to Minikube run this bash script. you will need to change the minicube start command params to fit your env ---
                        this was not tested. my local machine did not have enough memory to run docker and minicube at the same time.
  

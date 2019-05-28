
function build_docker_images {
    echo
    echo "Build docker images"
    echo
    sleep 1
    command="docker-compose up --build"
    eval $command
    sleep 1
}

function start_local_cluster {
    echo
    echo "Start Cluster"
    echo
    sleep 1
    command="minikube start --vm-driver=hyperv --hyperv-virtual-switch=\"Minikube Switch\" --memory=1024 --cpus=2"
    eval $command
    sleep 1
}

function deploy_containers {
    echo
    echo "Deploying Containers"
    echo
    sleep 1
    command="kubectl apply -f ng-mmi-dev-service.yaml,mmi-api-dev-service.yaml,ng-mmi-dev-deployment.yaml,mmi-api-dev-deployment.yaml --validate=false"
    eval $command
    sleep 1
}

function echo_pods {
    command="kubectl describe deployment,svc,pod"
    eval $command
    sleep 1
}

build_docker_images
start_local_cluster
deploy_containers
echo_pods

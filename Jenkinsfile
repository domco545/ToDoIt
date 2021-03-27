pipeline {
    agent any
    triggers {
		cron("0 * * * *")
		pollSCM("*/5 * * * *")
	}
    stages {
        stage("Build Web") {
            steps {
                echo "===== OPTIONAL: Will build the website (if needed) ====="
            }
        }
        stage("Build API") {
            steps {
                echo "===== REQUIRED: Will build the API project ====="
                sh "dotnet build src/Todoit.sln"
                sh "docker build src/. -t mrbacky/todoitapi -f src/API/Dockerfile"
            }
        }
        stage("Build database") {
            steps {
                echo "===== OPTIONAL: Will build the database (if using a state-based approach) ====="
            }
        }
        stage("Test API") {
            steps {
                echo "===== REQUIRED: Will execute unit tests of the API project ====="
            }
        }
        stage("Deliver Web to Docker Hub") {
            steps {
                echo "===== REQUIRED: Will deliver the website to Docker Hub ====="
            }
        }
        stage("Deliver API to Docer Hub") {
            steps {
                echo "===== REQUIRED: Will deliver the API to Docker Hub ====="
                withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerHub', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
                {
                    sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                }
                sh "docker push mrbacky/todoitapi"
            }
        }
        stage("Release staging environment") {
            steps {
                echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
                sh "docker-compose down"
                sh "docker-compose pull"
                sh "docker-compose up -d --build"
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}
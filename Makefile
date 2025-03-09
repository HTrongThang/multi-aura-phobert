hello:
	echo "Hello"
# Define the run-server target
run-server:
	cd backend && go run cmd/server/main.go

run-cyberbullying-server:
	cd vietnamese-cyberbullying && python server.py
	
run-server-websocket:
	cd backend && go run cmd/websocket/main.go
tidy:
	cd backend && go mod tidy
	
.PHONY: all
all: run-server
# hướng dẫn chạy source code
# hãy chạy lần lượt các make run....
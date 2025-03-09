package configs

import (
	"context"
	"log"

	firebase "firebase.google.com/go"
	"google.golang.org/api/option"
)

// var FirebaseStorageBucketName = "multi-aura-8eb80.appspot.com"
var FirebaseStorageBucketName = "multi-aura.appspot.com"

func InitializeFirebaseApp() *firebase.App {
	// opt := option.WithCredentialsFile("./internal/configs/firebase/multi-aura-8eb80-firebase-adminsdk-sdex1-090edd6c44.json")
	opt := option.WithCredentialsFile("./internal/configs/firebase/multi-aura-firebase-adminsdk-uo278-7b0417d3ae.json")
	app, err := firebase.NewApp(context.Background(), &firebase.Config{
		StorageBucket: FirebaseStorageBucketName,
	}, opt)
	if err != nil {
		log.Fatalf("Failed to initialize Firebase app: %v", err)
	}

	return app
}

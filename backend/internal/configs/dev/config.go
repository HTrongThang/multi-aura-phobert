package config

import (
	"log"
	"os"
	"path/filepath"
	"sync"

	"github.com/joho/godotenv"
	"github.com/spf13/viper"
)

var (
	instance *Config
	once     sync.Once
)

type Config struct {
	Neo4j         Neo4jConfig
	Mongo         MongoConfig
	SecretKey     string
	CloudinaryURL string
}

type Neo4jConfig struct {
	URI      string
	Username string
	Password string
}

type MongoConfig struct {
	URI      string
	Database string
}

func Instance() (*Config, error) {
	var err error
	once.Do(func() {

		rootDir, _ := os.Getwd()
		envPath := filepath.Join(rootDir, ".env")
		// Load .env file
		err = godotenv.Load(envPath)
		if err != nil {
			log.Println("No .env file found or failed to load")
		}

		viper.SetConfigName("config")                 // Tên file là "config"
		viper.SetConfigType("yaml")                   // Định dạng YAML
		viper.AddConfigPath("./internal/configs/dev") // Đường dẫn đến folder chứa file config

		err = viper.ReadInConfig()
		if err != nil {
			err = log.Output(2, "unable to read config: "+err.Error())
			return
		}

		instance = &Config{}
		err = viper.Unmarshal(instance)
		if err != nil {
			err = log.Output(2, "unable to decode into struct: "+err.Error())
			return
		}

		instance.CloudinaryURL = os.Getenv("CLOUDINARY_URL")
	})

	return instance, err
}

// GetSecretKey trả về SecretKey
func (cfg *Config) GetSecretKey() string {
	return cfg.SecretKey
}

// GetCloudinaryURL trả về URL Cloudinary
func (cfg *Config) GetCloudinaryURL() string {
	return cfg.CloudinaryURL
}

package utils

import (
	"encoding/json"
	"fmt"
	"net/url"
	"path"
	"reflect"
	"strings"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

func StructToMap(input interface{}) (map[string]interface{}, error) {
	jsonData, err := json.Marshal(input)
	if err != nil {
		return nil, err
	}

	var result map[string]interface{}
	if err := json.Unmarshal(jsonData, &result); err != nil {
		return nil, err
	}

	return result, nil
}

func GetString(data map[string]interface{}, key string) string {
	if val, ok := data[key]; ok {
		if str, ok := val.(string); ok {
			return str
		}
	}
	return ""
}

func GetBool(data map[string]interface{}, key string) bool {
	if val, ok := data[key]; ok {
		if b, ok := val.(bool); ok {
			return b
		}
	}
	return false
}

func GetArray(data map[string]interface{}, key string) []interface{} {
	if val, ok := data[key]; ok {
		if array, ok := val.([]interface{}); ok {
			return array
		}
	}
	return []interface{}{}
}

func GetArrayMap(data map[string]interface{}, key string) []map[string]interface{} {
	if val, ok := data[key]; ok {
		if array, ok := val.(primitive.A); ok {
			result := make([]map[string]interface{}, len(array))
			for i, v := range array {
				if m, ok := v.(map[string]interface{}); ok {
					result[i] = m
				}
			}
			return result
		}
	}
	return []map[string]interface{}{}
}

func GetTime(data map[string]interface{}, key string) time.Time {
	if val, ok := data[key]; ok {
		switch v := val.(type) {
		case time.Time:
			return v
		case string:
			parsedTime, err := time.Parse(time.RFC3339, v)
			if err == nil {
				return parsedTime
			}
		case int64:
			return time.Unix(v/1000, (v%1000)*1000000)
		case float64:
			return time.Unix(int64(v)/1000, (int64(v)%1000)*1000000)
		case primitive.DateTime:
			return v.Time()
		}
	}
	return time.Time{}
}

func GetFloat64(data map[string]interface{}, key string) float64 {
	if value, ok := data[key]; ok {
		if floatVal, ok := value.(float64); ok {
			return floatVal
		}
		if floatVal, ok := value.(float32); ok {
			return float64(floatVal)
		}
		if intVal, ok := value.(int); ok {
			return float64(intVal)
		}
		if int64Val, ok := value.(int64); ok {
			return float64(int64Val)
		}
		if reflect.TypeOf(value).Kind() == reflect.Int64 {
			return float64(value.(int64))
		}
	}
	return 0
}

func GetStringArray(data map[string]interface{}, key string) []string {
	if val, ok := data[key]; ok {
		if array, ok := val.([]interface{}); ok {
			strArray := make([]string, len(array))
			for i, v := range array {
				if str, ok := v.(string); ok {
					strArray[i] = str
				}
			}
			return strArray
		}
	}
	return []string{}
}

func GetStringArrayFromPrimitiveAMap(data map[string]interface{}, key string) []string {
	if val, ok := data[key]; ok {
		if array, ok := val.(primitive.A); ok {
			strArray := make([]string, len(array))
			for i, v := range array {
				if str, ok := v.(string); ok {
					strArray[i] = str
				}
			}
			return strArray
		}
	}
	return []string{}
}

func GetMap(data map[string]interface{}, key string) map[string]interface{} {
	if val, ok := data[key]; ok {
		if mapVal, ok := val.(map[string]interface{}); ok {
			return mapVal
		}
	}
	return map[string]interface{}{}
}

func GetObjectID(data map[string]interface{}, key string) primitive.ObjectID {
	if id, ok := data[key]; ok {
		switch v := id.(type) {
		case primitive.ObjectID:
			return v
		case string:
			objectID, err := primitive.ObjectIDFromHex(v)
			if err != nil {
				return primitive.NilObjectID
			}
			return objectID
		}
	}
	return primitive.NilObjectID
}

func ExtractFileName(fileURL string) (string, error) {
	// Parse URL để tách phần path
	parsedURL, err := url.Parse(fileURL)
	if err != nil {
		return "", fmt.Errorf("invalid URL: %v", err)
	}

	// Lấy path từ URL và giải mã
	filePath := parsedURL.Path
	decodedFilePath, err := url.PathUnescape(filePath)
	if err != nil {
		return "", fmt.Errorf("failed to decode file path: %v", err)
	}

	// Tách file name từ đường dẫn
	parts := strings.Split(decodedFilePath, "/")
	if len(parts) < 2 {
		return "", fmt.Errorf("invalid file path format")
	}

	// Trả về tên file (phần cuối cùng)
	fileName := parts[len(parts)-1]
	return fileName, nil
}

func ExtractPublicID(fileURL string) (string, error) {
	// Parse URL để tách phần path
	parsedURL, err := url.Parse(fileURL)
	if err != nil {
		return "", fmt.Errorf("invalid URL: %v", err)
	}

	// Lấy path từ URL và giải mã
	filePath := parsedURL.Path
	decodedFilePath, err := url.PathUnescape(filePath)
	if err != nil {
		return "", fmt.Errorf("failed to decode file path: %v", err)
	}

	// Tách file path thành các phần và bỏ qua các phần không liên quan
	parts := strings.Split(decodedFilePath, "/")

	// Kiểm tra và đảm bảo có đủ phần tử
	if len(parts) < 7 {
		return "", fmt.Errorf("invalid file path format")
	}

	// Tìm phần public_id, đây là phần từ thứ 6 trở đi trong URL
	publicIDWithExt := strings.Join(parts[5:], "/") // Kết hợp từ phần thứ 5 trở đi thành public_id

	// Loại bỏ phần mở rộng file
	publicID := strings.TrimSuffix(publicIDWithExt, path.Ext(publicIDWithExt))

	return publicID, nil
}

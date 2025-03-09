package models

import (
	"multiaura/pkg/utils"
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

type ToxicityPost struct {
	ID            primitive.ObjectID `bson:"_id,omitempty" json:"_id,omitempty" form:"_id,omitempty"`
	ToxicityScore float64            `bson:"toxicityScore,omitempty" json:"toxicityScore,omitempty" form:"toxicityScore,omitempty"`
	CreatedAt     time.Time          `bson:"createdAt,omitempty" json:"createdAt,omitempty" form:"createdAt,omitempty"`
}

func (p *ToxicityPost) ToMap() map[string]interface{} {
	return map[string]interface{}{
		"_id":           p.ID,
		"toxicityScore": p.ToxicityScore,
		"createdAt":     p.CreatedAt,
	}
}

func (p *ToxicityPost) FromMap(data map[string]interface{}) (*ToxicityPost, error) {
	return &ToxicityPost{
		ID:            utils.GetObjectID(data, "_id"),
		ToxicityScore: utils.GetFloat64(data, "toxicityScore"),
		CreatedAt:     utils.GetTime(data, "createdAt"),
	}, nil
}

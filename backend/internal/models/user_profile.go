package models

type UserProfile struct {
	User             *User              `json:"user"`
	Status           RelationshipStatus `json:"relationshipStatus"`
	Followings       []*UserSummary     `json:"followings"`
	Followers        []*UserSummary     `json:"followers"`
	Friends          []*UserSummary     `json:"friends"`
	MutualFollowings []*UserSummary     `json:"mutualFollowings"`
	MutualFriends    []*UserSummary     `json:"mutualFriends"`
}

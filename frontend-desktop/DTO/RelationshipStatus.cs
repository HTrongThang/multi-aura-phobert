using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace DTO
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RelationshipStatusType
    {
        NoRelationship,
        Following,
        Follower,
        Blocking,
        Blocked,
        Friend
    }

    public class RelationshipStatus
    {
        public RelationshipStatusType Status { get; set; }
        public DateTime? Since { get; set; }

        public string GetRelationshipStatusText()
        {
            switch (Status)
            {
                case RelationshipStatusType.NoRelationship:
                    return "Follow";
                case RelationshipStatusType.Following:
                    return "Following";
                case RelationshipStatusType.Follower:
                    return "Follow back";
                case RelationshipStatusType.Blocking:
                    return "Blocking";
                case RelationshipStatusType.Blocked:
                    return "Blocked";
                case RelationshipStatusType.Friend:
                    return "Friends";
                default:
                    return "Follow";
            }
        }

        public static RelationshipStatusType ParseRelationshipStatusType(string status)
        {
            if (status == null) return RelationshipStatusType.NoRelationship;

            status = status.Trim().ToLower();

            switch (status)
            {
                case "norelation":
                case "no relationship":
                    return RelationshipStatusType.NoRelationship;

                case "following":
                    return RelationshipStatusType.Following;

                case "follower":
                    return RelationshipStatusType.Follower;

                case "blocking":
                    return RelationshipStatusType.Blocking;

                case "blocked":
                    return RelationshipStatusType.Blocked;

                case "friend":
                    return RelationshipStatusType.Friend;

                default:
                    return RelationshipStatusType.NoRelationship;
            }
        }
    }
}

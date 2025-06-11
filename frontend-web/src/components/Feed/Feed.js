import React, { useState } from "react";
import Post from "../Post/Post";
import "./Feed.css";

function Feed({ posts, userData, deletePost }) {
  const [loading, setLoading] = useState(false); // Trạng thái loading nếu cần

  if (loading) {
    return <p>Loading...</p>;
  }

  return (
    <div
      className="feed"
      style={{ display: "flex", flexDirection: "column", alignItems: "center" }}
    >
      {posts &&
        posts.map((post) => (
          <Post
            key={post._id}
            post={post}
            userData={userData}
            deletePost={deletePost}
          />
        ))}
    </div>
  );
}

export default Feed;

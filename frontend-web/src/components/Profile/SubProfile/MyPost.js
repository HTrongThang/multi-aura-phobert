import React from 'react';
import Feed from '../../Feed/Feed';

function Posts({ posts, userData }) {
  return (
    <div>
      <Feed posts={posts} userData={userData} />
    </div>
  );
}

export default Posts;

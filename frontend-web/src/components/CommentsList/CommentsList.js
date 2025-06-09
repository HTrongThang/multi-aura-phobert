import React from "react";
import CommentItem from "../CommentIte/CommentItem";

const CommentsList = ({ comments = [] }) => {
  const validComments = Array.isArray(comments) ? comments : [];
  return (
    <div className="comments-list" style={{ paddingBottom: "70px" }}>
      {validComments.map((comment) => (
        <CommentItem key={comment._id} comment={comment} />
      ))}
    </div>
  );
};

export default CommentsList;

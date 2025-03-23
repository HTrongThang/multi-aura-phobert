import React, { useEffect, useState } from "react";
import "../Post/NegativeComment.css";

const NegativeComment = ({ onTurnOff }) => {
  useEffect(() => {
    const timer = setTimeout(() => {
      onTurnOff();
    }, 3000);

    return () => clearTimeout(timer);
  }, [onTurnOff]);
  return (
    <div>
      <div className="nofi">
        <button className="exit" onClick={onTurnOff}>
          X
        </button>
        <div className="text">
          <p>Bạn vừa bình luận tiêu cực</p>
          <p>Hãy bình luận 1 câu khác tích cực lên</p>
        </div>
      </div>
    </div>
  );
};

export default NegativeComment;

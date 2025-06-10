import React, { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGhost } from "@fortawesome/free-solid-svg-icons";
import { faEllipsisV } from "@fortawesome/free-solid-svg-icons";
import "./ChatHeader.css";

const ChatHeader = ({
  user,
  currentUserID,
  onToggleSidebar,
  isSidebarOpen,
}) => {
  const [imageError, setImageError] = useState(false);
  const isGroup = user.conversation_type === "Group";

  let avatarSrc;
  let nameDisplay;

  const handleImageError = () => {
    setImageError(true);
  };

  if (isGroup && user.users.length === 2) {
    const otherUser = user.users.find((u) => u.userID !== currentUserID);
    avatarSrc = otherUser
      ? otherUser.avatar
      : "../static/media/Logo.af2b2f1b32b135402e38.png";
    nameDisplay = otherUser ? otherUser.fullname : "Unknown User";
  } else if (isGroup) {
    avatarSrc = user.avatar || "../static/media/Logo.af2b2f1b32b135402e38.png";
    nameDisplay = user.name_conversation;
  } else {
    const otherUser = user.users.find((u) => u.userID !== currentUserID);
    avatarSrc = otherUser
      ? otherUser.avatar
      : "../static/media/Logo.af2b2f1b32b135402e38.png";
    nameDisplay = otherUser ? otherUser.fullname : "Unknown User";
  }

  return (
    <div
      className="chat-header"
      style={{ display: "flex", justifyContent: "space-between" }}
    >
      <div className="left-section">
        <div style={{ display: "flex", alignItems: "center" }}>
          {imageError ? (
            <div className="avatar-fallback rounded-circle me-3">
              <FontAwesomeIcon icon={faGhost} />
            </div>
          ) : (
            <img
              src={avatarSrc}
              alt={nameDisplay}
              className="avatar rounded-circle me-3"
              onError={handleImageError}
            />
          )}
          <div className="user-info">
            <h3>{nameDisplay}</h3>
            <span className="status">Online - Last seen, 2.02pm</span>
          </div>
        </div>
      </div>
      <div className="right-section">
        <div
          className={`menu-icon ${isSidebarOpen ? "active" : ""}`} // Thêm class "active" khi sidebar mở
          onClick={onToggleSidebar}
          style={{ cursor: "pointer" }}
        >
          <FontAwesomeIcon icon={faEllipsisV} />
        </div>
      </div>
    </div>
  );
};

export default ChatHeader;

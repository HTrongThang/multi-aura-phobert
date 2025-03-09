import React from "react";
import "./NotificationItem.css";

const NotificationItem = ({ user, message, time, avatar }) => {
  return (
    <div className="notification-item">
      <div className="notification-avatar">
        <img
          src={avatar || "https://via.placeholder.com/40"}
          alt="Avatar"
          className="avatar-image"
        />
      </div>
      <div className="notification-content">
        <span className="notification-message">
          <strong>{user}</strong> {message}
        </span>
        <div className="notification-time">{time}</div>
      </div>
    </div>
  );
};

export default NotificationItem;

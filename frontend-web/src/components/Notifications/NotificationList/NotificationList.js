import React from "react";
import NotificationItem from "../NotificationItem/NotificationItem";
import "./NotificationList.css";

const NotificationList = ({ notifications }) => {
  return (
    <div className="notification-list">
      {notifications.length > 0 ? (
        notifications.map((notification) => (
          <NotificationItem
            key={notification.id}
            user={notification.user}
            message={notification.message}
            time={notification.time}
            avatar={notification.avatar}
          />
        ))
      ) : (
        <p className="no-notifications">No notifications</p>
      )}
    </div>
  );
};

export default NotificationList;

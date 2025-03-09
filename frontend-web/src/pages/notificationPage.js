import React, { useState } from "react";
import NotificationsHeader from "../components/Notifications/NotificationsHeader/NotificationsHeader";
import NotificationsTabs from "../components/Notifications/NotificationsTabs/NotificationsTabs";
import NotificationList from "../components/Notifications/NotificationList/NotificationList";
import "../assets/css/NotificationPage.css";

const NotificationsPage = ({ isOpen, onClose }) => {
  const [activeTab, setActiveTab] = useState("Common");

  const notifications = [
    { id: 1, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 2, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 3, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 4, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 5, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 6, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 7, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 8, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},
    { id: 9, user: "Nguyen Huy Hoang", message: "đã bày tỏ cảm xúc về bình luận của bạn.", time: "2 hours ago", type: "Common" , avatar:"https://scontent.fsgn5-9.fna.fbcdn.net/v/t39.30808-6/366569885_1533700070701457_8801153647754393288_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=6ee11a&_nc_ohc=aGcPExken6MQ7kNvgEUYEuf&_nc_zt=23&_nc_ht=scontent.fsgn5-9.fna&_nc_gid=A710y9kxGhWLCopSeGpf-7n&oh=00_AYBKh69EmHz497c-N8AiubCU4qQeaVQ2XUUr3TDjaWv7UQ&oe=67488CDF"},



  ];

  const filteredNotifications = notifications.filter((n) => n.type === activeTab);

  return (
    <>
      {isOpen && (
        <div className="drawer-overlay" onClick={onClose}></div>
      )}
      <div className={`notifications-drawer ${isOpen ? "open" : ""}`}>
        <div className="drawer-content">
          <NotificationsHeader onClose={onClose} />

          {/* Tabs */}
          <NotificationsTabs activeTab={activeTab} setActiveTab={setActiveTab} />

          {/* Notification List */}
          <NotificationList notifications={filteredNotifications} />
        </div>
      </div>
    </>
  );
};

export default NotificationsPage;

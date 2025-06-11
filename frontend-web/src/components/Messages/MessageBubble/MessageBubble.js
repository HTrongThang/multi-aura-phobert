import React, { useEffect, useRef, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faGhost } from "@fortawesome/free-solid-svg-icons";
import "./MessageBubble.css";

const MessageBubble = ({
  message,
  userAvatar,
  currentUserID,
  showSenderInfo,
  showTime,
}) => {
  const isSentByUser = message.sender.userID === currentUserID;
  const messageEndRef = useRef(null);
  const [imageError, setImageError] = useState(false);

  // Tự động cuộn xuống khi có tin nhắn mới
  useEffect(() => {
    messageEndRef.current?.scrollIntoView({ behavior: "smooth" });
    setImageError(false);
  }, [message]);

  const handleImageError = () => {
    setImageError(true);
  };

  // Định dạng thời gian
  const formattedTime = message.createdat
    ? new Date(message.createdat).toLocaleTimeString("en-US", {
        hour: "numeric",
        minute: "numeric",
        hour12: true,
      })
    : "Unknown time"; // Giá trị mặc định nếu `createdat` không tồn tại

  return (
    <div className={`messchat-item ${isSentByUser ? "sent" : "received"}`}>
      {!isSentByUser && showSenderInfo ? (
        // Bắt đầu khối xử lý lỗi ảnh
        imageError ? (
          // Nếu có lỗi, hiển thị icon thay thế
          <div className="avatar-fallback">
            <FontAwesomeIcon icon={faGhost} />
          </div>
        ) : (
          // Nếu không có lỗi, hiển thị ảnh và thêm trình xử lý onError
          <img
            src={userAvatar}
            alt="sender-avatar"
            className="avatar"
            onError={handleImageError}
          />
        )
      ) : (
        // Giữ nguyên logic cho placeholder
        <div className="placeholder-avatar"></div>
      )}
      <div className="message-content">
        {/* Hiển thị tên người gửi nếu `showSenderInfo` là true */}
        {!isSentByUser && showSenderInfo && (
          <p className="mb-1 sender-name">{message.sender.fullname}</p>
        )}
        <p className="message-text">{message.content.text}</p>
        {/* Chỉ hiển thị thời gian khi `showTime` là true */}
        {showTime && <span className="message-time">{formattedTime}</span>}
      </div>
      <div ref={messageEndRef}></div> {/* Thêm phần tử trống để cuộn tới */}
    </div>
  );
};

export default MessageBubble;

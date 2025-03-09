import React, { useEffect, useState } from 'react';
import './MessageItem.css';

const MessageItem = ({ message, onClick, isSelected  }) => {
  const [userData, setUserData] = useState(null);
  const isGroup = message.conversation_type === 'Group';
  let avatar;
  let nameDisplay;

  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setUserData(JSON.parse(storedUser));
    }
  }, []);

  const currentUserID = userData ? userData.userID : null;

  if (isGroup) {
    avatar = message.thumb_group || '../static/media/Logo.af2b2f1b32b135402e38.png';
    nameDisplay = message.name_conversation || 'Multi Aura';
  } else {
    const otherUser = message.users.find((user) => user.userID !== currentUserID);
    avatar = otherUser ? otherUser.avatar : '../static/media/Logo.af2b2f1b32b135402e38.png';
    nameDisplay = otherUser ? otherUser.fullname : 'Unknown User';
  }

  const lastMessage = message.chats && message.chats.length > 0
    ? (message.chats[message.chats.length - 1].content.text
      ? message.chats[message.chats.length - 1].content.text
      : message.chats[message.chats.length - 1].content.image
        ? 'Hình ảnh'
        : message.chats[message.chats.length - 1].content.voice_url
          ? 'Ghi âm'
          : 'Bạn bè mới. Hãy gửi lời chào')
    : 'Bạn bè mới. Hãy gửi lời chào';

  const lastMessageDate = message.chats && message.chats.length > 0
    ? new Date(message.chats[message.chats.length - 1].createdat)
    : null;

  let timeDisplay = '';
  if (lastMessageDate) {
    const timeDiff = (new Date() - lastMessageDate) / 1000;
    if (timeDiff < 60) {
      timeDisplay = `${Math.floor(timeDiff)} seconds ago`;
    } else if (timeDiff < 3600) {
      const minutes = Math.floor(timeDiff / 60);
      timeDisplay = `${minutes} minute${minutes > 1 ? 's' : ''} ago`;
    } else if (timeDiff < 86400) {
      const hours = Math.floor(timeDiff / 3600);
      timeDisplay = `${hours} hour${hours > 1 ? 's' : ''} ago`;
    } else {
      const days = Math.floor(timeDiff / 86400);
      timeDisplay = `${days} day${days > 1 ? 's' : ''} ago`;
    }
  }
  return (
    <li
      className={`list-group-item d-flex align-items-center message-item ${isSelected  ? 'selected' : ''}`}
      style={{ borderBottom: "1px solid #333" }}
      onClick={onClick}
    >
      <img src={avatar} alt="profile" className="avatar rounded-circle me-3" />

      <div className="message-info">
        <strong className="message-name">{nameDisplay}</strong>

        <div className="last-message-container" style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
          <p className="small message-last" style={{ color: "#e9edef", marginRight: '10px' }}>
            {lastMessage}
          </p>

          {timeDisplay && (
            <span className="small" style={{ color: "#6f787d" }}>
              {timeDisplay}
            </span>
          )}
        </div>
      </div>
    </li>
  );
};

export default MessageItem;

import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import CreateGroupConversation from '../CreateGroupConversation/CreateGroupConversation';

import {
  faBellSlash,
  faThumbtack,
  faUsers,
  faClock,
  faFile,
  faImage,
  faTimes,
  faUserPlus,
  faCogs,
  faChevronDown,
  faChevronUp, faEllipsisV
} from '@fortawesome/free-solid-svg-icons';
import './SettingSidebarChat.css';

const SettingSidebarChat = ({ isOpen, currentChat, userCurent, dataFriend, onCreateGroup, onAddMenberGroup ,onRemoveMenberGroup}) => {
  const [isModalVisible, setModalVisible] = useState(false);
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);
  const [selectedUserID, setSelectedUserID] = useState(null);
  const [showLeaveButton, setShowLeaveButton] = useState(false);
  const isUser = userCurent?.userID;

  const isGroup = currentChat.conversation_type === 'Group';
  const currentUserID = userCurent ? userCurent.userID : null;
  let avatar;
  let nameDisplay;

  // Xử lý avatar và tên hiển thị
  if (isGroup) {
    avatar = currentChat.thumb_group || '../static/media/Logo.af2b2f1b32b135402e38.png';
    nameDisplay = currentChat.name_conversation || 'Multi Aura';
  } else {
    const otherUser = currentChat.users.find((user) => user.userID !== currentUserID);
    avatar = otherUser ? otherUser.avatar : '../static/media/Logo.af2b2f1b32b135402e38.png';
    nameDisplay = otherUser ? otherUser.fullname : 'Unknown User';
  }

  // Mở modal
  const openModal = () => {
    setModalVisible(true);
  };

  // Đóng modal
  const closeModal = () => {
    setModalVisible(false);

  };



  // Toggle dropdown để hiện/ẩn danh sách thành viên
  const toggleDropdown = () => {
    setIsDropdownOpen(!isDropdownOpen);
  };
  const handleLeaveGroup = (userID) => {
    onRemoveMenberGroup(userID);
  }
  useEffect(() => {
    const handleClickOutside = (event) => {
      if (event.target.closest('.ellipsis-btn') === null) {
        setShowLeaveButton(false); // Ẩn nút khi click ngoài
      }
    };

    // Thêm event listener khi component mount
    document.addEventListener('click', handleClickOutside);

    // Cleanup khi component unmount
    return () => {
      document.removeEventListener('click', handleClickOutside);
    };
  }, []);

  return (
    <div className={`setting-sidebar-chat ${isOpen ? 'visible' : 'hidden'}`}>
      {/* Header */}
      <div className="header">
        <img src={avatar} alt="Avatar" />
        <h3>{nameDisplay}</h3>
        <div className="actions">
          <button>
            <FontAwesomeIcon icon={faThumbtack} /> Ghim hội thoại
          </button>

          {isGroup ? (
            <>
              <button onClick={openModal}>
                <FontAwesomeIcon icon={faUserPlus} /> Thêm thành viên
              </button>
            </>
          ) : (
            <button onClick={openModal}>
              <FontAwesomeIcon icon={faUsers} /> Tạo nhóm
            </button>
          )}
        </div>
      </div>

      {/* Modal Create Group */}
      <CreateGroupConversation
        UsercurrentChat={currentChat.users}
        dataFriend={dataFriend}
        isVisible={isModalVisible}
        onClose={closeModal}
        onCreateGroup={onCreateGroup}
        isGroup={isGroup}
        onAddMenberGroup={onAddMenberGroup}
      />

      {/* Dropdown danh sách thành viên */}
      {isGroup && (
        <>
          <div className="section">
            <h4 className="section-title">
              <FontAwesomeIcon icon={faUsers} /> Danh sách thành viên
              <button onClick={toggleDropdown} className="dropdown-toggle-btn">
                <FontAwesomeIcon icon={isDropdownOpen ? faChevronUp : faChevronDown} />
              </button>
            </h4>
          </div>
          {isDropdownOpen && (
            <div className="members-list">
              {currentChat?.users && currentChat.users.length > 0 ? (
                currentChat.users.map((user) => (
                  <div key={user.userID} className="member-item">
                    <div>
                      <img
                        src={user.avatar || 'https://phongreviews.com/wp-content/uploads/2022/11/avatar-facebook-mac-dinh-8.jpg'} // Nếu không có avatar thì sử dụng ảnh mặc định
                        alt={user.fullname}
                        className="member-avatar"
                      />
                      <span>{user.fullname}</span>
                    </div>
                    <div className="ellipsis-btn">
                      {user.userID === isUser && (
                        <>
                          <FontAwesomeIcon icon={faEllipsisV} onClick={() => setShowLeaveButton(!showLeaveButton)} />
                          {showLeaveButton && (
                            <button
                              className="leave-group" // Áp dụng class leave-group cho nút "Rời nhóm"
                              onClick={() => handleLeaveGroup(user.userID)}
                            >
                              Rời nhóm
                            </button>
                          )}
                        </>
                      )}
                    </div>
                  </div>
                ))
              ) : (
                <p>Chưa có thành viên nào.</p>
              )}
            </div>
          )}


        </>
      )}

      {/* Ảnh/Video */}
      <div className="section">
        <h4 className="section-title">
          <FontAwesomeIcon icon={faImage} /> Ảnh/Video
        </h4>
        <div className="media-grid">
          {/* <img src="image1.jpg" alt="Media 1" />
          <img src="image2.jpg" alt="Media 2" />
          <img src="image3.jpg" alt="Media 3" />
          <img src="image4.jpg" alt="Media 4" /> */}
        </div>
        <div className="view-all-btn">Xem tất cả</div>
      </div>

      {/* File */}
      <div className="section">
        <h4 className="section-title">
          <FontAwesomeIcon icon={faFile} /> File
        </h4>
        <ul className="file-list">
          {/* <li>
            <div className="file-name">
              <FontAwesomeIcon icon={faFile} />
              <span>2001216069_File1.xlsx</span>
            </div>
            <div className="file-date">21/11/2024</div>
          </li>
          <li>
            <div className="file-name">
              <FontAwesomeIcon icon={faFile} />
              <span>Nhom10_BaoCaoCuoiKi.zip</span>
            </div>
            <div className="file-date">11/11/2024</div>
          </li> */}
          {/* Thêm các file khác nếu cần */}
        </ul>
      </div>
    </div>
  );
};

export default SettingSidebarChat;

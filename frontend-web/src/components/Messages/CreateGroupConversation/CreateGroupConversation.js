import React, { useState, useEffect } from "react";
import ReactDOM from "react-dom";
import "./CreateGroupConversation.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faTimes, faUserPlus } from "@fortawesome/free-solid-svg-icons";
import { createGroupConversation } from "../../../services/chatservice";
import SuccessModal from "../../SuccessModal/SuccessModal";
import { debounce } from "lodash"; // Giả sử lodash đã được cài đặt để sử dụng debouncing
import UserAvatarWithFallback from "../ErrorImage/UserAvatarWithFallback"; // Import component hiển thị avatar với fallback

const CreateGroupConversation = ({
  isVisible,
  onClose,
  dataFriend,
  onCreateGroup,
  UsercurrentChat,
  isGroup,
  onAddMenberGroup,
}) => {
  const [selectedUsers, setSelectedUsers] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [selectedImage, setSelectedImage] = useState(null);
  const [groupTitle, setGroupTitle] = useState("");
  const [groupData, setGroupData] = useState(null);
  const [imageUrl, setImageUrl] = useState("");
  const [isSuccess, setIsSuccess] = useState(false);
  const handleSelectUser = (user) => {
    setSelectedUsers((prevUsers) =>
      prevUsers.some((u) => u.userID === user.userID)
        ? prevUsers.filter((u) => u.userID !== user.userID)
        : [...prevUsers, user]
    );
  };

  const handleImageUpload = (event) => {
    const file = event.target.files[0];
    setImageUrl(file);
    if (file && file.type.startsWith("image/")) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setSelectedImage(reader.result); // Lưu URL dữ liệu ảnh
      };
      reader.readAsDataURL(file);
    } else {
      alert("Vui lòng chọn tệp ảnh hợp lệ.");
    }
  };

  const hanleSubmit = () => {
    const groupData = {
      title: groupTitle,
      image: imageUrl,
      users: [...selectedUsers.map((user) => user.userID)],
    };
    onCreateGroup(groupData);
    setGroupTitle(""); // Nếu muốn reset trường nhập tên nhóm
    setImageUrl(null); // Nếu muốn reset ảnh đại diện
    setSelectedUsers([]); // Nếu muốn reset danh sách người dùng đã chọn
  };
  const handleSubmit_add = () => {
    const groupData_addMenber = {
      users: [...selectedUsers.map((user) => user.userID)],
    };
    onAddMenberGroup(groupData_addMenber);
  };

  if (!isVisible) return null;

  return ReactDOM.createPortal(
    <>
      <div className="create-group-overlay">
        <div className="create-group-container">
          <div className="create-group-header">
            <h3>{isGroup ? "Thêm thành viên" : "Tạo nhóm"}</h3>
            <button onClick={onClose} className="create-group-close-btn">
              <FontAwesomeIcon icon={faTimes} />
            </button>
          </div>
          <div className="create-group-body">
            <div className="group-name-container">
              {!isGroup && (
                <div className="input-with-icon">
                  {selectedImage ? (
                    <img
                      src={selectedImage}
                      alt="Group Avatar"
                      className="group-avatar-preview"
                      onClick={() =>
                        document.getElementById("group-avatar-input").click()
                      }
                    />
                  ) : (
                    <div
                      className="icon-wrapper"
                      onClick={() =>
                        document.getElementById("group-avatar-input").click()
                      }
                    >
                      <i className="fas fa-camera"></i>
                    </div>
                  )}
                  <input
                    type="file"
                    id="group-avatar-input"
                    accept="image/*"
                    style={{ display: "none" }}
                    onChange={handleImageUpload}
                  />
                  <input
                    type="text"
                    className="group-name-input"
                    placeholder="Nhập tên nhóm..."
                    value={groupTitle}
                    onChange={(e) => setGroupTitle(e.target.value)}
                  />
                </div>
              )}

              <div className="input-search-wrapper">
                <i className="fas fa-search search-icon"></i>
                <input
                  type="text"
                  className="create-group-search-input"
                  placeholder="Nhập tên hoặc số điện thoại"
                  value={searchTerm}
                  onChange={debounce((e) => setSearchTerm(e.target.value), 500)}
                />
              </div>
            </div>
            <div className="create-group-user-list-container">
              <div className="create-group-user-list">
                {Array.isArray(dataFriend) &&
                  dataFriend
                    .filter(
                      (user) =>
                        user.fullname
                          ?.toLowerCase()
                          .includes(searchTerm.toLowerCase()) &&
                        !UsercurrentChat.some(
                          (chatUser) => chatUser.userID === user.userID
                        ) // Kiểm tra userID đã tồn tại trong UsercurrentChat
                    )
                    .map((user) => (
                      <div key={user.userID} className="create-group-user-item">
                        <input
                          type="checkbox"
                          checked={selectedUsers.some(
                            (u) => u.userID === user.userID
                          )}
                          onChange={() => handleSelectUser(user)}
                        />
                        <UserAvatarWithFallback
                          src={user.avatar || "/path/to/default-avatar.png"}
                          alt={user.fullname}
                          className="create-group-avatar"
                        />
                        <span>{user.fullname}</span>
                      </div>
                    ))}
              </div>

              <div className="create-group-selected-users">
                <p>Đã chọn {selectedUsers.length}/100</p>
                {selectedUsers.map((user) => (
                  <div key={user.userID} className="create-group-selected-user">
                    <UserAvatarWithFallback
                      src={user.avatar || "/path/to/default-avatar.png"}
                      alt={user.fullname}
                      className="create-group-avatar"
                    />
                    <span>{user.fullname}</span>
                    <button
                      onClick={() =>
                        setSelectedUsers(
                          selectedUsers.filter((u) => u.userID !== user.userID)
                        )
                      }
                      className="remove-user-btn"
                    >
                      <FontAwesomeIcon icon={faTimes} />
                    </button>
                  </div>
                ))}
              </div>
            </div>
          </div>
          <div className="create-group-footer">
            <button className="btn btn-outline-light" onClick={onClose}>
              Hủy
            </button>
            {!isGroup ? (
              <button
                className="btn btn-success"
                disabled={selectedUsers.length === 0 || !groupTitle}
                onClick={() => {
                  hanleSubmit();
                  onClose();
                }}
                style={{ width: "30%" }}
              >
                Tạo nhóm
              </button>
            ) : (
              <button
                className="btn btn-success"
                disabled={selectedUsers.length === 0}
                onClick={() => {
                  handleSubmit_add();
                  onClose();
                }}
                style={{ width: "40%" }}
              >
                Thêm thành viên
              </button>
            )}
          </div>
        </div>
      </div>
    </>,
    document.body
  );
};

export default CreateGroupConversation;

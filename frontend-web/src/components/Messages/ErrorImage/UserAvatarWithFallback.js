import React, { useState, useEffect } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUser } from "@fortawesome/free-solid-svg-icons"; // Dùng icon user cho gọn
import "./UserAvatarWithFallback.css"; // File CSS riêng cho component này

const UserAvatarWithFallback = ({ src, alt, className }) => {
  const [error, setError] = useState(false);

  // Reset trạng thái lỗi mỗi khi `src` của ảnh thay đổi
  useEffect(() => {
    setError(false);
  }, [src]);

  const handleError = () => {
    setError(true);
  };

  if (error) {
    return (
      <div className={`${className} user-avatar-fallback`}>
        <FontAwesomeIcon icon={faUser} />
      </div>
    );
  }

  return (
    <img src={src} alt={alt} className={className} onError={handleError} />
  );
};

export default UserAvatarWithFallback;

import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import './UserInfo.css';
import { followUser, unfollowUser, checkRelationshipStatus, blockUser } from '../../../services/RelationshipService';
import { createConversation } from '../../../services/chatservice';

const UserInfo = ({ user }) => {

  const [relationshipStatus, setRelationshipStatus] = useState('');
  const [loading, setLoading] = useState(true);
  const [isBlocked, setIsBlocked] = useState(false);
  const [userData, setUserData] = useState(null);
  const navigate = useNavigate();
  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setUserData(JSON.parse(storedUser));
    }
  }, []);
  useEffect(() => {
    const fetchRelationshipStatus = async () => {
      try {
        const status = await checkRelationshipStatus(user.userID);
        setRelationshipStatus(status.status);
        setIsBlocked(status.isBlocked || false);
        console.log(status);
      } catch (error) {
        console.error('Lỗi khi kiểm tra trạng thái quan hệ:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchRelationshipStatus();
  }, [user.userID]);

  const handleCreateConversation = async () => {
    try {
      const name_conversation = "";
      const userIDs = [userData.userID, user.userID];

      const response = await createConversation(userIDs, name_conversation);
      console.log(response);
      if (response.status === 201 || response.status === 200) {
        navigate(`/chat/${response.data._id}`);
      }
    } catch (err) {
      console.error("Lỗi khi tạo cuộc trò chuyện:", err.message || err);
    }
  };


  const handleFollowClick = async () => {
    try {
      await followUser(user.userID);
      setRelationshipStatus('isFollowedBy');
    } catch (error) {
      console.error('Lỗi khi theo dõi:', error);
    }
  };

  const handleUnfollowClick = async () => {
    try {
      await unfollowUser(user.userID);
      setRelationshipStatus('');
    } catch (error) {
      console.error('Lỗi khi hủy theo dõi:', error);
    }
  };
  const handleBlockClick = async () => {
    try {
      await blockUser(user.userID);
      setIsBlocked(true);
    } catch (error) {
      console.error('Lỗi khi block người dùng:', error);
    }
  };
  if (loading) {
    return <p>Loading...</p>;
  }

  const renderActionButton = () => {
    switch (relationshipStatus) {
      case 'Friend':
        return <button className="btn btn-success" disabled>Friend</button>;
      case 'Following':
        return <button className="btn btn-info" onClick={handleFollowClick}>FollowBack</button>;
      case 'Followed':
        return <button className="btn btn-danger" onClick={handleUnfollowClick}>Unfollow</button>;
      default:
        return <button className="btn btn-secondary" onClick={handleFollowClick}>Follow</button>;
    }
  };

  return (
    <div className="user-info-container">
      <img src={user.avatar || 'https://firebasestorage.googleapis.com/v0/b/multi-aura.appspot.com/o/Hihon%2F1728534046_9ea1c9841cadbef3e7bc.jpg?alt=media&token=3d221a08-d064-4ece-881a-32e2c5d273e1'} alt={user.fullname} className="profile-avatar" />
      <h4>{user.fullname}</h4>
      <p>@{user.username}</p>
      <p>{user.posts} posts • {user.followers} followers • {user.following} following</p>
      <p>{user.bio}</p>
      {renderActionButton()}
      <button className="btn btn-secondary" onClick={handleCreateConversation}>Message</button>
      <button className="btn btn-danger" onClick={handleBlockClick} disabled={isBlocked}>
        {isBlocked ? 'Blocked' : 'Block'}
      </button>
    </div>
  );
};

export default UserInfo;

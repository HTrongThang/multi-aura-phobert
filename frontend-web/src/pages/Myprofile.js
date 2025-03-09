import React, { useEffect, useState } from 'react';
import '../assets/css/MyProfile.css';
import ProfileHeader from '../components/Profile/ProfileHeader/ProfileHeader';
import ProfileNav from '../components/Profile/ProfileNav/ProfileNav';
import Posts from '../components/Profile/SubProfile/MyPost';
import Introduce from '../components/Profile/SubProfile/Introduce';
import Friends from '../components/Profile/SubProfile/Friends';
import Layout from '../layouts/Layout';
import { useLocation, useNavigate } from 'react-router-dom';
import { getFriends, getFollowers, getFollowings } from '../services/RelationshipService';
import Cookies from 'js-cookie';
import ImageGallery from '../components/ImageGallery/ImageGallery';
import { getPostsById } from '../services/searchService';

function MyProfile() {
  const [userData, setUserData] = useState(null);
  const [friends, setFriends] = useState([]);
  const [followers, setFollowers] = useState([]);
  const [followings, setFollowings] = useState([]);
  const [activeTab, setActiveTab] = useState('posts');
  const navigate = useNavigate();
  const location = useLocation();
  const authToken = Cookies.get('authToken');
  const [posts, setPosts] = useState([]);

  useEffect(() => {
    if (!authToken) {
      navigate('/');
    } else if (location.state && location.state.userData) {
      setUserData(location.state.userData);
      localStorage.setItem('user', JSON.stringify(location.state.userData));
    } else {
      const storedUser = localStorage.getItem('user');
      if (storedUser) {
        setUserData(JSON.parse(storedUser));
      }
    }
  }, [authToken, location, navigate]);

  useEffect(() => {
    const fetchRelationships = async () => {
      try {
        const friendsData = await getFriends();
        const followersData = await getFollowers();
        const followingsData = await getFollowings();
        setFriends(friendsData || []);
        setFollowers(followersData || []);
        setFollowings(followingsData || []);
      } catch (error) {
        console.error('Lỗi khi lấy danh sách bạn bè:', error);
      }
    };

    fetchRelationships();
    const storedTab = localStorage.getItem('activeTab');
    if (storedTab) {
      setActiveTab(storedTab);
    }
  }, []);

  const handleTabChange = (tab) => {
    setActiveTab(tab);
    localStorage.setItem('activeTab', tab);
  };

  useEffect(() => {
    if (userData) {
      const fetchNewsPosts = async () => {
        try {
          const response = await getPostsById(userData?.userID);
          setPosts(response.data);
        } catch (error) {
          console.error('Lỗi khi lấy bài viết:', error);
        }
      };

      fetchNewsPosts();
    }
  }, [userData]);

  const renderContent = () => {
    switch (activeTab) {
      case 'posts':
        return <Posts posts={posts}  userData={userData}/>;
      case 'introduce':
        return <Introduce userData={userData} />;
      case 'friends':
        return <Friends friends={friends} />;
      case 'images':
        return <ImageGallery posts={posts} userData={userData} />;
      case 'more':
        return <div>Additional content here.</div>;
      default:
        return <Posts posts={posts} />;
    }
  };

  return (
    <Layout userData={userData}>
      <div className="container myprofile-page text-white py-5">
        <ProfileHeader 
          userData={userData} 
          friends={friends.length ? friends : []} 
          followers={followers.length ? followers : []} 
          followings={followings.length ? followings : []} 
        />
        <ProfileNav activeTab={activeTab} onTabChange={handleTabChange} />
        <div className="row mt-4">
          <div className="col-md-12">
            {renderContent()}
          </div>
        </div>
      </div>
    </Layout>
  );
}

export default MyProfile;

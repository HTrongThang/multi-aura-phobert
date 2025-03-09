import React, { useState, useEffect } from 'react';
import { useLocation } from 'react-router-dom';
import './Sidebar.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faHome, faThLarge, faCommentDots, faBell, faUser } from '@fortawesome/free-solid-svg-icons';
import NotificationsPage from '../../pages/notificationPage';

function Sidebar() {
  const location = useLocation();
  const [activeTab, setActiveTab] = useState('/Home'); // Tab hiện tại
  const [isCollapsed, setIsCollapsed] = useState(false); // Sidebar collapsed
  const [isDrawerOpen, setIsDrawerOpen] = useState(false); // Trạng thái Drawer

  // Cập nhật activeTab khi đường dẫn thay đổi
  useEffect(() => {
    setActiveTab(location.pathname);
  }, [location.pathname]);

  // Xử lý nhấn tab
  const handleTabClick = (tab) => {
    if (tab === '/notifications') {
      setIsDrawerOpen(!isDrawerOpen); // Toggle Drawer
      setActiveTab(tab); // Đặt tab active
    } else {
      setIsDrawerOpen(false); // Đóng Drawer khi chọn tab khác
      setActiveTab(tab);
    }
  };

  // Toggle Sidebar
  const toggleSidebar = () => {
    setIsCollapsed(!isCollapsed);
    document.querySelector('.main-content').style.marginLeft = isCollapsed ? '250px' : '100px';
  };

  return (
    <div className={`sidebar ${isCollapsed ? 'collapsed' : ''}`}>
      {/* Toggle Button */}
      <div className="toggle-button" onClick={toggleSidebar}>
        <FontAwesomeIcon icon={faThLarge} />
      </div>

      <h2 className="text-center">Multi Aura</h2>

      <ul className="nav flex-column">
        {/* Home */}
        <li className="nav-item">
          <a
            className={`tab-link ${activeTab === '/Home' ? 'active' : ''}`}
            href="/Home"
            onClick={() => handleTabClick('/Home')}
          >
            <FontAwesomeIcon icon={faHome} className="icon" />
            {!isCollapsed && <span>Home</span>}
          </a>
        </li>

        {/* Explore */}
        <li className="nav-item">
          <a
            className={`tab-link ${activeTab === '/explore' ? 'active' : ''}`}
            href="/explore"
            onClick={() => handleTabClick('/explore')}
          >
            <FontAwesomeIcon icon={faThLarge} className="icon" />
            {!isCollapsed && <span>Explore</span>}
          </a>
        </li>

        {/* Messages */}
        <li className="nav-item">
          <a
            className={`tab-link ${activeTab === '/chat' ? 'active' : ''}`}
            href="/chat"
            onClick={() => handleTabClick('/chat')}
          >
            <FontAwesomeIcon icon={faCommentDots} className="icon" />
            {!isCollapsed && <span>Messages</span>}
          </a>
        </li>

        {/* Notifications */}
        <li className="nav-item">
          <button
            className={`tab-link NotificationsPage ${activeTab === '/notifications' ? 'active' : ''}`}
            onClick={() => handleTabClick('/notifications')}
          >
            <FontAwesomeIcon icon={faBell} className="icon" />
            {!isCollapsed && <span>Notifications</span>}
          </button>
          <NotificationsPage isOpen={isDrawerOpen} onClose={() => setIsDrawerOpen(false)} />
        </li>

        {/* Profile */}
        <li className="nav-item">
          <a
            className={`tab-link ${activeTab === '/profile' ? 'active' : ''}`}
            href="/profile"
            onClick={() => handleTabClick('/profile')}
          >
            <FontAwesomeIcon icon={faUser} className="icon" />
            {!isCollapsed && <span>Profile</span>}
          </a>
        </li>
      </ul>
    </div>
  );
}

export default Sidebar;

import React, { useState, useEffect } from "react";
import { useLocation, NavLink } from "react-router-dom"; // 1. Import NavLink
import "./Sidebar.css"; // CSS của Sidebar
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faHome,
  faThLarge,
  faCommentDots,
  faBell,
  faUser,
  faSun,
  faMoon,
} from "@fortawesome/free-solid-svg-icons";
import NotificationsPage from "../../pages/notificationPage";

function Sidebar() {
  const location = useLocation(); // Keep useLocation for the Notifications button active state if needed
  // const [activeTab, setActiveTab] = useState("/Home"); // 2. Remove activeTab state
  const [isCollapsed, setIsCollapsed] = useState(false);
  const [isDrawerOpen, setIsDrawerOpen] = useState(false);

  const [isLightMode, setIsLightMode] = useState(() => {
    const savedTheme = localStorage.getItem("theme");
    return savedTheme === "light";
  });

  useEffect(() => {
    const currentTheme = isLightMode ? "light" : "dark";
    document.documentElement.setAttribute("data-theme", currentTheme);
    localStorage.setItem("theme", currentTheme);
  }, [isLightMode]);

  // 4. Simplify or adjust click handlers
  const handleNavigationClick = () => {
    // This function is called when a NavLink is clicked
    if (isDrawerOpen) {
      setIsDrawerOpen(false); // Close the notifications drawer if it's open
    }
  };

  const handleNotificationsClick = () => {
    setIsDrawerOpen(!isDrawerOpen);
  };

  const toggleSidebar = () => {
    setIsCollapsed(!isCollapsed);
    const mainContent = document.querySelector(".main-content");
    if (mainContent) {
      mainContent.style.marginLeft = !isCollapsed ? "100px" : "250px";
    }
  };

  const handleThemeChange = (event) => {
    setIsLightMode(event.target.checked);
  };

  return (
    <div className={`sidebar ${isCollapsed ? "collapsed" : ""}`}>
      <div className="toggle-button" onClick={toggleSidebar}>
        <FontAwesomeIcon icon={faThLarge} />
      </div>

      <h2 className="text-center">Multi Aura</h2>

      <ul className="nav flex-column">
        {/* Home */}
        <li className="nav-item">
          {/* 5. Replace <a> with <NavLink> */}
          <NavLink
            to="/Home" // 6. Use 'to' prop instead of 'href'
            // 7. Dynamically set className using isActive from NavLink
            className={({ isActive }) =>
              "tab-link" + (isActive ? " active" : "")
            }
            onClick={handleNavigationClick} // 8. Call simplified click handler
          >
            <FontAwesomeIcon icon={faHome} className="icon" />
            {!isCollapsed && <span>Home</span>}
          </NavLink>
        </li>

        {/* Explore */}
        <li className="nav-item">
          <NavLink
            to="/explore"
            className={({ isActive }) =>
              "tab-link" + (isActive ? " active" : "")
            }
            onClick={handleNavigationClick}
          >
            <FontAwesomeIcon icon={faThLarge} className="icon" />
            {!isCollapsed && <span>Explore</span>}
          </NavLink>
        </li>

        {/* Messages */}
        <li className="nav-item">
          <NavLink
            to="/chat"
            className={({ isActive }) =>
              "tab-link" + (isActive ? " active" : "")
            }
            onClick={handleNavigationClick}
          >
            <FontAwesomeIcon icon={faCommentDots} className="icon" />
            {!isCollapsed && <span>Messages</span>}
          </NavLink>
        </li>

        {/* Notifications */}
        <li className="nav-item">
          <button
            // Keep manual active state for Notifications button based on drawer or specific logic
            className={`tab-link NotificationsPage ${ // Assuming NotificationsPage class is for specific button styling
              isDrawerOpen || location.pathname === "/notifications" ? "active" : "" // Active if drawer is open or if /notifications is a distinct route being shown
            }`}
            style={{ backgroundColor: "transparent" }} // This inline style might be better in CSS
            onClick={handleNotificationsClick}
          >
            <FontAwesomeIcon icon={faBell} className="icon" />
            {!isCollapsed && <span>Notifications</span>}
          </button>
          <NotificationsPage
            isOpen={isDrawerOpen}
            onClose={() => setIsDrawerOpen(false)}
          />
        </li>

        {/* Profile */}
        <li className="nav-item">
          <NavLink
            to="/profile"
            className={({ isActive }) =>
              "tab-link" + (isActive ? " active" : "")
            }
            onClick={handleNavigationClick}
          >
            <FontAwesomeIcon icon={faUser} className="icon" />
            {!isCollapsed && <span>Profile</span>}
          </NavLink>
        </li>

        {/* Light/Dark Mode */}
        <li className="nav-item">
          <label
            htmlFor="Light-Dark-mode-checkbox" // Corrected to htmlFor
            className="switch tab-link"
            style={{ cursor: "pointer" }}
          >
            <FontAwesomeIcon
              icon={isLightMode ? faMoon : faSun}
              className="icon"
            />
            <input
              id="Light-Dark-mode-checkbox"
              type="checkbox"
              onChange={handleThemeChange}
              checked={isLightMode}
              hidden
            />
            {!isCollapsed && (
              <span>{isLightMode ? "Dark Mode" : "Light Mode"}</span>
            )}
          </label>
        </li>
      </ul>
    </div>
  );
}

export default Sidebar;
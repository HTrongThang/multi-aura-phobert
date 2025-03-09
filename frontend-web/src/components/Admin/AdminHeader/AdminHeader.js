import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { useNavigate } from 'react-router-dom';
import Cookies from 'js-cookie';

import './AdminHeader.css';

const Header = ({ toggleSidebar, isSidebarOpen }) => {
    const navigate = useNavigate();
    const [dataUser, setDataUser] = useState(null);
    const [isDropdownOpen, setDropdownOpen] = useState(false);

    useEffect(() => {
        const storedUser = localStorage.getItem('user');
        if (storedUser) {
            setDataUser(JSON.parse(storedUser));
        }
    }, []);

    const toggleDropdown = () => {
        setDropdownOpen((prevState) => !prevState);
    };

    const handleLogout = async () => {
        Cookies.remove('authToken');
        localStorage.removeItem('user');
        setDataUser(null);
        navigate('/login');
    };

    return (
        <header className="header-admin d-flex align-items-center justify-content-between p-3 bg-light border-bottom">
            {/* Sidebar Toggle Button */}
            <div className="d-flex align-items-center">
                {!isSidebarOpen && (
                    <button className="btn toggle-sidebar-btn" onClick={toggleSidebar}>
                        <FontAwesomeIcon icon={faBars} />
                    </button>
                )}
            </div>

            {/* Admin Info */}
            <div className="admin-info d-flex align-items-center ml-auto dropdown">
                <div
                    className="admin-header"
                    onClick={toggleDropdown} // Toggle dropdown on click
                >
                    <img
                        src={
                            dataUser?.data?.avatar ||
                            'https://res.cloudinary.com/dlym0sypp/image/upload/v1732856350/profile-photos/profile-photos/1732856349_3ccf02e5-5e71-488c-b428-c36efb22411e.jpg'
                        }
                        alt="Admin Avatar"
                        className="admin-avatar rounded-circle"
                    />
                    <span className="admin-name ml-2">{dataUser?.username || 'Admin'}</span>
                </div>

                {/* Dropdown Menu */}
                <ul className={`dropdown-menu custom-dropdown ${isDropdownOpen ? 'show' : ''}`}>
                    <li>
                        <button className="dropdown-item" onClick={handleLogout}>
                            <FontAwesomeIcon icon={faSignOutAlt} /> Đăng xuất
                        </button>
                    </li>
                </ul>
            </div>
        </header>
    );
};

export default Header;

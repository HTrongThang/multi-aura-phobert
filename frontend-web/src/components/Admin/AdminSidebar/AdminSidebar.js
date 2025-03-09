import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom'; // Import useLocation để lấy thông tin đường dẫn hiện tại
import Logo from '../../Logo/Logo';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCube, faFileAlt, faChevronLeft } from '@fortawesome/free-solid-svg-icons';
import './AdminSidebar.css';

const AdminSidebar = ({ toggleSidebar, isOpen }) => {
    const location = useLocation(); // Sử dụng useLocation để theo dõi đường dẫn hiện tại
    const [selectedItem, setSelectedItem] = useState(location.pathname);

    // Cập nhật selectedItem khi đường dẫn thay đổi
    useEffect(() => {
        setSelectedItem(location.pathname);
    }, [location]);

    const handleItemClick = (item) => {
        setSelectedItem(item);
    };

    return (
        <div className={`admin-sidebar ${isOpen ? 'open' : 'collapsed'} d-flex flex-column`}>
            {isOpen && (
                <div className="sidebar-header p-3">
                    <Logo />
                </div>
            )}
            <nav className="nav flex-column flex-grow-1">
                <Link
                    to="/admin/"
                    className={`custom-nav-link d-flex align-items-center ${selectedItem === '/admin/Emhun' ? 'custom-selected' : ''}`}
                    onClick={() => handleItemClick('/admin/')}
                >
                    <div className="icon"><FontAwesomeIcon icon={faFileAlt} /> </div>
                    <span>Dashboard</span>
                </Link>
                <Link
                    to="/admin/PostManagement"
                    className={`custom-nav-link d-flex align-items-center ${selectedItem === '/admin/ProductManagement' ? 'custom-selected' : ''}`}
                    onClick={() => handleItemClick('/admin/PostManagement')}
                >
                    <div className="icon"><FontAwesomeIcon icon={faCube} /> </div>
                    <span>Toxic Post Management</span>
                </Link>
               
            </nav>
            {isOpen && (
                <div className="sidebar-footer p-3">
                    <button className="btn btn-link text-white" onClick={toggleSidebar}>
                         <FontAwesomeIcon icon={faChevronLeft} />
                    </button>
                </div>

            )}
        </div>
    );
};

export default AdminSidebar;

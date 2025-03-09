import React, { useState } from 'react';
import AdminSidebar from '../../components/Admin/AdminSidebar/AdminSidebar';
import Header from '../../components/Admin/AdminHeader/AdminHeader';
import { Container, Row, Col } from 'react-bootstrap';
import './AdminLayout.css';

function AdminLayout({ children }) {
    const [isSidebarOpen, setIsSidebarOpen] = useState(true);

    const toggleSidebar = () => {
        setIsSidebarOpen(!isSidebarOpen);
    };

    return (
        <div className="admin-layout">
            {isSidebarOpen && <AdminSidebar toggleSidebar={toggleSidebar} isOpen={isSidebarOpen} />}
            <main className={`admin-main-content ${isSidebarOpen ? 'sidebar-open' : 'sidebar-closed'}`}>
                <Header toggleSidebar={toggleSidebar} isSidebarOpen={isSidebarOpen} />
                <Container fluid className="mt-4">
                    <Row>
                        <Col>
                                {children}
                        </Col>
                    </Row>
                </Container>
            </main>
        </div>
    );
}

export default AdminLayout;

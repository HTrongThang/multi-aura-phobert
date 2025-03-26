import React, { useState, useEffect } from 'react';
import './ErrorModal.css';

const ErrorModal = ({ title, description, onClose }) => {
    const [showModal, setShowModal] = useState(true);

    useEffect(() => {
        const timer = setTimeout(() => {
            setShowModal(false); // Đóng modal sau khi hiển thị 6 giây
        }, 6000);

        return () => clearTimeout(timer); // Dọn dẹp khi component bị unmount
    }, []);

    useEffect(() => {
        if (!showModal) {
            const timer = setTimeout(() => {
                onClose(); // Gọi onClose sau khi modal ẩn
            }, 300);
            return () => clearTimeout(timer);
        }
    }, [showModal, onClose]);

    return (
        <div className={`error-modal-overlay ${showModal ? 'show' : 'hide'}`}>
            <div className="error-modal-container">
                <div className="error-modal-content">
                    {title && <h2 className="error-modal-title"> {title}</h2>}
                    {description && <p className="error-modal-description">{description}</p>}
                </div>
            </div>
        </div>
    );
};

export default ErrorModal;

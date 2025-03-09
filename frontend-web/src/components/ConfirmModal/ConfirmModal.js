import React from "react";
import "./ConfirmModal.css"; // Đảm bảo có file CSS này

const ConfirmModal = ({ slogan, message, onConfirm, onCancel }) => {
    return (
        <div className="confirm-modal-overlay">
            <div className="confirm-modal-container">
                <div className="confirm-modal-header">
                    <p>{slogan}</p>
                </div>
                <div className="confirm-modal-message">
                    <p>{message}</p>
                </div>
                <div className="confirm-modal-actions-cancel">
                    <button className="confirm-modal-cancel" onClick={onCancel}>
                        Hủy
                    </button>
                </div>
                <div className="confirm-modal-actions-confirm">
                    <button className="confirm-modal-confirm" onClick={onConfirm}>
                        Xác nhận
                    </button>
                </div>
            </div>


        </div>
    );
};

export default ConfirmModal;

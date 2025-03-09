import React from "react";
import { MapContainer, TileLayer, Marker, Popup, useMapEvents } from "react-leaflet";
import "leaflet/dist/leaflet.css";
import "./MapModal.css";

// Component con để lắng nghe sự kiện click
const MapClickHandler = ({ onMapClick }) => {
    useMapEvents({
        click(e) {
            // Lấy vị trí tọa độ nơi người dùng bấm
            const { lat, lng } = e.latlng;
            onMapClick({ lat, lng }); // Gửi tọa độ về parent component
        },
    });
    return null; // Không cần render gì
};

const MapModal = ({ show, onClose, location, onMapClick }) => {
    if (!show || !location) return null;

    return (
        <div className="map-overlay">
            <div className="map-container">
                <button className="close-map-btn" onClick={onClose}>
                    Đóng
                </button>
                <MapContainer
                    center={location}
                    zoom={15}
                    style={{ height: "400px", width: "100%" }}
                >
                    <TileLayer
                        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    />
                    {/* Thêm Marker nếu có vị trí hiện tại */}
                    {location && (
                        <Marker position={location}>
                            <Popup>Vị trí hiện tại của bạn</Popup>
                        </Marker>
                    )}
                    {/* Lắng nghe sự kiện click */}
                    <MapClickHandler onMapClick={onMapClick} />
                </MapContainer>
            </div>
        </div>
    );
};

export default MapModal;

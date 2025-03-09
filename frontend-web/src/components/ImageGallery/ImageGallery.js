import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './ImageGallery.css'; // File CSS tùy chỉnh
import PostDetail from '../PostDetail/PostDetail';

const ImageGallery = ({ posts, userData }) => {
    const [isDetailOpen, setIsDetailOpen] = useState(false);
    const [currentPost, setCurrentPost] = useState(null); // Store current post details
    const navigate = useNavigate();

    // Function to handle image click and navigate to post detail
    const handleImageClick = (postId) => {
        navigate(`/posts/${postId}`);
    };

    // Function to open post details
    const openDetail = (post) => {
        setCurrentPost(post);
        setIsDetailOpen(true);
    };

    // Function to close post details
    const closeDetail = () => {
        setIsDetailOpen(false);
        setCurrentPost(null);
    };

    if (!posts || posts.length === 0) {
        return <p>No images available.</p>;
    }

    return (
        <div className="my-image-gallery">
            {posts.map((post) => (
                <div key={post._id} className="my-image-item">
                    <img
                        src={post.images[0].url}
                        alt={`Post ${post._id}`}
                        onClick={() => openDetail(post)} // Open post detail when clicked
                        className="my-gallery-image"
                    />
                    <p className="my-image-title">{post.description}</p> {/* Tiêu đề bài viết */}
                </div>
            ))}

            {isDetailOpen && currentPost && (
                <PostDetail 
                    post={currentPost} 
                    closeDetail={closeDetail} 
                    userCurent={userData} 
                />
            )}
        </div>
    );
};

export default ImageGallery;

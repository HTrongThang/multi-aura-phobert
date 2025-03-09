import React, {useState } from 'react';
import { Card, Button, CardFooter } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import PostDetail from '../../PostDetail/PostDetail';
const getToxicColor = (toxicityScore) => {
    if (toxicityScore < 0.5) {
        return 'text-success'; 
    } else if (toxicityScore >= 0.5 && toxicityScore < 0.7) {
        return 'text-warning'; 
    } else {
        return 'text-danger'; 
    }
};

const PostCard = ({ post, onDelete  }) => {
    const [isDetailOpen, setIsDetailOpen] = useState(false);  

    const openDetail = () => {
        setIsDetailOpen(true); 
    };

    const closeDetail = () => {
        setIsDetailOpen(false);  
    };
    const handleDelete = async () => {
        try {
            onDelete(post._id);  
        } catch (error) {
            console.error('Error deleting post:', error);
            alert('Failed to delete post. Please try again.');
        }
    };
    const formattedDate = new Date(post.createdAt).toLocaleString('vi-VN', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit',
        second: '2-digit',
        hour12: false
    });

    return (
        <div className="col-sm-12 col-md-6 col-lg-4 mb-4" >
            <Card className="h-100" onClick={openDetail}> 
                <Card.Body>
                    <Card.Title>{post.description}</Card.Title>
                    
                    <Card.Text>{post.description}</Card.Text>

                    {/* Hình ảnh bài đăng */}
                    {post.images && post.images.length > 0 && (
                        <img
                            src={post.images[0].url}
                            alt="Post Image"
                            className="img-fluid"
                            style={{ maxHeight: '200px', height: '200px', objectFit: 'cover' }}
                        />
                    )}

                    <div className="d-flex justify-content-between">
                        <span>Posted by: {post.createdBy?.username}</span>
                        <span className={getToxicColor(post.toxicityScore)}>
                            {Math.round(post.toxicityScore * 100)}% Toxic
                        </span>
                    </div>
                    <div className="d-flex justify-content-between">
                        <span>Posted date: {formattedDate}</span>
                    </div>
                </Card.Body>
                <Card.Footer className="d-flex justify-content-between">
                    <Button variant="primary" onClick={openDetail}  className="view-details-button mt-3 text-black">View Details</Button>
                    <Button variant="danger" onClick={handleDelete}>Delete Post</Button>
                </Card.Footer>
            </Card>
            {isDetailOpen && (
                <PostDetail post={post} closeDetail={closeDetail} />
            )}
        </div>
    );
};

export default PostCard;

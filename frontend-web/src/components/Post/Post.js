import React, { useState, useRef } from 'react';
import './Post.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faThumbsUp, faCommentDots, faShare, faHeart, faBookmark } from '@fortawesome/free-solid-svg-icons';
import { FaVolumeUp, FaPauseCircle, FaPlayCircle, FaKeyboard } from 'react-icons/fa';
import { Carousel } from 'react-bootstrap'; // Import Carousel từ Bootstrap
import { CommentPost, likePost, unlikePost, uploadVoiceComment } from '../../services/exploreSevice';
import PostDetail from '../PostDetail/PostDetail';
import soundWave from '../../assets/img/audio_wave.gif';

function Post({ post, userData, deletePost }) {
  console.log(deletePost);
  const userCurent = userData?.userID || null;  // Lấy userID của người dùng hiện tại
  const [showAllImages, setShowAllImages] = useState(false);
  const [commentText, setCommentText] = useState('');
  const [isPlaying, setIsPlaying] = useState(false);
  const [icon, setIcon] = useState(<FaPlayCircle size={30} />);
  const [liked, setLiked] = useState(post.likedBy.some(user => user.userID === userCurent));
  const [bookmarked, setBookmarked] = useState(false);
  const [likesCount, setLikesCount] = useState(post?.likedBy.length || 0);
  const [CommentCount, setCommentCount] = useState(post?.comments?.length || 0);
  const [ShareCount, setShareCount] = useState(post?.sharedBy?.length || 0);
  const [isDetailOpen, setIsDetailOpen] = useState(false);
  const [showInput, setShowInput] = useState(false);
  const audioRef = useRef(null);
  const [shareText, setShareText] = useState('');
  const openDetail = () => {
    setIsDetailOpen(true);
  };
  const handleInputtextClick = () => {
    setShowInput(!showInput); // Chuyển đổi trạng thái hiển thị input
  };

  // Hàm để đóng chi tiết bài đăng
  const closeDetail = () => {
    setIsDetailOpen(false);
  };
  const handleImageClick = () => {
    setShowAllImages(!showAllImages); // Toggle việc hiển thị toàn bộ ảnh
  };

  const handlePlayPause = () => {
    const audio = audioRef.current;

    if (!audio) return;

    if (isPlaying) {
      audio.pause();
    } else {
      audio.play().catch((error) => {
        console.error('Error playing audio:', error);
      });
    }
    setIcon(isPlaying ? <FaPlayCircle size={30} /> : <FaPauseCircle size={30} />);
    setIsPlaying(!isPlaying);
  };

  const handleKeyDown = (event, postID) => {
    if (event.key === 'Enter' && commentText.trim()) {
      handlePostComment(postID);
    }
  };


  const renderImages = () => {
    const imageCount = post.images.length;

    if (imageCount === 1) {
      return (
        <img
          src={post.images[0].url}
          alt="Post"
          className="img-post img-fluid rounded mb-4"
          style={{
            width: '600px',
            height: 'auto',
            objectFit: 'contain',
            display: 'block',
          }}
        />
      );
    }
    if (imageCount === 2) {
      return (
        <div className="image-row d-flex">
          {post.images.map((image, index) => (
            <img
              key={index}
              src={image.url}
              alt={`Post ${index}`}
              className="img-fluid rounded"
              style={{
                width: '60%',
                marginRight: index === 0 ? '4%' : '0',
                objectFit: 'cover', // Đảm bảo ảnh được cắt bớt phù hợp
              }}
            />
          ))}
        </div>
      );
    }
    if (imageCount > 2) {
      return (
        <div className="image-row">
          <Carousel>
            {post.images.map((image, index) => {
              return (
                <Carousel.Item key={index}>
                  <div className="carousel-image-row">
                    <img
                      className="d-block"
                      src={image.url}
                      alt={`Slide ${index}`}
                      style={{
                        objectFit: 'contain',
                        maxHeight: '700px',
                      }}
                    />
                  </div>
                </Carousel.Item>
              );
            })}
          </Carousel>
        </div>
      );
    }

    return null;
  };

  const handlePostComment = async (postID) => {
    if (!commentText.trim()) return;

    try {
      const response = await CommentPost(postID, commentText);
      const commentid = response?.data?._id;
      if (response.status === 201) {
        const uploadComemntVoid = await uploadVoiceComment(commentid, shareText);
        setCommentCount(CommentCount + 1);
        setCommentText('');
        setShareText('');
      }

    } catch (error) {
      console.error("Error posting comment:", error);
    }


  };

  const handleLike = async (postID) => {
    setLiked(!liked);

    try {
      if (liked) {

        const response = await unlikePost(postID);
        setLikesCount(likesCount - 1);
        setLiked(false);
      } else {
        const response = await likePost(postID);
        setLikesCount(likesCount + 1);
        setLiked(true);
      }
    } catch (error) {
      console.log("Error API like/unlike post:", error);
    }
  };




  const handleShare = () => {
    console.log('Chia sẻ bài viết');
  };

  const handleBookmark = () => {
    setBookmarked(!bookmarked); // Chuyển đổi trạng thái "bookmarked"
    console.log(bookmarked ? 'Đã bỏ lưu' : 'Đã lưu bài viết');
  };
  return (
    <div className="post p-3 mb-4 rounded shadow-sm text-white">
      <div className="post-header" onClick={openDetail}>
        <div className="d-flex align-items-center mb-2" style={{ height: '100%' }}>
          <div className="avatar-container">
            <img
              src={post.createdBy.avatar || 'https://firebasestorage.googleapis.com/v0/b/multi-aura.appspot.com/o/Hihon%2F393107bb-4c20-44d9-9022-9c900b6b3b71.jpg?alt=media&token=5e41e599-4b72-432b-beb9-6363b2e7b0ce'}
              alt="Avatar"
              className="avatar rounded-circle"
            />
          </div>

          <div className="ml-3">
            <h5 className="text-fullname">{post.createdBy.fullname}</h5>
            <p className="text-time">{new Date(post.createdAt).toLocaleString()}</p>
          </div>
        </div>

        {/* Đoạn ghi âm với biểu tượng play/pause */}
        <p className="content-post">
          <span className="post-description">{post.description}</span>


        </p>

        {post.voice && (
          <div className="post-audio-controls">
            <button onClick={handlePlayPause} className="btn audio-btn audio-post-play">
              <img
                src={soundWave}
                alt={isPlaying ? 'Pause' : 'Play'}
                className="post-audio-icon"
              />
            </button>
            <audio ref={audioRef} src={post.voice} />
          </div>
        )}

        {renderImages()}


        {showAllImages && (
          <div className="image-grid">
            {post.images.map((image, index) => (
              <img key={index} src={image.url} alt={`Post ${index}`} className="img-fluid rounded mb-4" />
            ))}
          </div>
        )}

      </div>
      {isDetailOpen && (
    <>
        {console.log("deletePost in PostDetail:", deletePost)}  {/* In ra giá trị của deletePost */}
        <PostDetail 
            post={post} 
            closeDetail={closeDetail} 
            userCurent={userCurent} 
            deletePost={deletePost} 
        />
    </>
)}

      <div className="d-flex justify-content-between align-items-center" style={{ width: "85%" }}>
        <div className="d-flex">

          <button
            className="btn btn-link text-white mr-3" style={{ border: "none" }}
            onClick={() => handleLike(post._id)}
          >
            <FontAwesomeIcon icon={faHeart} color={liked ? 'red' : 'white'} style={{ border: "none" }} />

            <span className="likes-count" style={{ border: "none" }}>{likesCount}</span>

          </button>

          <button className="btn btn-link text-white mr-3" >
            <FontAwesomeIcon icon={faCommentDots} />
            <span className="likes-count" style={{ border: "none" }}>{CommentCount}</span>

          </button>
          <button className="btn btn-link text-white mr-3" onClick={handleShare}>
            <FontAwesomeIcon icon={faShare} />
            <span className="likes-count" style={{ border: "none" }}>{ShareCount}</span>

          </button>
          <button className="btn btn-link text-white mr-3" onClick={handleInputtextClick}>
            <FaKeyboard size={20} />
            <span className="likes-count" style={{ border: "none" }}></span>
          </button>
        </div>
        <button className="btn btn-link text-white" onClick={handleBookmark}>
          <FontAwesomeIcon icon={faBookmark} color={bookmarked ? 'yellow' : 'white'} />
        </button>
      </div>
      {showInput && (
        <input
          type="text"
          className="input-voice mt-2"
          placeholder="Nhập chia sẻ..."
          value={shareText}
          onChange={(e) => setShareText(e.target.value)}
          onKeyDown={(e) => handleKeyDown(e)}
        />
      )}
      <div className="d-flex mt-3">
        <input
          type="text"
          className="form-control comment-text"
          placeholder="Add a comment..."
          value={commentText}
          onChange={(e) => setCommentText(e.target.value)}
          onKeyDown={(event) => handleKeyDown(event, post._id)}

        />
        <button className="btn btn-outline-light ml-2"
          onClick={() => handlePostComment(post._id)}
          disabled={!commentText.trim()}
        >
          Đăng
        </button>
      </div>
    </div>
  );
}

export default Post;

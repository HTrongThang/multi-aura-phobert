import React, { useEffect, useRef, useState } from "react";
import "./PostDetail.css";
import Gallery from "react-image-gallery";
import {
  FaEllipsisV,
  FaVolumeUp,
  FaPauseCircle,
  FaPlayCircle,
} from "react-icons/fa";
import "react-image-gallery/styles/css/image-gallery.css"; // Import style của thư viện
import { format } from "date-fns";
import { FaHeart, FaReply } from "react-icons/fa";
import CommentsList from "../CommentsList/CommentsList";
import {
  CommentPost,
  GetCommentByID,
  DeletePost,
  uploadVoiceComment,
} from "../../services/exploreSevice";
import { getToxicComment } from "../../services/toxicService";
import ErrorModal from "../../components/errorModal/ErrorModal";

import soundWave from "../../assets/img/audio_wave.gif";

// Component to display the post creator's information
function PostCreator({
  avatar,
  fullname,
  createdAt,
  IsUserPost,
  onMenuToggle,
}) {
  return (
    <div className="post-detail-header">
      <div className="post-detail-header-title">
        <div className="post-detail-header-left">
          <img src={avatar} alt="Avatar" className="post-detail-avatar" />
        </div>
        <div className="post-detail-header-right">
          <p className="post-detail-username">{fullname}</p>
          <p className="post-detail-fullname">
            {createdAt
              ? format(new Date(createdAt), "dd/MM/yyyy")
              : "Ngày không hợp lệ"}
          </p>
        </div>
      </div>
      {IsUserPost ? (
        <div className="post-detail-header-actions">
          <FaEllipsisV
            className="post-detail-ellipsis"
            onClick={onMenuToggle}
          />
        </div>
      ) : null}
    </div>
  );
}

function PostDetail({ post, closeDetail, userCurent, deletePost }) {
  const overlayRef = useRef(null);
  const audioRef = useRef(null); // Audio ref
  const [commentText, setCommentText] = useState("");
  const [isPlaying, setIsPlaying] = useState(false); // Moved inside the component
  const [icon, setIcon] = useState(<FaPlayCircle size={30} />); // Moved inside the component
  const [comments, setComments] = useState(post.comments || []);
  const [showMenu, setShowMenu] = useState(false); // Trạng thái menu
  const IsUserPost = post?.createdBy?.userID === userCurent;
  const [showInput, setShowInput] = useState(false);
  const [shareText, setShareText] = useState("");
  const [showError, setShowError] = useState(false);
  // Handle play/pause audio
  const handlePlayPause = () => {
    const audio = audioRef.current;

    if (!audio) return;

    if (isPlaying) {
      audio.pause();
    } else {
      audio.play().catch((error) => {
        console.error("Error playing audio:", error);
      });
    }
    setIcon(
      isPlaying ? <FaPlayCircle size={30} /> : <FaPauseCircle size={30} />
    );
    setIsPlaying(!isPlaying);
  };

  // Close the post detail when clicking outside the component
  const handleClickOutside = (e) => {
    if (overlayRef.current && !overlayRef.current.contains(e.target)) {
      closeDetail();
    }
  };

  useEffect(() => {
    document.addEventListener("mousedown", handleClickOutside);
    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, []);

  const handleGetComment = async (postID) => {
    try {
      const response = await GetCommentByID(postID);
      setComments(response.data);
    } catch (error) {
      console.error("Error posting comment:", error);
    }
    setCommentText("");
  };

  useEffect(() => {
    if (post && post._id) {
      handleGetComment(post._id);
    }
  }, [post._id]);

  const handleCommentSubmit = async (postID) => {
    if (commentText.trim()) {
      try {
        const responseCmt = await getToxicComment(commentText);

        if (responseCmt === 2) {
          setShowError(true);
        } else {
          try {
            debugger;
            const response = await CommentPost(postID, commentText);
            const commentid = response?.data?._id;

            if (response.status === 201) {
              if (shareText.trim()) {
                const uploadCommentVoice = await uploadVoiceComment(
                  commentid,
                  shareText
                );
              }
              handleGetComment(postID);
              setCommentText("");
              setShareText("");
            }
          } catch (error) {
            console.error("Error posting comment:", error);
          }
        }
      } catch (error) {
        console.log("Error checking toxic comment", error);
      }
    }
  };

  const renderImages = (images) => {
    if (!images || images.length === 0) {
      return <p>Không có ảnh để hiển thị.</p>;
    }

    const galleryImages = images.map((image) => {
      const isSmallImage = image.width < 600;

      return {
        original: image.url,
        thumbnail: image.url,
        originalClass: isSmallImage ? "resize-image" : "large-image",
      };
    });

    return (
      <div className="custom-gallery-wrapper">
        <Gallery
          items={galleryImages}
          showThumbnails={false}
          showPlayButton={false}
          showFullscreenButton={false}
        />
      </div>
    );
  };

  const handleMenuToggle = () => {
    setShowMenu((prev) => !prev);
  };

  const handleDeletePost = async () => {
    deletePost(post._id);
    closeDetail();
  };

  return (
    <div className="post-detail-overlay">
      <div className="post-detail-container" ref={overlayRef}>
        <div className="post-detail-left">{renderImages(post.images)}</div>

        <div className="post-detail-right">
          <PostCreator
            avatar={post.createdBy.avatar}
            fullname={post.createdBy.fullname}
            createdAt={post.createdAt}
            IsUserPost={IsUserPost}
            onMenuToggle={handleMenuToggle}
          />

          {showMenu && IsUserPost && (
            <div className="post-menu">
              <button
                onClick={handleDeletePost}
                className="delete-button btn btn-outline-light"
              >
                Xóa bài
              </button>
            </div>
          )}

          <div className="post-detail-description">
            <p className="post-description-details ">{post.description}</p>

            {post.voice && (
              <div className="audio-controls">
                <button
                  onClick={handlePlayPause}
                  className="btn comment-audio-btn"
                >
                  <img
                    src={soundWave}
                    alt={isPlaying ? "Pause" : "Play"}
                    className="comment-audio-icon"
                  />
                </button>
                <audio ref={audioRef} src={post.voice} />
              </div>
            )}
          </div>

          <CommentsList comments={comments} />

          <div className="post-detail-add-comment">
            <div className="input-container">
              {showInput && (
                <input
                  type="text"
                  className="share-input"
                  placeholder="Chia sẻ nội dung..."
                  value={shareText}
                  onChange={(e) => setShareText(e.target.value)}
                  aria-label="Chia sẻ nội dung"
                  style={{ marginBottom: "10px" }}
                />
              )}
              <div className="comment-input-container">
                <input
                  type="text"
                  className="comment-input"
                  placeholder="Thêm bình luận..."
                  value={commentText}
                  onChange={(e) => setCommentText(e.target.value)}
                  onKeyDown={(e) => {
                    if (e.key === "Enter" && commentText.trim()) {
                      handleCommentSubmit(post._id);
                    }
                  }}
                  aria-label="Thêm bình luận"
                />
              </div>
              <button
                className={`show-Input-Comment${showInput ? " show" : ""}`}
                onClick={() => setShowInput(!showInput)}
              >
                <i className="fas fa-keyboard ml-2"></i>
              </button>

              <button
                className={`comment-submit-button${showInput ? " show" : ""} ${
                  commentText.trim() ? "active" : ""
                }`}
                onClick={() => handleCommentSubmit(post._id)}
                aria-label="Gửi bình luận"
                disabled={!commentText.trim()}
              >
                <i className="fas fa-paper-plane"></i>
              </button>
            </div>
            {showError && (
              <ErrorModal
                title={<span>Cảnh Báo: Bình luận không phù hợp</span>}
                description={
                  <span>
                    <i
                      className="fas fa-heart"
                      style={{ color: "#ff4d4d", marginRight: "8px" }}
                    ></i>
                    Bình luận của bạn chứa ngôn ngữ không phù hợp. Vui lòng điều
                    chỉnh lại để tuân thủ quy định cộng đồng.
                  </span>
                }
                onClose={() => setShowError(false)} // Đóng modal khi cần
              />
            )}
          </div>
        </div>
      </div>
    </div>
  );
}

export default PostDetail;

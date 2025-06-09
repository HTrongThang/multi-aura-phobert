import React, { useState, useRef, useEffect } from "react";
import { FaHeart, FaReply } from "react-icons/fa";
import "./CommentItem.css";
import {
  addReplyComment,
  LikeComment,
  unLikeComment,
  uploadVoiceComment,
  uploadVoiceReply,
} from "../../services/exploreSevice";
import soundWave from "../../assets/img/audio_wave.gif";
import { Link } from "react-router-dom";
const CommentItem = ({ comment }) => {
  const [likesCount, setLikesCount] = useState(comment?.likedBy.length || 0);
  const [showReplies, setShowReplies] = useState(false);
  const [likedComments, setLikedComments] = useState({});
  const [isReplying, setIsReplying] = useState(false);
  const [replyText, setReplyText] = useState("");
  const replies = Array.isArray(comment.replies) ? comment.replies : [];
  const [isPlaying, setIsPlaying] = useState(false); // Moved inside the component
  const audioRef = useRef(null); // Audio ref
  const [isFocusing, setIsFocusing] = useState(false);
  const [replyingTo, setReplyingTo] = useState(null);

  const [replyTextPart1, setReplyTextPart1] = useState("");
  const [replyTextPart2, setReplyTextPart2] = useState("");

  const [userData, setUserData] = useState(null);

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    if (storedUser) {
      setUserData(JSON.parse(storedUser));
    }
  }, []);

  const UserNameCurrent = userData?.username;

  useEffect(() => {
    setLikedComments((prevState) => ({
      ...prevState,
      [comment._id]: comment.likedBy.includes(UserNameCurrent),
    }));
  }, [comment, UserNameCurrent]);

  const handleLikeComment = async () => {
    const newLikedState = !likedComments[comment._id];

    try {
      setLikedComments((prevState) => ({
        ...prevState,
        [comment._id]: newLikedState,
      }));

      if (newLikedState) {
        setLikesCount(likesCount + 1);
        await LikeComment(comment._id); // Like comment
      } else {
        setLikesCount(likesCount - 1);
        await unLikeComment(comment._id); // Unlike comment
      }
    } catch (error) {
      console.error("Error while handling like/unlike for comment:", error);
    }
  };
  const handleInputFocus = () => setIsFocusing(true);

  const handleInputBlur = () => {
    setTimeout(() => {
      setIsFocusing(false);
      if (!isFocusing) setIsReplying(false);
    }, 200);
  };

  const handleReply = (username) => {
    setReplyingTo(username);
    setIsReplying(true);
    setIsReplying(!isReplying);
  };

  const handleReplyChange = (event) => {
    setReplyText(event.target.value);
  };
  const handleLikeReply = async (replyId) => {};

  const handleSubmitReply = async (
    CommentId,
    replyTextPart1,
    replyTextPart2
  ) => {
    if (!replyTextPart1.trim()) return;
    try {
      const response = await addReplyComment(
        CommentId,
        replyTextPart1,
        replyingTo
      );
      setReplyTextPart1("");
      setReplyingTo(null);
      const replyid = response?.data?._id;
      if (response.status === 201) {
        console.log(replyTextPart2);
        const uploadComemntVoice = await uploadVoiceReply(
          CommentId,
          replyid,
          replyTextPart2
        );
        setReplyTextPart2("");
      }
      setIsReplying(false);
    } catch (error) {
      console.error("Lỗi khi gửi câu trả lời:", error);
    }
  };

  const toggleReplies = () => {
    setShowReplies((prevState) => !prevState);
  };

  const getTimeAgo = (createdAt) => {
    const now = new Date();
    const commentTime = new Date(createdAt);
    const diffInMs = now - commentTime;

    const diffInMinutes = Math.floor(diffInMs / (1000 * 60));
    const diffInHours = Math.floor(diffInMs / (1000 * 60 * 60));
    const diffInDays = Math.floor(diffInMs / (1000 * 60 * 60 * 24));

    if (diffInMinutes < 60) {
      return `${diffInMinutes} phút trước`;
    } else if (diffInHours < 24) {
      return `${diffInHours} giờ trước`;
    } else {
      return `${diffInDays} ngày trước`;
    }
  };

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

    setIsPlaying(!isPlaying);
  };

  const renderReplies = () => {
    return replies.map((reply) => {
      return (
        <div key={reply._id} className="comment-reply">
          <div className="reply-avatar-container">
            <img
              src={reply.createdBy.avatar}
              alt="Reply Avatar"
              className="reply-avatar"
            />
          </div>
          <div className="reply-content">
            <p className="reply-author">{reply.createdBy.fullname}</p>
            <p className="comment-time">{getTimeAgo(reply.createdAt)}</p>
            {reply.replyFor && (
              <div className="reply-for">
                <Link
                  to={`/profile/${reply.replyFor}`}
                  className="reply-for-user"
                >
                  {reply.replyFor}
                </Link>
                <p className="reply-text">{reply.text}</p>
              </div>
            )}
            {reply.voice && (
              <div className="comment-audio-controls">
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
                <audio ref={audioRef} src={reply.voice} />
              </div>
            )}
          </div>
        </div>
      );
    });
  };

  return (
    <div className="comment-item">
      <div className="comment-avatar-container">
        <img
          src={comment.createdBy.avatar}
          alt="User Avatar"
          className="comment-avatar"
        />
      </div>

      <div className="comment-content">
        <p className="comment-author">{comment.createdBy.fullname}</p>
        <p className="comment-time">{getTimeAgo(comment.createdAt)}</p>
        <p className="comment-text">{comment.text}</p>
        <div className="comment-voice-container">
          {comment.voice && (
            <div className="comment-audio-controls">
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
              <audio ref={audioRef} src={comment.voice} />
            </div>
          )}
        </div>

        <div className="comment-actions">
          <button onClick={handleLikeComment} className="comment-like-btn">
            <FaHeart
              size={20}
              color={likedComments[comment._id] ? "red" : "gray"}
            />
            <span>{likesCount}</span>
          </button>
          <button
            onClick={() => handleReply(comment.createdBy.username)}
            className="comment-reply-btn"
          >
            <FaReply /> Trả lời
          </button>

          {replies.length > 0 && (
            <button
              onClick={toggleReplies}
              className="comment-view-replies-btn"
            >
              <span>
                {showReplies
                  ? "Ẩn các trả lời"
                  : `Xem ${replies.length} trả lời`}
              </span>
            </button>
          )}
        </div>

        {showReplies && <div className="replies">{renderReplies()}</div>}

        {isReplying && (
          <div className="reply-input-container">
            {" "}
            <p className="replying-to">
              Trả lời:{" "}
              <span className="replying-to-username">@{replyingTo}</span>
            </p>
            <div className="reply-input-container">
              <input
                type="text"
                value={replyTextPart1}
                onChange={(e) => setReplyTextPart1(e.target.value)}
                onFocus={handleInputFocus}
                onBlur={handleInputBlur}
                placeholder="Nhập câu trả lời..."
                className="reply-input-part1"
              />
              <input
                type="text"
                value={replyTextPart2}
                onChange={(e) => setReplyTextPart2(e.target.value)}
                onFocus={handleInputFocus}
                onBlur={handleInputBlur}
                placeholder="Nhập câu chia sẻ... (Tuỳ chọn)"
                className="reply-input-part2"
              />
            </div>
            <button
              className="btn btn-outline-light reply-submit-btn"
              onClick={() =>
                handleSubmitReply(comment._id, replyTextPart1, replyTextPart2)
              }
            >
              Gửi
            </button>
          </div>
        )}
      </div>
    </div>
  );
};

export default CommentItem;

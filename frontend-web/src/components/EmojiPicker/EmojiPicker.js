import React, { useState, useEffect } from "react";
import "./EmojiPicker.css";
import { getEmoji } from "../../services/exploreSevice";

const EmojiPicker = ({ onEmojiClick }) => {
  const [emojiList, setEmojiList] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    const fetchEmojis = async () => {
      try {
        const data = await getEmoji();
        const filteredEmoji = data.filter(
          (emoji) => emoji.category === "smileys and people"
        );
        setEmojiList(filteredEmoji);
        setLoading(false);
      } catch (err) {
        console.error("Lỗi khi tải emoji:", err);
        setError("Không thể tải emoji.");
        setLoading(false);
      }
    };

    fetchEmojis();
  }, []);

  if (loading) {
    return <p className="emoji-picker-loading">Đang tải emoji...</p>;
  }

  if (error) {
    return <p className="emoji-picker-error">{error}</p>;
  }

  return (
    <div className="emoji-picker-grid">
      {emojiList.map((emoji, index) => (
        <div
          key={index}
          className="emoji-picker-item"
          onClick={() => onEmojiClick(emoji)}
        >
          <span
            dangerouslySetInnerHTML={{ __html: emoji.htmlCode }}
            className="emoji-icon"
          ></span>
        </div>
      ))}
    </div>
  );
};

export default EmojiPicker;

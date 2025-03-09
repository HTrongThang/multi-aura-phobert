import axios from "axios";
import { API_URL } from '../config/config';
import Cookies from 'js-cookie';
const Post_URL = `${API_URL}/post`;
const UploadImage_URL = `${API_URL}/upload`;



/**
 * Lấy danh sách emoji từ API.
 * @returns {Promise<Array>} Danh sách emoji.
 */
export const getEmoji = async () => {
  try {
    const response = await axios.get("https://emojihub.yurace.pro/api/all");
    if (response.data) {
      return response.data;
    }
    throw new Error("Không có dữ liệu trả về từ API");
  } catch (error) {
    console.error("Lỗi khi lấy emoji:", error);
    throw error;
  }
};

/**
 * Lấy địa chỉ từ tọa độ (latitude và longitude).
 * @param {number} lat - Latitude.
 * @param {number} lng - Longitude.
 * @returns {Promise<string>} Địa chỉ đã loại bỏ mã bưu chính.
 */
export const getAddressFromCoordinates = async (lat, lng) => {
  try {
    const response = await axios.get(
      `https://nominatim.openstreetmap.org/reverse?format=json&lat=${lat}&lon=${lng}`
    );

    if (response.data && response.data.display_name) {
      let location = response.data.display_name;

      // Loại bỏ mã bưu chính (nếu có)
      const addressParts = location.split(", ");
      const filteredParts = addressParts.filter(
        (part) => !/^\d{5,}$/.test(part) // Loại bỏ các phần chỉ chứa số
      );
      location = filteredParts.join(", ");

      return location || "Không tìm thấy địa chỉ";
    } else {
      return "Không tìm thấy địa chỉ";
    }
  } catch (error) {
    console.error("Lỗi khi gọi API Nominatim:", error);
    throw new Error("Không thể lấy địa chỉ cụ thể");
  }
};


export const createPost = async (postContent) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.post(`${Post_URL}/create`, {
      description: postContent,
    }, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });
    return response.data;


  } catch (error) {
    console.log(`Error to create post`, error);
    throw error;
  }
}

export const uploadImagePost = async (idPost, imagePost, postText) => {
  try {
    const token = Cookies.get('authToken');
    const formData = new FormData();

    imagePost.forEach((image) => {
      formData.append("photos", image);
    });
    if (postText) {
      formData.append("text", postText);
    }
    const response = await axios.post(`${UploadImage_URL}/post/medias/${idPost}`, formData, {
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "multipart/form-data",
      },
    });

    return response.data;

  } catch (error) {
    console.log("Error to upload image post", error);
    throw error;
  }
}

export const likePost = async (idPost) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.post(
      `${Post_URL}/like/${idPost}`,
      {},
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return response.data;
  } catch (error) {
    console.error("Error to like post", error);
    throw error;
  }
};

export const unlikePost = async (idPost) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.delete(
      `${Post_URL}/unlike/${idPost}`,
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return response.data;
  } catch (error) {
    console.error("Error to unlike post", error);
    throw error;
  }
};

export const CommentPost = async (idPost, commentText) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.post(
      `${Post_URL}/add-comment/${idPost}`, 
      {
        "text": commentText, 
      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return response.data; 
  } catch (error) {
    console.error("Error to comment post", error); 
    throw error;
  }
};
export const GetCommentByID = async (idPost) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.post(
      `${Post_URL}/comments/${idPost}`,  
      {},
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return response.data; 
  } catch (error) {
    console.error("Error get comment by idpost", error); 
    throw error;
  }
};

export const LikeComment = async (idComent) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.post(
      `${Post_URL}/comment/like/${idComent}`,  
      {},
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return response.data; 
  } catch (error) {
    console.error("Error  like comment by idpost", error); 
    throw error;
  }
};

export const unLikeComment = async (idComment) => {
  try {
    const token = Cookies.get('authToken');

    const response = await axios.delete(
      `${Post_URL}/comment/unlike/${idComment}`,  
      {
        headers: {
          Authorization: `Bearer ${token}`, 
        },
      }
    );

    return response.data;
  } catch (error) {
    throw new Error('Failed to unlike the comment. Please try again later.'); 
  }
};


export const addReplyComment = async (idComent, commentText,replyingTo ) => {
  try {
    const token = Cookies.get('authToken');
    const response = await axios.post(
      `${Post_URL}/add-reply/${idComent}`, 
      {
        "text": commentText,
        "ReplyFor": replyingTo, 

      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return response.data; 
  } catch (error) {
    console.error("Error to comment post", error); 
    throw error;
  }
};
export const deletePostByid = async (idPost) => {
  try {
    const token = Cookies.get('authToken');

    const response = await axios.delete(
      `${Post_URL}/delete/${idPost}`,  
      {
        headers: {
          Authorization: `Bearer ${token}`, 
        },
      }
    );

    return response.data;
  } catch (error) {
    throw new Error('Failed to delete Post . Please try again later.'); 
  }
};


export const uploadVoiceComment= async (icComment, commentText) => {
  try {
    const token = Cookies.get('authToken');
    const formData = new FormData();

    if (commentText) {
      formData.append("text", commentText);
    }
    const response = await axios.post(`${UploadImage_URL}/comment/medias/${icComment}`, formData, {
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "multipart/form-data",
      },
    });

    return response.data;

  } catch (error) {
    console.log("Error to upload voice  comment", error);
    throw error;
  }
}

export const uploadVoiceReply= async (commentid,idReply, commentText) => {
  try {
    const token = Cookies.get('authToken');
    const formData = new FormData();

    if (commentText) {
      formData.append("text", commentText);
    }
    const response = await axios.post(`${UploadImage_URL}/reply/medias/${commentid}/${idReply}`, formData, {
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "multipart/form-data",
      },
    });

    return response.data;

  } catch (error) {
    console.log("Error to upload voice  comment", error);
    throw error;
  }
}

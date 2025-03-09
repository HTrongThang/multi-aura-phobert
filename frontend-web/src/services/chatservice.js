import axios from 'axios';
import { API_URL } from '../config/config';
import Cookies from 'js-cookie';

const CONVERSATION_URL = `${API_URL}/conversation`;
const UploadImage_URL = `${API_URL}/upload/conversation`;


export const getUserConversation = async (userID) => {
    try {
        const token = Cookies.get('authToken');
        const response = await axios.get(`${CONVERSATION_URL}/get-user-conversations/${userID}`, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data.data;

    } catch (error) {
        console.log(`Failed to get conversation for user with ID ${userID}`, error);
        throw error;
    }
}

export const getConversationDetails = async (conversationID, userID) => {
    try {
        const token = Cookies.get('authToken');
        const response = await axios.get(`${CONVERSATION_URL}/detais-coversation/${conversationID}/${userID}`, {

            headers: {
                Authorization: `Bearer ${token}`
            }
        });
        return response.data.data;
    } catch (error) {
        console.log(`Failed to get conversation details for conversation with ID ${conversationID}`, error);
        throw error;
    }
};
export const sendMessageToConversation = async (conversationID, userID, content) => {

    try {
        const token = Cookies.get('authToken');
        const response = await axios.post(`${CONVERSATION_URL}/send-message/${conversationID}`, {
            user_id: userID,
            content: content
        }, {
            headers: {
                Authorization: `Bearer ${token}`
            }
        });


        // Kiểm tra nếu response.data.data không tồn tại, bạn có thể log một cảnh báo
        if (!response.data.data) {
            console.warn('API response does not contain expected "data" field:', response.data);
            return null;
        }

        return response.data.data; // Trả về dữ liệu tin nhắn
    } catch (error) {
        console.log(`Failed to send message for conversation with ID ${conversationID}`, error);
        throw error;
    }
};
export const createConversation = async (userID, name_conversation) => {
    try {
        const token = Cookies.get('authToken');
        const response = await axios.post(
            `${CONVERSATION_URL}/create-conversation`,
            {
                user_ids: userID,
                name: name_conversation
            },
            {
                headers: {
                    Authorization: `Bearer ${token}`,
                    "Content-Type": "application/json"
                }
            }
        );

        return response.data; // Trả về dữ liệu nếu thành công
    } catch (error) {
        console.error("Error creating conversation:", error.response?.data || error.message);
        throw error; // Ném lỗi để xử lý ở nơi gọi hàm
    }
};


export const createGroupConversation = async (userIDs, name_conversation) => {
    try {
        const token = Cookies.get('authToken'); // Lấy token từ cookie

        const data = {
            user_ids: userIDs.users,
            name: name_conversation,
        };

        const response = await axios.post(
            `${CONVERSATION_URL}/create-conversation`, 
            data, 
            {
                headers: {
                    Authorization: `Bearer ${token}`, 
                    'Content-Type': 'application/json',
                },
            }
        );

        return response.data; // Trả về dữ liệu nếu thành công
    } catch (error) {
        console.error('Error creating conversation:', error.response?.data || error.message);
        throw error; // Ném lỗi để xử lý ở nơi gọi hàm
    }
};


export const uploadImageConversation = async (conversatinID, image) => {
  try {
    const token = Cookies.get('authToken'); 

    const formData = new FormData();
    formData.append("photos", image);  

    const response = await axios.post(`${UploadImage_URL}/image/${conversatinID}`, formData, {
      headers: {
        Authorization: `Bearer ${token}`,
        "Content-Type": "multipart/form-data", 
      },
    });

    if (response.status === 200) {
      return response.data;
    } else {
      throw new Error(`Upload failed with status: ${response.status}`);
    }

  } catch (error) {
    console.error("Error uploading image for conversation", error);
    throw error;  
  }
};

export const addMenberConversation = async (userIDs, id_conversation) => {
    try {
        const token = Cookies.get('authToken'); // Lấy token từ cookie

        const data = {
            conversation_id: id_conversation,
            user_ids: userIDs.users,

        };

        const response = await axios.post(
            `${CONVERSATION_URL}/add-member-message`, 
            data, 
            {
                headers: {
                    Authorization: `Bearer ${token}`, 
                    'Content-Type': 'application/json',
                },
            }
        );

        return response.data; // Trả về dữ liệu nếu thành công
    } catch (error) {
        console.error('Error creating conversation:', error.response?.data || error.message);
        throw error; // Ném lỗi để xử lý ở nơi gọi hàm
    }
};
export const RemoveMenberConversation = async (userID, id_conversation) => {
    try {
        const token = Cookies.get('authToken'); 

        const response = await axios.delete(
            `http://localhost:3000/conversation/remove-member-conversation/${id_conversation}/${userID}`, 
            {
                headers: {
                    Authorization: `Bearer ${token}`, 
                    'Content-Type': 'application/json',
                },
            }
        );

        return response.data; 
    } catch (error) {
        console.error('Error removing member from conversation:', error.response?.data || error.message);
        throw error; 
    }
};

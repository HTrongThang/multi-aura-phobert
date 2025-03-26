import axios from 'axios';
import { API_URL, API_URL_AI } from '../config/config'; 
import Cookies from 'js-cookie';

const TOXIC_URL = `${API_URL}/post/toxic-posts`; 
const TOXIC_URL_COMMENT = `${API_URL_AI}/predict`; 


export const getToxicPosts = async (limit = 10, page = 1,threshold = 0.5) => {
  try {
    const token = Cookies.get('authToken'); 
    if (isNaN(threshold)) {
        threshold = 0.5;
      }
    const response = await axios.post(`${TOXIC_URL}/${threshold}`,
      { limit, page }, 
      {
        headers: {
          Authorization: `Bearer ${token}`, 
          'Content-Type': 'application/json', 
        },
      }
    );
    console.log("Toxic posts data:", response.data);

    return response.data; 
  } catch (error) {
    console.error('Error fetching toxic posts:', error);
    throw error;
  }
};


export const getToxicComment = async (comment) => {
  try {
    const token = Cookies.get('authToken'); 
    if (!token) {
      throw new Error('No authentication token found');
    }
   
    const response = await axios.post(
      "http://192.168.2.3:5000/predict",  // Kiểm tra xem đây có phải URL chính xác không
      { "text": comment },
      {
        headers: {
          Authorization: `Bearer ${token}`,
          'Content-Type': 'application/json',
        },
      }
    );
    

    console.log("Toxic comment data:", response.data);
    return response.data.value; 

  } catch (error) {
    console.error('Error fetching toxic comment:', error.message || error);
    throw error; 
  }
};
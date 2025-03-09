import axios from 'axios';
import { API_URL } from '../config/config'; 
import Cookies from 'js-cookie';

const TOXIC_URL = `${API_URL}/post/toxic-posts`; 

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

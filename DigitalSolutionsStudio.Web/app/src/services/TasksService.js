import axios from 'axios';

const API_URL = process.env.REACT_APP_API_URL;

const fetchTasks = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    throw error;
  }
};

export default fetchTasks;
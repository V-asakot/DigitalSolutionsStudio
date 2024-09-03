import axios from 'axios';

const API_URL = process.env.REACT_APP_API_URL;

const getTasks = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error("Error fetching tasks", error);
    throw error;
  }
};

export default getTasks;
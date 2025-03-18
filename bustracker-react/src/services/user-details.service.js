import axios from 'axios';

const API_URL = 'https://localhost:5001/api/authentication/'; // Replace this with the actual endpoint for fetching all users

// Fetch all users
const getAllUsers = async () => {
  try {
    const response = await axios.get(`${API_URL}/users`); // Adjust the URL if necessary
    return response.data; // Return the list of users
  } catch (error) {
    console.error('Error fetching users:', error);
    throw error; // Rethrow the error for handling in the component
  }
};

export default {
  getAllUsers,
};

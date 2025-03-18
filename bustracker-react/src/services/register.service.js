import axios from 'axios';

const API_URL = 'https://localhost:5001/api/authentication';

// Register User function
export const registerService = async (firstName, lastName, username, email, password, phoneNumber) => {
  try {
    const response = await axios.post(API_URL, {
      firstName,
      lastName,
      userName: username,  // Should match the field in backend DTO
      password,
      email,
      phoneNumber,
      roles: ['customer'],  // If roles are static or need to be passed
    });
    return response.data;
  } catch (error) {
    console.error('Registration error:', error);
    throw new Error(error.response?.data?.message || 'An error occurred while registering.');
  }
};


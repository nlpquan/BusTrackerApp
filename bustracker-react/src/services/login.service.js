import axios from 'axios';

// Set the base URL for your API
const API_URL = 'https://localhost:5001/api/authentication/';

// Login User
// Updated loginService with detailed logging
const loginService = async (username, password) => { 
  try {
    const response = await axios.post(`${API_URL}login`, {
      username,
      password
    });

    // Log the response data for debugging
    console.log("Login response:", response);

    // Check if the response contains the token and role (or user object)
    if (response.data && response.data.token) {
      // Log token and check for role
      console.log("Token:", response.data.token);
      console.log("Role:", response.data.role);

      // Assuming the role is within response.data
      const userData = {
        token: response.data.token,
        role: response.data.role, // Ensure the role is returned as expected
      };

      // Save the token and role in localStorage
      localStorage.setItem('user', JSON.stringify(userData));
      return userData; // Return the token and role
    }

    // If no token is returned, throw an error
    throw new Error('Login failed. Please check your credentials.');

  } catch (error) {
    if (error.response) {
      // Handle specific errors
      console.error('Login error:', error.response.data);
      if (error.response.data.message) {
        throw new Error(error.response.data.message); // Use specific message if available
      }
      throw new Error('An error occurred while logging in.');
    } else {
      console.error('Error:', error.message);
      throw new Error('An error occurred while logging in.');
    }
  }
};

export default { loginService };


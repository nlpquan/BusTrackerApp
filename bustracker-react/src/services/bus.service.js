import axios from 'axios';

const API_URL = 'https://localhost:5001/api/buses'; 

// Get all buses
export const getAllBuses = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Error fetching all buses:', error);
    throw error;
  }
};

// Get a single bus by ID
export const getBusById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching bus with ID ${id}:`, error);
    throw error;
  }
};

// Create a new bus
export const createBus = async (busData) => {
  try {
    const response = await axios.post(API_URL, busData);
    return response.data;
  } catch (error) {
    console.error('Error creating a new bus:', error);
    throw error;
  }
};

// Update an existing bus by ID
export const updateBus = async (id, busData) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, busData);
    return response.data;
  } catch (error) {
    console.error(`Error updating bus with ID ${id}:`, error);
    throw error;
  }
};

// Delete a bus by ID
export const deleteBus = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error deleting bus with ID ${id}:`, error);
    throw error;
  }
};

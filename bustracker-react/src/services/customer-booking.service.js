import axios from 'axios';

const API_URL = 'https://localhost:5001/api/customerbookings'; 

// Get all customer bookings
export const getAllBookings = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Error fetching all bookings:', error);
    throw error;
  }
};

// Get a single booking by ID
export const getBookingById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching booking with ID ${id}:`, error);
    throw error;
  }
};

// Create a new booking
export const createBooking = async (bookingData) => {
  try {
    const response = await axios.post(API_URL, bookingData);
    return response.data;
  } catch (error) {
    console.error('Error creating a new booking:', error);
    throw error;
  }
};

// Update an existing booking by ID
export const updateBooking = async (id, bookingData) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, bookingData);
    return response.data;
  } catch (error) {
    console.error(`Error updating booking with ID ${id}:`, error);
    throw error;
  }
};

// Delete a booking by ID
export const deleteBooking = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error deleting booking with ID ${id}:`, error);
    throw error;
  }
};

import axios from 'axios';

const API_URL = 'https://localhost:5001/api/drivertickets'; 

// Get all driver tickets
export const getAllTickets = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error('Error fetching all tickets:', error);
    throw error;
  }
};

// Get a single ticket by ID
export const getTicketById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching ticket with ID ${id}:`, error);
    throw error;
  }
};

// Create a new ticket
export const createTicket = async (ticketData) => {
  try {
    const response = await axios.post(API_URL, ticketData);
    return response.data;
  } catch (error) {
    console.error('Error creating a new ticket:', error);
    throw error;
  }
};

// Update an existing ticket by ID
export const updateTicket = async (id, ticketData) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, ticketData);
    return response.data;
  } catch (error) {
    console.error(`Error updating ticket with ID ${id}:`, error);
    throw error;
  }
};

// Delete a ticket by ID
export const deleteTicket = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error deleting ticket with ID ${id}:`, error);
    throw error;
  }
};

import axios from 'axios';

const API_BASE_URL = 'https://localhost:5001/api/users'; // replace with your actual base API URL

const BookingForCustomerService = {
  // Get customer bookings for a specific customer
  getCustomerBookingsForCustomer: async (customerId) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/${customerId}/customerbookings`);
      return response.data;
    } catch (error) {
      console.error("Error fetching customer bookings:", error);
      throw error;
    }
  },

  // Get a specific booking for a customer
  getCustomerBookingForCustomer: async (customerId, bookingId) => {
    try {
      const response = await axios.get(`${API_BASE_URL}/${customerId}/customerbookings/${bookingId}`);
      return response.data;
    } catch (error) {
      console.error("Error fetching customer booking:", error);
      throw error;
    }
  },

  // Create a new customer booking
  createCustomerBookingForCustomer: async (customerId, bookingData) => {
    try {
      const response = await axios.post(`${API_BASE_URL}/${customerId}/customerbookings`, bookingData);
      return response.data;
    } catch (error) {
      console.error("Error creating customer booking:", error);
      throw error;
    }
  },

  // Update a customer booking
  updateCustomerBookingForCustomer: async (customerId, bookingId, updatedBookingData) => {
    try {
      const response = await axios.put(
        `${API_BASE_URL}/${customerId}/customerbookings/${bookingId}`,
        updatedBookingData
      );
      return response.data;
    } catch (error) {
      console.error("Error updating customer booking:", error);
      throw error;
    }
  },

  // Delete a customer booking
  deleteCustomerBookingForCustomer: async (customerId, bookingId) => {
    try {
      await axios.delete(`${API_BASE_URL}/${customerId}/customerbookings/${bookingId}`);
    } catch (error) {
      console.error("Error deleting customer booking:", error);
      throw error;
    }
  },
};

export default BookingForCustomerService;
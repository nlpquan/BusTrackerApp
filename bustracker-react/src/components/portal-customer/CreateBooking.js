import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { createBooking } from '../../services/customer-booking.service'; // Import the createBooking service
import '../../App-Portal.css'; // Import the CSS for styling

const PortalCustomerCreateBooking = () => {
  // State to hold form data
  const [formData, setFormData] = useState({
    destination: '',
    bookingDate: '',
    status: 'Pending', // Default status is 'Pending'
    numberOfSeats: 1,
  });

  // State for handling loading and success/error messages
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(false);

  // Handle form field changes
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    setError(null);
    setSuccess(false);

    try {
      // Call the createBooking service to send data to the backend
      await createBooking(formData);
      setSuccess(true); // Set success message if booking is created
    } catch (err) {
      setError('Failed to create booking. Please try again later.'); // Handle error if the API request fails
    } finally {
      setLoading(false); // Set loading to false after request completion
    }
  };

  return (
    <div 
      className="container-fluid" 
      style={{
        background: 'url() no-repeat center center/cover', 
        minHeight: '100vh',
        paddingBottom: '60px' // Ensure footer doesn't overlap
      }}
    >
      <div className="row">
        {/* Sidebar */}
        <nav className="sidebar navbar navbar-expand-lg fixed-left col-md-2 col-12">
          <div className="container-fluid flex-column">
            <Link to="/portalcustomer" className="navbar-brand mb-4">Customer Portal</Link>
            <div className="sidebar-body flex-grow-1">
              <ul className="navbar-nav flex-column">
                <li className="nav-item">
                  <Link to="/portalcustomer/bookings" className="nav-link">Manage Bookings</Link>
                </li>
                <li className="nav-item">
                  <Link to="/portalcustomer/create" className="nav-link">Create a Booking</Link>
                </li>
                <li className="nav-item">
                  <Link to="/portalcustomer/routes" className="nav-link">Routes</Link>
                </li>
              </ul>
            </div>
          </div>
        </nav>

        {/* Main Content Area */}
        <div className="content-area col-md-10 col-12">
          <h2>Create a Booking</h2>

          {/* Success or Error Messages */}
          {success && <div className="alert alert-success">Booking created successfully!</div>}
          {error && <div className="alert alert-danger">{error}</div>}

          <form onSubmit={handleSubmit}>
            <div className="mb-3">
              <label htmlFor="destination" className="form-label">Destination</label>
              <input
                type="text"
                id="destination"
                name="destination"
                className="form-control"
                value={formData.destination}
                onChange={handleChange}
                required
              />
            </div>

            <div className="mb-3">
              <label htmlFor="bookingDate" className="form-label">Booking Date</label>
              <input
                type="datetime-local"
                id="bookingDate"
                name="bookingDate"
                className="form-control"
                value={formData.bookingDate}
                onChange={handleChange}
                required
              />
            </div>

            <div className="mb-3">
              <label htmlFor="numberOfSeats" className="form-label">Number of Seats</label>
              <input
                type="number"
                id="numberOfSeats"
                name="numberOfSeats"
                className="form-control"
                value={formData.numberOfCapacity}
                onChange={handleChange}
                min="1"
                max="19"
                required
              />
            </div>

            <div className="mb-3">
              <label htmlFor="status" className="form-label">Booking Status</label>
              <select
                id="status"
                name="status"
                className="form-select"
                value={formData.status}
                onChange={handleChange}
                disabled
              >
                <option value="Pending">Pending</option>
              </select>
            </div>

            <button type="submit" className="btn btn-primary" disabled={loading}>
              {loading ? 'Creating Booking...' : 'Create Booking'}
            </button>
          </form>
        </div>
      </div>
    </div>
  );
};

export default PortalCustomerCreateBooking;

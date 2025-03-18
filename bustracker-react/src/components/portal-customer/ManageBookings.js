import React, { useState, useEffect } from 'react';
import { Link, useNavigate } from 'react-router-dom'; 
import { getAllBookings, deleteBooking } from '../../services/customer-booking.service'; 
import '../../App-Portal.css'; 

const PortalCustomerManageBookings = () => {
  const [bookings, setBookings] = useState([]); 
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null); 
  const [bookingToDelete, setBookingToDelete] = useState(null); 
  const navigate = useNavigate(); 

  // Get the current user's ID (e.g., from localStorage or global state)
  const userId = localStorage.getItem('userId'); // Assuming userId is stored in localStorage

  // Fetch bookings when the component is mounted
  useEffect(() => {
    const fetchBookings = async () => {
      try {
        const bookingsData = await getAllBookings(); 
        // Filter the bookings based on the current userId
        const userBookings = bookingsData.filter(booking => booking.userId === userId);
        setBookings(userBookings); 
      } catch (err) {
        setError('Failed to load bookings'); 
      } finally {
        setLoading(false); 
      }
    };

    fetchBookings(); 
  }, [userId]); // Depend on userId to re-fetch when the userId changes

  // Handle delete booking
  const handleDelete = async () => {
    if (bookingToDelete) {
      try {
        await deleteBooking(bookingToDelete.id); 
        setBookings(bookings.filter(booking => booking.id !== bookingToDelete.id)); 
      } catch (err) {
        setError('Failed to delete the booking');
      }
      setBookingToDelete(null); // Reset after deletion
    }
  };

  // Handle delete button click
  const openDeleteModal = (booking) => {
    setBookingToDelete(booking); 
    const modal = new window.bootstrap.Modal(document.getElementById('deleteModal')); 
    modal.show(); 
  };

  if (loading) {
    return <div>Loading bookings...</div>; 
  }

  if (error) {
    return <div>{error}</div>; 
  }

  return (
    <div className="container">
      <div className="row">
        <nav className="sidebar navbar navbar-expand-lg fixed-left">
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

        <div className="col-md-10 col-12 content-area">
          <h2>Manage Bookings</h2>
          <table className="table table-striped">
            <thead>
              <tr>
                <th>Destination</th>
                <th>Booking Date</th>
                <th>Number of Seats</th>
                <th>Status</th>
                <th>Actions</th> 
              </tr>
            </thead>
            <tbody>
              {bookings.map((booking) => (
                <tr key={booking.id}>
                  <td>{booking.destination}</td>
                  <td>{new Date(booking.bookingDate).toLocaleString()}</td>
                  <td>{booking.capacity}</td>
                  <td>{booking.status}</td>
                  <td>
                    <button 
                      onClick={() => navigate(`/portalcustomer/bookings/edit/${booking.id}`)} 
                      className="btn btn-primary">
                      Edit
                    </button>
                    <button 
                      onClick={() => openDeleteModal(booking)} 
                      className="btn btn-danger ml-2">
                      Delete
                    </button>
                  </td>
                </tr>              
              ))}
            </tbody>
          </table>

          {/* Modal for delete confirmation */}
          <div 
            className="modal fade" 
            id="deleteModal" 
            tabIndex="-1" 
            aria-labelledby="deleteModalLabel" 
            aria-hidden="true"
          >
            <div className="modal-dialog modal-dialog-centered">
              <div className="modal-content">
                <div className="modal-header">
                  <h5 className="modal-title" id="deleteModalLabel">Confirm Deletion</h5>
                  <button 
                    type="button" 
                    className="btn-close" 
                    data-bs-dismiss="modal" 
                    aria-label="Close"
                  ></button>
                </div>
                <div className="modal-body">
                  Are you sure you want to delete this booking?
                </div>
                <div className="modal-footer">
                  <button 
                    type="button" 
                    className="btn btn-secondary" 
                    data-bs-dismiss="modal"
                  >
                    Cancel
                  </button>
                  <button 
                    type="button" 
                    className="btn btn-danger" 
                    onClick={handleDelete} 
                    data-bs-dismiss="modal"
                  >
                    Delete
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PortalCustomerManageBookings;

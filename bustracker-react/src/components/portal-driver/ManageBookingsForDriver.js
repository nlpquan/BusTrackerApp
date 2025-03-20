import React, { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom'; 
import { getAllBookings, deleteBooking, getBookingById, updateBooking } from '../../services/customer-booking.service'; // Updated import for the new service
import '../../App-Portal.css'; 

const PortalCustomerManageBookings = () => {
  const [bookings, setBookings] = useState([]); 
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null); 
  const [bookingToDelete, setBookingToDelete] = useState(null); 
  const [bookingToEdit, setBookingToEdit] = useState(null); // For storing the booking to be edited
  const [formData, setFormData] = useState({
    destination: '',
    bookingDate: '',
    capacity: '',
    status: ''
  }); // For the form fields
  
  const editModalRef = useRef(null); // Reference for the edit modal
  const deleteModalRef = useRef(null); // Reference for the delete modal

  // Fetch bookings when the component is mounted
  useEffect(() => {
    const fetchBookings = async () => {
      try {
        const bookingsData = await getAllBookings(); // Use the new service to fetch bookings
        setBookings(bookingsData); 
      } catch (err) {
        setError('Failed to load bookings'); 
      } finally {
        setLoading(false); 
      }
    };

    fetchBookings(); 
  }, []); // Depend only on the initial mount of the component

  // Handle delete booking
  const handleDelete = async () => {
    if (bookingToDelete) {
      try {
        await deleteBooking(bookingToDelete.id); // Use the new service to delete a booking
        setBookings(bookings.filter(booking => booking.id !== bookingToDelete.id)); 
      } catch (err) {
        setError('Failed to delete the booking');
      }
      setBookingToDelete(null); // Reset after deletion
      const modal = window.bootstrap.Modal.getInstance(deleteModalRef.current);
      modal.hide();
    }
  };

  // Handle edit booking
  const handleEdit = (bookingId) => {
    // Fetch the booking by ID and populate the form fields
    const fetchBookingDetails = async () => {
      try {
        const booking = await getBookingById(bookingId);
        setBookingToEdit(booking); 
        setFormData({
          destination: booking.destination,
          bookingDate: new Date(booking.bookingDate).toISOString().slice(0, 16), // Format for input type="datetime-local"
          capacity: booking.capacity,
          status: booking.status
        });
      } catch (err) {
        setError('Failed to fetch booking details');
      }
    };

    fetchBookingDetails();
    const modal = new window.bootstrap.Modal(editModalRef.current); // Use ref to show the modal
    modal.show();
  };

  // Handle form field change
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  // Handle save changes
  const handleSaveChanges = async () => {
    const updatedBooking = { ...formData, id: bookingToEdit.id };
    try {
      await updateBooking(bookingToEdit.id, updatedBooking);
      setBookings(bookings.map(booking => (booking.id === bookingToEdit.id ? updatedBooking : booking)));
      setBookingToEdit(null);
      const modal = window.bootstrap.Modal.getInstance(editModalRef.current);
      modal.hide();
    } catch (err) {
      setError('Failed to update the booking');
    }
  };

  // Handle cancel (close modal)
  const handleCancel = () => {
    setBookingToEdit(null);
    const modal = window.bootstrap.Modal.getInstance(editModalRef.current);
    modal.hide();
  };

  // Function to open the delete confirmation modal
  const openDeleteModal = (booking) => {
    setBookingToDelete(booking);  // Store the booking that is selected for deletion
    const modal = new window.bootstrap.Modal(deleteModalRef.current); 
    modal.show();  // Show the modal
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
                      onClick={() => handleEdit(booking.id)} 
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

          {/* Modal for Edit Booking */}
          <div 
            className="modal fade" 
            id="editModal" 
            tabIndex="-1" 
            aria-labelledby="editModalLabel" 
            aria-hidden="true"
            ref={editModalRef} // Attach the ref to the modal
          >
            <div className="modal-dialog modal-dialog-centered">
              <div className="modal-content">
                <div className="modal-header">
                  <h5 className="modal-title" id="editModalLabel">Edit Booking</h5>
                  <button 
                    type="button" 
                    className="btn-close" 
                    data-bs-dismiss="modal" 
                    aria-label="Close"
                    onClick={handleCancel}
                  ></button>
                </div>
                <div className="modal-body">
                  <form>
                    <div className="mb-3">
                      <label htmlFor="destination" className="form-label">Destination</label>
                      <input 
                        type="text" 
                        className="form-control" 
                        id="destination" 
                        name="destination"
                        value={formData.destination}
                        onChange={handleInputChange}
                      />
                    </div>
                    <div className="mb-3">
                      <label htmlFor="bookingDate" className="form-label">Booking Date</label>
                      <input 
                        type="datetime-local" 
                        className="form-control" 
                        id="bookingDate" 
                        name="bookingDate"
                        value={formData.bookingDate}
                        onChange={handleInputChange}
                      />
                    </div>
                    <div className="mb-3">
                      <label htmlFor="capacity" className="form-label">Number of Seats</label>
                      <input 
                        type="number" 
                        className="form-control" 
                        id="capacity" 
                        name="capacity"
                        value={formData.capacity}
                        onChange={handleInputChange}
                      />
                    </div>
                    <div className="mb-3">
                      <label htmlFor="status" className="form-label">Status</label>
                      <select 
                        className="form-select" 
                        id="status" 
                        name="status"
                        value={formData.status}
                        onChange={handleInputChange}
                      >
                        <option value="Pending">Pending</option>
                        <option value="Confirmed">Confirmed</option>
                        <option value="Canceled">Canceled</option>
                      </select>
                    </div>
                  </form>
                </div>
                <div className="modal-footer">
                  <button 
                    type="button" 
                    className="btn btn-secondary" 
                    data-bs-dismiss="modal"
                    onClick={handleCancel}
                  >
                    Cancel
                  </button>
                  <button 
                    type="button" 
                    className="btn btn-primary" 
                    onClick={handleSaveChanges}
                  >
                    Save changes
                  </button>
                </div>
              </div>
            </div>
          </div>

          {/* Modal for Delete Confirmation */}
          <div 
            className="modal fade" 
            id="deleteModal" 
            tabIndex="-1" 
            aria-labelledby="deleteModalLabel" 
            aria-hidden="true"
            ref={deleteModalRef} // Attach the ref to the delete modal
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

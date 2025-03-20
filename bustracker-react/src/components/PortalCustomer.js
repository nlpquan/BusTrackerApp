import React, { useState, useEffect } from 'react';
import { Link, useLocation } from 'react-router-dom'; 
import { getAllBookings } from '../services/customer-booking.service'; // Import service for fetching bookings
import { Bar } from 'react-chartjs-2'; // Import Bar chart from react-chartjs-2
import { Chart as ChartJS, CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend } from 'chart.js'; // Import necessary components from Chart.js
import '../App-Portal.css'; // Import the CSS for styling

// Registering the chart components with Chart.js
ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

const PortalCustomer = () => {
  const location = useLocation(); // Get the current location (path)

  // State for storing the booking data
  const [bookings, setBookings] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Function to check if the current path matches the link
  const isActive = (path) => location.pathname === path ? 'active' : '';

  // Fetch bookings when the component is mounted
  useEffect(() => {
    const fetchBookings = async () => {
      try {
        const bookingsData = await getAllBookings(); // Fetch all bookings using the service
        setBookings(bookingsData); 
      } catch (err) {
        setError('Failed to load bookings');
      } finally {
        setLoading(false);
      }
    };

    fetchBookings();
  }, []);

  // Group bookings by destination and count the number of bookings per destination
  const groupedBookings = bookings.reduce((acc, booking) => {
    const destination = booking.destination;
    if (!acc[destination]) {
      acc[destination] = 1; // If the destination doesn't exist, initialize the count to 1
    } else {
      acc[destination] += 1; // If the destination already exists, increment the count
    }
    return acc;
  }, {});

  // Prepare data for the chart
  const chartData = {
    labels: Object.keys(groupedBookings), // Use grouped destinations as labels
    datasets: [
      {
        label: 'Number of Bookings',
        data: Object.values(groupedBookings), // Use the counts of bookings per destination
        backgroundColor: 'rgba(75, 192, 192, 0.2)', // Bar color
        borderColor: 'rgba(75, 192, 192, 1)', // Border color
        borderWidth: 1,
      },
    ],
  };

  // Options for the chart
  const chartOptions = {
    responsive: true,
    plugins: {
      title: {
        display: true,
        text: 'Bookings by Destination',
      },
    },
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>{error}</div>;
  }

  return (
    <div
      className="portal-customer-container"
      style={{
        background: 'url( no-repeat center center/cover',
        minHeight: '100vh',
        paddingBottom: '60px', // Ensure footer doesn't overlap
      }}
    >
      <nav className="sidebar navbar navbar-expand-lg fixed-left">
        <div className="container-fluid flex-column">
          <Link to="/portalcustomer" className="navbar-brand mb-4">
            Customer Portal
          </Link>
          <div className="sidebar-body flex-grow-1">
            <ul className="navbar-nav flex-column">
              <li className="nav-item">
                <Link
                  to="/portalcustomer/bookings"
                  className={`nav-link ${isActive('/portalcustomer/bookings')}`}
                >
                  Manage Bookings
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  to="/portalcustomer/create"
                  className={`nav-link ${isActive('/portalcustomer/create')}`}
                >
                  Create a Booking
                </Link>
              </li>
              <li className="nav-item">
                <Link
                  to="/portalcustomer/routes"
                  className={`nav-link ${isActive('/portalcustomer/routes')}`}
                >
                  Routes
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      {/* Charts Section */}
      <div className="charts-section">
        <h3>Booking Overview</h3>
        <div className="chart-container">
          {/* Chart Component for displaying bookings */}
          <Bar data={chartData} options={chartOptions} />
        </div>
      </div>
    </div>
  );
};

export default PortalCustomer;

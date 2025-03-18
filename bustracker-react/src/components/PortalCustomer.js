import React from 'react';
import { Link, useLocation } from 'react-router-dom'; // Add useLocation to get current path
import ChartComponent from './Chart'; // Import ChartComponent
import '../App-Portal.css'; // Import the CSS for styling

const PortalCustomer = () => {
  const location = useLocation(); // Get the current location (path)

  // Function to check if the current path matches the link
  const isActive = (path) => location.pathname === path ? 'active' : '';

  return (
    <div 
      className="portal-customer-container" 
      style={{ 
        background: 'url(bus-background-7.jpg) no-repeat center center/cover',
        minHeight: '100vh',
        paddingBottom: '60px' // Ensure footer doesn't overlap
      }}
    >
      <nav className="sidebar navbar navbar-expand-lg fixed-left">
        <div className="container-fluid flex-column">
          <Link to="/portalcustomer" className="navbar-brand mb-4">Customer Portal</Link>
          <div className="sidebar-body flex-grow-1">
            <ul className="navbar-nav flex-column">
              <li className="nav-item">
                <Link to="/portalcustomer/bookings" className={`nav-link ${isActive('/portalcustomer/bookings')}`}>Manage Bookings</Link>
              </li>
              <li className="nav-item">
                <Link to="/portalcustomer/create" className={`nav-link ${isActive('/portalcustomer/create')}`}>Create a Booking</Link>
              </li>
              <li className="nav-item">
                <Link to="/portalcustomer/routes" className={`nav-link ${isActive('/portalcustomer/routes')}`}>Routes</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      {/* Charts Section */}
      <div className="charts-section">
        <ChartComponent />
      </div>
    </div>
  );
};

export default PortalCustomer;

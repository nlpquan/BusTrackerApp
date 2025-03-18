import React from 'react';
import { Link } from 'react-router-dom'; // Make sure you have react-router-dom installed
import '../../App-Portal.css'; // Import the CSS for styling

const PortalCustomerRoutes = () => {
  // Hardcoded available routes data
  const routes = [
    { id: 1, name: 'Route A', description: 'From Downtown to Airport', price: '$20', duration: '30 mins' },
    { id: 2, name: 'Route B', description: 'From Central Station to City Park', price: '$15', duration: '20 mins' },
    { id: 3, name: 'Route C', description: 'From Beachfront to Mall', price: '$25', duration: '40 mins' },
    { id: 4, name: 'Route D', description: 'From Suburbs to City Center', price: '$18', duration: '25 mins' },
    { id: 4, name: 'Route D', description: 'From Suburbs to City Center', price: '$18', duration: '25 mins' },
    { id: 4, name: 'Route D', description: 'From Suburbs to City Center', price: '$18', duration: '25 mins' },
  ];

  return (
    <div className="container">
      <div className="row">
        {/* Sidebar */}
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
                  <Link to="/portalcustomer/routes" className="nav-link active">Routes</Link>
                </li>
              </ul>
            </div>
          </div>
        </nav>

        {/* Main Content Area */}
        <div className="col-md-9 ml-auto pt-5">
          <h2 className="text-center mb-4">Available Routes</h2>
          <div className="row justify-content-end"> {/* Align the content to the right */}
            {routes.map((route) => (
              <div key={route.id} className="col-md-6 col-lg-4 mb-4">
                <div className="card">
                  <div className="card-body">
                    <h5 className="card-title">{route.name}</h5>
                    <p className="card-text">{route.description}</p>
                    <p className="card-text"><strong>Price:</strong> {route.price}</p>
                    <p className="card-text"><strong>Duration:</strong> {route.duration}</p>
                    <Link to={`/portalcustomer/create`} className="btn btn-primary">Book Now</Link>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};

export default PortalCustomerRoutes;

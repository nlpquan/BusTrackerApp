import React from 'react';
import { Link } from 'react-router-dom'; // Make sure you have react-router-dom installed
import '../App-Portal.css'; // Import the CSS for styling

const PortalAdmin = () => {
  return (
    <nav className="sidebar navbar navbar-expand-lg fixed-left">
      <div className="container-fluid flex-column">
        <Link to="/portaladmin" className="navbar-brand mb-4">Admin Portal</Link>
        <div className="sidebar-body flex-grow-1">
          <ul className="navbar-nav flex-column">
            <li className="nav-item">
              <Link to="/dashboard" className="nav-link">Dashboard</Link>
            </li>
            <li className="nav-item">
              <Link to="/buses" className="nav-link">Buses</Link>
            </li>
            <li className="nav-item">
              <Link to="/routes" className="nav-link">Routes</Link>
            </li>
            <li className="nav-item">
              <Link to="/notifications" className="nav-link">Notifications</Link>
            </li>
            <li className="nav-item">
              <Link to="/schedules" className="nav-link">Schedules</Link>
            </li>
          </ul>
        </div>
        
      </div>
    </nav>
  );
};

export default PortalAdmin;

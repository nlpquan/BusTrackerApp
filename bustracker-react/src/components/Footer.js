import React from 'react';
import { Link } from 'react-router-dom'; // For navigation links

function Footer() {
  return (
    <footer className="footer bg-dark text-white py-4">
      <div className="container">
        <div className="row">
          {/* Column 1: Company Info */}
          <div className="col-md-4 mb-3">
            <h5>Bus Tracker</h5>
            <p>Your reliable partner for easy bus tracking and smooth commuting. Join us in transforming the way you travel!</p>
          </div>

          {/* Column 2: Quick Links */}
          <div className="col-md-4 mb-3">
            <h5>Quick Links</h5>
            <ul className="list-unstyled">
              <li><Link to="/aboutus" className="text-white">About Us</Link></li>
              <li><Link to="/services" className="text-white">Services</Link></li>
              <li><Link to="/contact" className="text-white">Contact</Link></li>
              <li><Link to="/privacy" className="text-white">Privacy Policy</Link></li>
              <li><Link to="/terms" className="text-white">Terms of Service</Link></li>
            </ul>
          </div>

          {/* Column 3: Social Media Links with Bootstrap Icons */}
          <div className="col-md-4 mb-3">
            <h5>Follow Us</h5>
            <div>
              <a href="https://www.facebook.com" target="_blank" rel="noopener noreferrer" className="text-white me-3">
                <i className="bi bi-facebook" style={{ fontSize: '30px' }}></i>
              </a>
              <a href="https://twitter.com" target="_blank" rel="noopener noreferrer" className="text-white me-3">
                <i className="bi bi-twitter" style={{ fontSize: '30px' }}></i>
              </a>
              <a href="https://www.instagram.com" target="_blank" rel="noopener noreferrer" className="text-white me-3">
                <i className="bi bi-instagram" style={{ fontSize: '30px' }}></i>
              </a>
              <a href="https://www.linkedin.com" target="_blank" rel="noopener noreferrer" className="text-white">
                <i className="bi bi-linkedin" style={{ fontSize: '30px' }}></i>
              </a>
            </div>
          </div>
        </div>
        
        {/* Bottom Section: Copyright */}
        <div className="row">
          <div className="col text-center mt-4">
            <p>&copy; {new Date().getFullYear()} Bus Tracker. All rights reserved.</p>
          </div>
        </div>
      </div>
    </footer>
  );
}

export default Footer;

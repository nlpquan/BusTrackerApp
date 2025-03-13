import React from 'react';
import { Link } from 'react-router-dom'; // Add this import
import HeroSection from './HeroSection';

function Login() {
  return (
    <HeroSection 
      content={
        <div className="container register-container d-flex justify-content-center align-items-center fade-in" style={{ minHeight: '80vh' }}> 
          <div className="card register-card" style={{ maxWidth: '500px', width: '100%', padding: '15px' }}> {/* Reduced padding */}
            <div className="card-body">
              <h2 className="card-title text-center" style={{ marginBottom: '1rem', fontSize: '1.1rem' }}>Login Page</h2> {/* Reduced margin and font size */}
              <form>
                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="name" className="form-label" style={{ fontSize: '0.85rem' }}>Username</label> {/* Reduced font size */}
                  <input type="text" className="form-control" id="name" placeholder="Enter your username" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} /> {/* Reduced font size and padding */}
                </div>
                <div style={{ marginBottom: '1rem' }}>
                  <label htmlFor="password" className="form-label" style={{ fontSize: '0.85rem' }}>Password</label>
                  <input type="password" className="form-control" id="password" placeholder="Enter your password" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                </div>
                <button type="submit" className="btn btn-primary w-100" style={{ padding: '0.5rem', fontSize: '0.85rem' }}>Login</button> {/* Reduced padding and font size */}
              </form>
              <p className="mt-2 text-center" style={{ fontSize: '0.8rem' }}> {/* Reduced margin and font size */}
                Don't have an account? <Link to="/register">Register here</Link>
              </p>
            </div>
          </div>
        </div>
      }
      heroClass="login-hero"
    />
  );
}

export default Login;

import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import HeroSection from './HeroSection';
import loginService from '../services/login.service'; // Import your login service
import { useAuth } from '../authentication/AuthContext'; // Import useAuth correctly

function Login() {
  const { login } = useAuth(); // Get the login function from the context
  const navigate = useNavigate();
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const handleChange = (e) => {
    const { name, value } = e.target;
    if (name === 'username') {
      setUsername(value);
    } else if (name === 'password') {
      setPassword(value);
    }
  };

  // In your Login.js

const handleSubmit = async (e) => {
  e.preventDefault();

  try {
    const response = await loginService.loginService(username, password);

    if (response && response.token) {
      // Save the token, role, and first name in the context
      login({ 
        token: response.token, 
        role: response.role,
        firstName: response.firstName, // Store the first name here
      });

      // Redirect based on the role
      if (response.role === 'Customer') {
        navigate('/portalcustomer');
      } else if (response.role === 'Driver') {
        navigate('/portaldriver');
      } else if (response.role === 'Admin') {
        navigate('/portaladmin');
      } else {
        console.warn('Unknown role:', response.role);
        navigate('/forbidden');
      }
    }
  } catch (error) {
    setErrorMessage(error.message || 'An error occurred while logging in.');
  }
};


  return (
    <HeroSection
    backgroundUrl="url(bus-background-6.jpg)" 
      content={
        <div className="container register-container d-flex justify-content-center align-items-center fade-in" style={{ minHeight: '80vh' }}> 
          <div className="card register-card" style={{ maxWidth: '500px', width: '100%', padding: '15px' }}>
            <div className="card-body">
              <h2 className="card-title text-center" style={{ marginBottom: '1rem', fontSize: '1.1rem' }}>Login Page</h2>

              {errorMessage && <div className="alert alert-danger">{errorMessage}</div>}

              <form onSubmit={handleSubmit}>
                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="username" className="form-label" style={{ fontSize: '0.85rem' }}>Username</label>
                  <input 
                    type="text" 
                    className="form-control" 
                    id="username"  
                    name="username"
                    value={username} 
                    onChange={handleChange}
                    placeholder="Enter your username" 
                    required 
                    style={{ fontSize: '0.85rem', padding: '0.5rem' }} 
                  />
                </div>
                <div style={{ marginBottom: '1rem' }}>
                  <label htmlFor="password" className="form-label" style={{ fontSize: '0.85rem' }}>Password</label>
                  <input 
                    type="password" 
                    className="form-control" 
                    id="password" 
                    name="password" 
                    value={password}
                    onChange={handleChange}
                    placeholder="Enter your password" 
                    required 
                    style={{ fontSize: '0.85rem', padding: '0.5rem' }} 
                  />
                </div>
                <button type="submit" className="btn btn-primary w-100" style={{ padding: '0.5rem', fontSize: '0.85rem' }}>Login</button>
              </form>

              <p className="mt-2 text-center" style={{ fontSize: '0.8rem' }}>
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

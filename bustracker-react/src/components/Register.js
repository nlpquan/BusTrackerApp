import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import HeroSection from './HeroSection';
import { registerService } from '../services/register.service';  // Correct named import

function Register() {
  const navigate = useNavigate();

  // State to hold form values
  const [user, setUser] = useState({
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    password: '',
    confirmPassword: '',
    phoneNumber: '',
  });

  const [errorMessage, setErrorMessage] = useState('');
  const [successMessage, setSuccessMessage] = useState(''); // New state for success message

  // Handle input changes
  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser({ ...user, [name]: value });
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();
  
    // Check if password and confirm password match
    if (user.password !== user.confirmPassword) {
      setErrorMessage('Passwords do not match!');
      return;
    }
  
    // Prepare the data to send to the backend
    try {
      // Call the API to register the user using the registerService
      const response = await registerService(
        user.firstName,
        user.lastName,
        user.userName,
        user.email,
        user.password,
        user.phoneNumber
      );
  
      // On successful registration, navigate to the portalCustomer
      if (response && response.status === 201) {
        navigate('/portalcustomer');
      }
    } catch (error) {
      // Log the full error response for debugging
      console.error('Error response:', error.response);
  
      // Here, we check the structure of the error response
      if (error.response && error.response.data) {
        const { DuplicateEmail, DuplicateUserName } = error.response.data;
  
        // If duplicate email or username is found, show the appropriate error message
        if (DuplicateEmail && DuplicateEmail.length > 0) {
          setErrorMessage(DuplicateEmail[0]);
        } else if (DuplicateUserName && DuplicateUserName.length > 0) {
          setErrorMessage(DuplicateUserName[0]);
        } else {
          // For any other errors, show a generic message
          setErrorMessage(error.message || 'Registration failed!');
        }
      } else {
        // If the error response is not structured as expected, fall back to the generic error message
        setErrorMessage(error.message || 'Registration failed!');
      }
    }
  };
  
  

  return (
    <HeroSection
    backgroundUrl="url(bus-background-6.jpg)" 
      content={
        <div className="container register-container d-flex justify-content-center align-items-center fade-in" style={{ minHeight: '80vh' }}>
          <div className="card register-card" style={{ maxWidth: '500px', width: '100%', padding: '15px', marginBottom: '-8rem' }}>
            <div className="card-body">
              <h2 className="card-title text-center" style={{ marginBottom: '1rem', fontSize: '1.1rem' }}>Register Page</h2>

              {/* Display success message if registration is successful */}
              {successMessage && <div className="alert alert-success">{successMessage}</div>}

              {/* Display error message if something goes wrong */}
              {errorMessage && <div className="alert alert-danger">{errorMessage}</div>}

              <form onSubmit={handleSubmit}>
                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="userName" className="form-label" style={{ fontSize: '0.85rem' }}>Username</label>
                  <input
                    type="text"
                    className="form-control"
                    id="userName"
                    name="userName"
                    value={user.userName}
                    onChange={handleChange}
                    placeholder="Enter your username"
                    required
                    style={{ fontSize: '0.85rem', padding: '0.5rem' }}
                  />
                </div>
                <div className="row mb-3">
                  <div className="col" style={{ marginBottom: '-1rem' }}>
                    <label htmlFor="firstName" className="form-label" style={{ fontSize: '0.85rem' }}>First Name</label>
                    <input
                      type="text"
                      className="form-control"
                      id="firstName"
                      name="firstName"
                      value={user.firstName}
                      onChange={handleChange}
                      placeholder="Enter your first name"
                      required
                      style={{ fontSize: '0.85rem', padding: '0.5rem' }}
                    />
                  </div>
                  <div className="col" style={{ marginBottom: '-1rem' }}>
                    <label htmlFor="lastName" className="form-label" style={{ fontSize: '0.85rem' }}>Last Name</label>
                    <input
                      type="text"
                      className="form-control"
                      id="lastName"
                      name="lastName"
                      value={user.lastName}
                      onChange={handleChange}
                      placeholder="Enter your last name"
                      required
                      style={{ fontSize: '0.85rem', padding: '0.5rem' }}
                    />
                  </div>
                </div>

                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="email" className="form-label" style={{ fontSize: '0.85rem' }}>Email address</label>
                  <input
                    type="email"
                    className="form-control"
                    id="email"
                    name="email"
                    value={user.email}
                    onChange={handleChange}
                    placeholder="Enter your email"
                    required
                    style={{ fontSize: '0.85rem', padding: '0.5rem' }}
                  />
                </div>

                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="password" className="form-label" style={{ fontSize: '0.85rem' }}>Password</label>
                  <input
                    type="password"
                    className="form-control"
                    id="password"
                    name="password"
                    value={user.password}
                    onChange={handleChange}
                    placeholder="Enter your password"
                    required
                    style={{ fontSize: '0.85rem', padding: '0.5rem' }}
                  />
                </div>

                <div style={{ marginBottom: '1rem' }}>
                  <label htmlFor="confirmPassword" className="form-label" style={{ fontSize: '0.85rem' }}>Confirm Password</label>
                  <input
                    type="password"
                    className="form-control"
                    id="confirmPassword"
                    name="confirmPassword"
                    value={user.confirmPassword}
                    onChange={handleChange}
                    placeholder="Confirm your password"
                    required
                    style={{ fontSize: '0.85rem', padding: '0.5rem' }}
                  />
                </div>

                <button type="submit" className="btn btn-primary w-100" style={{ padding: '0.5rem', fontSize: '0.85rem' }}>Register</button>
              </form>

              <p className="mt-2 text-center" style={{ fontSize: '0.8rem', marginBottom: "2rem" }}>
                Already have an account? <Link to="/login">Login here</Link>
              </p>
            </div>
          </div>
        </div>
      }
      heroClass="register-hero"
    />
  );
}

export default Register;

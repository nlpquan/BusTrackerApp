import { BrowserRouter as Router, Route, Routes, Link, useLocation } from 'react-router-dom';
import React, { useEffect, useState } from 'react'; 
import { useAuth } from './authentication/AuthContext';
import './App.css';
import HeroSection from './components/HeroSection'; // Import HeroSection component
import Login from './components/Login';
import Register from './components/Register'
import PortalAdmin from './components/PortalAdmin';
import PortalCustomer from './components/PortalCustomer';
import PortalDriver from './components/PortalDriver';
import ProtectedRoute from './authentication/ProtectedRoute';
import { AuthProvider } from './authentication/AuthContext';
import PortalCustomerBooking from './components/portal-customer/ManageBookings';
import PortalCustomerCreateBooking from './components/portal-customer/CreateBooking';
import PortalCustomerRoutes from './components/portal-customer/Routes';
import Footer from './components/Footer';
import { Accordion } from 'react-bootstrap'; // Import react-bootstrap Accordion
import Forbidden from './components/Forbidden';

function Home() {
  const [fade, setFade] = useState(false);

  useEffect(() => {
    // Trigger the fade-in effect after the component is mounted
    setFade(true);
  }, []);

  return (
    <div className={`home-hero ${fade ? 'fade-in' : ''}`}>
      <HeroSection 
        title={<span className="home-title">Home Page</span>}
        content={<p className="home-content">Welcome to the Bus Tracking System!</p>}
        heroClass="home-hero"
      />
    </div>
  );
}

const Services = () => {
  return (
    <div>
      {/* Hero Section */}
      <HeroSection 
        title="Our Services"
        content={(
          <div>
            <h2>Explore New Zealand like never before!</h2>
            <div className="services-cards-container">
              {/* Service Card 1 */}
              <div className="service-card">
                <i className="bi bi-bus-front-fill mb-3" style={{ fontSize: '50px' }}></i>
                <h5 className="service-card-title">Real-Time Bus Tracking</h5>
                <p className="service-card-description">
                  Track your bus in real-time, ensuring you're always on time!
                </p>
              </div>

              {/* Service Card 2 */}
              <div className="service-card">
                <i className="bi bi-clock-fill mb-3" style={{ fontSize: '50px' }}></i>
                <h5 className="service-card-title">Bus Schedule Notifications</h5>
                <p className="service-card-description">
                  Get notified when your bus is near or if there’s a delay.
                </p>
              </div>

              {/* Service Card 3 */}
              <div className="service-card">
                <i className="bi bi-map-fill mb-3" style={{ fontSize: '50px' }}></i>
                <h5 className="service-card-title">Route Planning</h5>
                <p className="service-card-description">
                  Find the best routes for your commute with ease.
                </p>
              </div>
            </div>
          </div>
        )}
        heroClass="services-hero"
        backgroundUrl="url(bus-background-2.jpg)" // Set background for this section
      />
    </div>
  );
};

function AboutUs() {
  return (
    <div>
      <HeroSection 
      heroClass="aboutus-hero"
      backgroundUrl="url(bus-background-3.jpg)"
        content={(
          <div>
            <h1>Meet the Team!</h1>
            <div className="about-cards-container">
              {/* Card 1 */}
<div className="about-card">
  <img 
    src="quan.jpg" 
    alt="Person 1" 
    className="about-card-img"
  />
  <div className="about-card-body">
    <h5 className="about-card-title">Quan Nguyen</h5>
    <p className="about-card-description">
      Quan is an experienced software developer with a passion for creating innovative solutions. 
      He loves working on the backend systems that power our app.
    </p>

    {/* Social Icons Section */}
    <div className="social-icons">
      <a href="https://facebook.com" target="_blank" rel="noopener noreferrer" className="social-icon">
        <i className="bi bi-facebook"></i>
      </a>
      <a href="https://twitter.com" target="_blank" rel="noopener noreferrer" className="social-icon">
        <i className="bi bi-twitter"></i>
      </a>
      <a href="https://linkedin.com" target="_blank" rel="noopener noreferrer" className="social-icon">
        <i className="bi bi-linkedin"></i>
      </a>
    </div>
  </div>
</div>

{/* Card 2 */}
<div className="about-card">
  <img 
    src="mebs.jpg" 
    alt="Person 2" 
    className="about-card-img"
  />
  <div className="about-card-body">
    <h5 className="about-card-title">Mehrab Bhuiyan</h5>
    <p className="about-card-description">
      Mebs is a creative frontend developer with a keen eye for design. 
      He focuses on ensuring the user experience is seamless and intuitive.
    </p>

    {/* Social Icons Section */}
    <div className="social-icons">
      <a href="https://facebook.com" target="_blank" rel="noopener noreferrer" className="social-icon">
        <i className="bi bi-facebook"></i>
      </a>
      <a href="https://twitter.com" target="_blank" rel="noopener noreferrer" className="social-icon">
        <i className="bi bi-twitter"></i>
      </a>
      <a href="https://linkedin.com" target="_blank" rel="noopener noreferrer" className="social-icon">
        <i className="bi bi-linkedin"></i>
      </a>
    </div>
  </div>
</div>

            </div>
          </div>
        )}
      />
    </div>
  );
}

function News() {
  // Sample news data (can be dynamic from an API or a static array)
  const newsItems = [
    {
      title: "New Bus Routes Announced!",
      description: "We're excited to announce new bus routes across the city to make your commute even easier.",
      link: "/news/new-bus-routes-announced"
    },
    {
      title: "Bus Tracking App Updates",
      description: "Our app now offers real-time tracking and improved user experience. Check out the latest features!",
      link: "/news/bus-tracking-app-updates"
    },
    {
      title: "Holiday Bus Schedule",
      description: "For the upcoming holidays, we're running a special bus schedule to accommodate more passengers.",
      link: "/news/holiday-bus-schedule"
    }
  ];

  return (
    <div>
      {/* Hero Section */}
      <HeroSection 
        title="News Page"
        backgroundUrl="url(bus-background-4.jpg)"
        content={(
          <div>
            <p className="other-title text-center">Stay updated with the latest news!</p>

            {/* News Section inside Hero Content */}
            <div className="container my-5">
              <h2 className="text-center">Latest News</h2>
              <div className="row">
                {newsItems.map((item, index) => (
                  <div className="col-md-4 mb-4" key={index}>
                    <div className="card shadow-sm">
                      <div className="card-body text-center">
                        <h5 className="card-title">{item.title}</h5>
                        <p className="card-text">{item.description}</p>
                        <Link to="#" className="btn btn-primary">Read More</Link>
                      </div>
                    </div>
                  </div>
                ))}
              </div>
            </div>
          </div>
        )}
        heroClass="news-hero"
      />
    </div>
  );
}

function FAQ() {
  return (
    <div>
      {/* Hero Section */}
      <HeroSection 
        title="FAQ Page"
        backgroundUrl="url(bus-background-5.jpg)"
        content={(
          <div>
            <p className="other-title text-center">Frequently Asked Questions</p>
            {/* FAQ Accordion Section inside Hero Content */}
            <div className="container my-5 faq-accordion-container">
              <Accordion defaultActiveKey="0">
                {/* Accordion Item 1 */}
                <Accordion.Item eventKey="0">
                  <Accordion.Header>What is the Bus Tracker system?</Accordion.Header>
                  <Accordion.Body className="faq-answer">
                    The Bus Tracker system helps you track buses in real-time, find the best routes, and receive notifications about bus schedules.
                  </Accordion.Body>
                </Accordion.Item>

                {/* Accordion Item 2 */}
                <Accordion.Item eventKey="1">
                  <Accordion.Header>How do I track my bus?</Accordion.Header>
                  <Accordion.Body className="faq-answer">
                    You can track your bus by entering your bus route in the tracking section, and it will show you the real-time location of your bus.
                  </Accordion.Body>
                </Accordion.Item>

                {/* Accordion Item 3 */}
                <Accordion.Item eventKey="2">
                  <Accordion.Header>Can I receive notifications for bus delays?</Accordion.Header>
                  <Accordion.Body className="faq-answer">
                    Yes, you can enable notifications to receive updates if your bus is delayed or approaching your location.
                  </Accordion.Body>
                </Accordion.Item>

                {/* Accordion Item 4 */}
                <Accordion.Item eventKey="3">
                  <Accordion.Header>How do I create a booking?</Accordion.Header>
                  <Accordion.Body className="faq-answer">
                    To create a booking, you need to select the bus route, date, and time, and then confirm the details before booking your ticket.
                  </Accordion.Body>
                </Accordion.Item>

                {/* Accordion Item 5 */}
                <Accordion.Item eventKey="4">
                  <Accordion.Header>What is the route planning feature?</Accordion.Header>
                  <Accordion.Body className="faq-answer">
                    The route planning feature allows you to choose the best routes based on your current location or destination. It helps in optimizing your journey.
                  </Accordion.Body>
                </Accordion.Item>
              </Accordion>
            </div>
          </div>
        )}
        heroClass="notifications-hero"
      />
    </div>
  );
}




function App() {
  return (
    <AuthProvider>
      <Router>
        <div > 
          <Navbar /> {/* Conditionally render the Navbar here */}
          {/* Define Routes here */}
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/services" element={<Services />} />
            <Route path="/news" element={<News />} />
            <Route path="/aboutus" element={<AboutUs />} />
            <Route path="/faq" element={<FAQ />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />

            {/* Protected Routes */}
            <Route
              path="/portaladmin"
              element={
                <ProtectedRoute roles={['Admin']}>
                  <PortalAdmin />
                </ProtectedRoute>
              }
            />
            <Route
              path="/portalcustomer"
              element={
                <ProtectedRoute roles={['Customer']}>
                  <PortalCustomer />
                </ProtectedRoute>
              }
            />
            {/* Add the new route for bookings */}
            <Route
              path="/portalcustomer/bookings"
              element={
                <ProtectedRoute roles={['Customer']}>
                  <PortalCustomerBooking /> {/* Render the Bookings component */}
                </ProtectedRoute>
              }
            />
            <Route
              path="/portalcustomer/create"
              element={
                <ProtectedRoute roles={['Customer']}>
                  <PortalCustomerCreateBooking /> {/* Render the Bookings component */}
                </ProtectedRoute>
              }
            />
            <Route
              path="/portalcustomer/routes"
              element={
                <ProtectedRoute roles={['Customer']}>
                  <PortalCustomerRoutes /> {/* Render the Bookings component */}
                </ProtectedRoute>
              }
            />
            <Route
              path="/portaldriver"
              element={
                <ProtectedRoute roles={['Driver']}>
                  <PortalDriver />
                </ProtectedRoute>
              }
            />
            <Route path="/forbidden" element={<Forbidden />} />

          </Routes>
          <Footer />
        </div>
      </Router>
    </AuthProvider>
  );
}

// Navbar Component - Conditionally Rendered
const Navbar = () => {
  const { user } = useAuth(); // Get the current user from AuthContext
  const location = useLocation(); // Get the current location (path)

  // If the user is on /portalcustomer or its sub-paths, show the navbar
  // If you want to hide the navbar only on specific paths like login, you can modify this
  const hideNavbarOn = ['']; // Add any routes where you don't want the navbar visible

  // Check if the current path matches any of the 'hideNavbarOn' routes
  const shouldHideNavbar = hideNavbarOn.some((path) => location.pathname === path);

  // Function to check if the current path matches the link
  const isActive = (path) => location.pathname === path ? 'active' : '';

  const getPortalLink = (role) => {
    switch (role) {
      case 'customer':
        return '/portalcustomer'; // Redirect to customer portal
      case 'driver':
        return '/portaldriver'; // Redirect to driver portal
      case 'admin':
        return '/portaladmin'; // Redirect to admin portal
      default:
        return '/'; // Fallback to home if role is unknown
    }
  };

  // If `shouldHideNavbar` is true, return null to hide the navbar
  if (shouldHideNavbar) {
    return null;
  }

  return (
    <nav className="navbar navbar-expand-lg fixed-top">
      <div className="container-fluid">
        <Link to="/" className="navbar-brand me-auto">Bus Tracker</Link>
        <div className="offcanvas offcanvas-end" tabIndex="-1" id="offcanvasNavbar" aria-labelledby="offcanvasNavbarLabel">
          <div className="offcanvas-header">
            <h5 className="offcanvas-title" id="offcanvasNavbarLabel">Bus Tracker</h5>
            <button type="button" className="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
          </div>
          <div className="offcanvas-body">
            <ul className="navbar-nav justify-content-center flex-grow-1 pe-3">
              <li className="nav-item">
                <Link to="/services" className={`nav-link mx-lg-2 ${isActive('/services')}`}>Services</Link>
              </li>
              <li className="nav-item">
                <Link to="/aboutus" className={`nav-link mx-lg-2 ${isActive('/aboutus')}`}>About Us</Link>
              </li>
              <li className="nav-item">
                <Link to="/faq" className={`nav-link mx-lg-2 ${isActive('/faq')}`}>FAQ</Link>
              </li>
              <li className="nav-item">
                <Link to="/news" className={`nav-link mx-lg-2 ${isActive('/news')}`}>News</Link>
              </li>
            </ul>
          </div>
        </div>

        {/* Conditionally render login or welcome message with portal button */}
        {user ? (
          <div className="d-flex align-items-center">
            <span className="navbar-text me-3">
              Welcome! {user.firstName} {/* Display user's first name */}
            </span>
            <button 
              className="btn btn-primary" 
              onClick={() => window.location.href = getPortalLink(user.role)}
            >
              Logout
            </button>
          </div>
        ) : (
          <Link to="/login" className="login-button">Login</Link>
        )}

        <button className="navbar-toggler pe-0" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
      </div>
    </nav>
  );
};




export default App;
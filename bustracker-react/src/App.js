import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom'; // Import React Router components
import './App.css';
import HeroSection from './components/HeroSection'; // Import HeroSection component
import Login from './components/Login';
import Register from './components/Register'
import Dashboard from './components/Dashboard';
import Buses from './components/Buses';

function Home() {
  return (
    <HeroSection 
      title="Home Page"
      content={<p>Welcome to the Bus Tracking System!</p>}
      heroClass="home-hero"
    />
  );
}

function RoutesPage() {
  return (
    <HeroSection 
      title="Routes Page"
      content={
        <div>
          <p>Check out the available routes in the system.</p>
          <ul>
            <li>Route 1</li>
            <li>Route 2</li>
            <li>Route 3</li>
          </ul>
        </div>
      }
      heroClass="routes-hero"
    />
  );
}

function Notifications() {
  return (
    <HeroSection 
      title="Notifications Page"
      content={
        <div>
          <p>Stay updated with the latest notifications.</p>
          <div className="alert alert-info">New bus schedule updates available!</div>
        </div>
      }
      heroClass="notifications-hero"
    />
  );
}

function Schedules() {
  return (
    <HeroSection 
      title="Schedules Page"
      content={
        <div>
          <p>Check the bus schedules here.</p>
          <table className="table">
            <thead>
              <tr>
                <th>Bus No</th>
                <th>Departure Time</th>
                <th>Arrival Time</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>101</td>
                <td>08:00 AM</td>
                <td>09:00 AM</td>
              </tr>
              <tr>
                <td>102</td>
                <td>09:30 AM</td>
                <td>10:30 AM</td>
              </tr>
            </tbody>
          </table>
        </div>
      }
      heroClass="schedules-hero"
    />
  );
}


function App() {
  return (
    <Router>
      <div>
        {/* Navbar */}
        <nav className="navbar navbar-expand-lg fixed-top">
          <div className="container-fluid">
            <Link to="/" className="navbar-brand me-auto">Bus Tracker</Link>
            <div className="offcanvas offcanvas-end" tabindex="-1" id="offcanvasNavbar" aria-labelledby="offcanvasNavbarLabel">
              <div className="offcanvas-header">
                <h5 className="offcanvas-title" id="offcanvasNavbarLabel">Bus Tracker</h5>
                <button type="button" className="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
              </div>
              <div className="offcanvas-body">
                <ul className="navbar-nav justify-content-center flex-grow-1 pe-3">
                <li className="nav-item">
                    <Link to="/dashboard" className="nav-link mx-lg-2">Dashboard</Link>
                  </li>
                  <li className="nav-item">
                    <Link to="/buses" className="nav-link mx-lg-2">Buses</Link>
                  </li>
                  <li className="nav-item">
                    <Link to="/routes" className="nav-link mx-lg-2">Routes</Link>
                  </li>
                  <li className="nav-item">
                    <Link to="/notifications" className="nav-link mx-lg-2">Notifications</Link>
                  </li>
                  <li className="nav-item">
                    <Link to="/schedules" className="nav-link mx-lg-2">Schedules</Link>
                  </li>
                </ul>
              </div>
            </div>
            <Link to="/login" className="login-button">Login</Link>
            <button className="navbar-toggler pe-0" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasNavbar" aria-controls="offcanvasNavbar" aria-label="Toggle navigation">
              <span className="navbar-toggler-icon"></span>
            </button>
          </div>
        </nav>

        {/* Define Routes here */}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/buses" element={<Buses />} />
          <Route path="/routes" element={<RoutesPage />} />
          <Route path="/notifications" element={<Notifications />} />
          <Route path="/schedules" element={<Schedules />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;

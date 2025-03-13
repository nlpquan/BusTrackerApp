import HeroSection from "./HeroSection";
import { Link } from 'react-router-dom';

function Register() {
  return (
    <HeroSection 
      content={
        <div className="container register-container d-flex justify-content-center align-items-center fade-in" style={{ minHeight: '80vh' }}> 
          <div className="card register-card" style={{ maxWidth: '500px', width: '100%', padding: '15px', marginBottom: '-8rem' }}> {/* Reduced padding */}
            <div className="card-body">
              <h2 className="card-title text-center" style={{ marginBottom: '1rem', fontSize: '1.1rem' }}>Register Page</h2> {/* Reduced margin and font size */}
              <form>
              <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="username" className="form-label" style={{ fontSize: '0.85rem' }}>Username</label>
                  <input type="email" className="form-control" id="username" placeholder="Enter your username" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                </div>
                <div className="row mb-3">
                  <div className="col" style={{ marginBottom: '-1rem' }}>
                    <label htmlFor="firstName" className="form-label" style={{ fontSize: '0.85rem' }}>First Name</label>
                    <input type="text" className="form-control" id="firstName" placeholder="Enter your first name" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                  </div>
                  <div className="col" style={{ marginBottom: '-1rem' }}>
                    <label htmlFor="lastName" className="form-label" style={{ fontSize: '0.85rem' }}>Last Name</label>
                    <input type="text" className="form-control" id="lastName" placeholder="Enter your last name" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                  </div>
                </div>

                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="email" className="form-label" style={{ fontSize: '0.85rem' }}>Email address</label>
                  <input type="email" className="form-control" id="email" placeholder="Enter your email" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                </div>

                <div style={{ marginBottom: '-1rem' }}>
                  <label htmlFor="password" className="form-label" style={{ fontSize: '0.85rem' }}>Password</label>
                  <input type="password" className="form-control" id="password" placeholder="Enter your password" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                </div>

                <div style={{ marginBottom: '1rem' }}>
                  <label htmlFor="confirmPassword" className="form-label" style={{ fontSize: '0.85rem' }}>Confirm Password</label>
                  <input type="password" className="form-control" id="confirmPassword" placeholder="Confirm your password" required style={{ fontSize: '0.85rem', padding: '0.5rem' }} />
                </div>

                <button type="submit" className="btn btn-primary w-100" style={{ padding: '0.5rem', fontSize: '0.85rem' }}>Register</button> {/* Reduced padding and font size */}
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

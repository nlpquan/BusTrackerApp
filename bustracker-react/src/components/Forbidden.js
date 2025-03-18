import React, { useState, useEffect } from 'react';
import HeroSection from './HeroSection'; // Import HeroSection component

const Forbidden = () => {
  const [fade, setFade] = useState(false);

  useEffect(() => {
    // Trigger the fade-in effect after the component is mounted
    setFade(true);
  }, []);

  return (
    <div className={`forbidden-hero ${fade ? 'fade-in' : ''}`}>
      <HeroSection 
        title={<span className="forbidden-title">403 - Forbidden</span>}
        content={
          <div className="forbidden-content">
            <p>You do not have permission to access this page.</p>
            <a href="/" className="btn btn-primary">Go to Home</a>
          </div>
        }
        heroClass="forbidden-hero"
      />
    </div>
  );
};

export default Forbidden;

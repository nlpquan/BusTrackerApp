import React, { useState } from 'react';
import HeroSection from './HeroSection';

const BusCard = () => {
  const [buses, setBuses] = useState([
    { id: 1, plateNumber: 'ABC123', model: 'Model A', capacity: 40, status: 'active', routes: ['Route 1', 'Route 2'] },
    { id: 2, plateNumber: 'DEF456', model: 'Model B', capacity: 50, status: 'inactive', routes: ['Route 3', 'Route 4'] },
    { id: 3, plateNumber: 'GHI789', model: 'Model C', capacity: 30, status: 'active', routes: ['Route 5', 'Route 6'] },
    { id: 3, plateNumber: 'GHI789', model: 'Model C', capacity: 30, status: 'active', routes: ['Route 5', 'Route 6'] },
  ]);

  const handleDelete = (id) => {
    setBuses(buses.filter(bus => bus.id !== id));
  };

  return (
    <HeroSection content={
    <div className="bus-card-container">
      {buses.map((bus) => (
        <div className="bus-card" key={bus.id}>
          <div className="card-header">
            <h3>{bus.plateNumber}</h3>
            <span className={`status ${bus.status}`}>{bus.status}</span>
          </div>
          <div className="card-body">
            <p><strong>Model:</strong> {bus.model}</p>
            <p><strong>Capacity:</strong> {bus.capacity}</p>
            <p><strong>Assigned Routes:</strong></p>
            <ul>
              {bus.routes.map((route, index) => (
                <li key={index}>{route}</li>
              ))}
            </ul>
          </div>
          <div className="card-footer">
            <button className="edit-btn">Edit</button>
            <button className="delete-btn" onClick={() => handleDelete(bus.id)}>Delete</button>
          </div>
        </div>
      ))}
    </div>
}
    />
  );
};

export default BusCard;

import React from 'react';

const BusCard = ({ bus }) => {
  return (
    <div className="bus-card">
      <div className="bus-card-header">
        <h3>{bus.model}</h3>
        <span className={`status ${bus.status}`}>{bus.status}</span>
      </div>
      <div className="bus-card-body">
        <div className="bus-details">
          <p><strong>Plate Number:</strong> {bus.plateNumber}</p>
          <p><strong>Capacity:</strong> {bus.capacity}</p>
        </div>
      </div>
    </div>
  );
};

export default BusCard;

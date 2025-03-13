import React, { useEffect, useRef } from 'react';
import HeroSection from './HeroSection';

// Dashboard component
const Dashboard = () => {
  const chartRef = useRef(null); // Reference to canvas

  useEffect(() => {
    // Check if Chart.js is available globally (for cases where the CDN isn't loaded properly)
    if (typeof window.Chart !== 'undefined') {
      const ctx = chartRef.current.getContext('2d'); // Get canvas context
    
      // Initialize Chart.js chart
      const chart = new window.Chart(ctx, {
        type: 'bar', // You can use other chart types as well (e.g., 'line', 'pie')
        data: {
          labels: ['Bus 1', 'Bus 2', 'Bus 3'], // X-axis labels
          datasets: [
            {
              label: 'Bus Locations',
              data: [12, 19, 3], // Example data (replace with dynamic data)
              backgroundColor: 'rgba(75, 192, 192, 0.2)', // Background color of bars
              borderColor: 'rgba(75, 192, 192, 1)', // Border color of bars
              borderWidth: 1,
            },
          ],
        },
        options: {
          scales: {
            y: {
              beginAtZero: true, // Start Y-axis from zero
            },
          },
        },
      });

      // Cleanup the chart when component unmounts
      return () => {
        chart.destroy();
      };
    }
  }, []); // Empty dependency array ensures the chart is initialized once

  return (
    <HeroSection
    content={
    <div>
      <h2>Bus Tracking Dashboard</h2>
      <canvas ref={chartRef} width="400" height="400"></canvas>
    </div>
    }
    heroClass="dashboard-hero"
    />
  );
};

export default Dashboard;

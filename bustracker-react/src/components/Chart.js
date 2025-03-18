import React, { useRef, useEffect } from 'react';
import { Doughnut, Pie, Line } from 'react-chartjs-2';
import { Chart as ChartJS, Title, Tooltip, Legend, ArcElement, CategoryScale, LinearScale, PointElement, LineElement } from 'chart.js';

// Registering the necessary Chart.js components
ChartJS.register(Title, Tooltip, Legend, ArcElement, CategoryScale, LinearScale, PointElement, LineElement);

const ChartComponent = () => {
  // Create refs to access the charts
  const doughnutChartRef = useRef(null);
  const pieChartRef = useRef(null);
  const lineChartRef = useRef(null);

  // Doughnut and Pie Chart Data
  const doughnutData = {
    labels: ['Red', 'Blue', 'Yellow'],
    datasets: [{
      label: 'Doughnut Chart',
      data: [300, 50, 100],
      backgroundColor: ['#FF6384', '#36A2EB', '#FFCE56'],
      hoverOffset: 4,
    }],
  };

  const pieData = {
    labels: ['Orange', 'Green', 'Purple'],
    datasets: [{
      label: 'Pie Chart',
      data: [200, 100, 50],
      backgroundColor: ['#FF5733', '#28A745', '#6F42C1'],
    }],
  };

  // Line Chart Data
  const lineData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June'],
    datasets: [
      {
        label: 'Bus Riders',
        data: [12, 19, 3, 5, 2, 3],
        borderColor: '#FF5733',
        backgroundColor: 'rgba(255, 87, 51, 0.2)',
        fill: true,
        tension: 0.4,
      },
    ],
  };

  // Chart options (no animations set here, we'll handle it manually)
  const chartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    animation: {
      duration: 0, // Disable default animations
    },
  };

  // Manually trigger the animation after the chart is loaded
  useEffect(() => {
    // Trigger the animation only after the chart has been rendered
    if (doughnutChartRef.current) {
      doughnutChartRef.current.chartInstance?.update();
    }
    if (pieChartRef.current) {
      pieChartRef.current.chartInstance?.update();
    }
    if (lineChartRef.current) {
      lineChartRef.current.chartInstance?.update();
    }
  }, []); // Empty dependency array ensures this runs once after the component mounts

  return (
    <div className="charts-container">
      <h2 className="charts-heading"></h2>

      {/* Doughnut Chart */}
      <div className="chart-box">
        <h3>Doughnut Chart</h3>
        <Doughnut ref={doughnutChartRef} data={doughnutData} options={chartOptions} />
      </div>

      {/* Pie Chart */}
      <div className="chart-box">
        <h3>Pie Chart</h3>
        <Pie ref={pieChartRef} data={pieData} options={chartOptions} />
      </div>

      {/* Line Chart */}
      <div className="chart-box">
        <h3>Line Chart</h3>
        <Line ref={lineChartRef} data={lineData} options={chartOptions} />
      </div>
    </div>
  );
};

export default ChartComponent;

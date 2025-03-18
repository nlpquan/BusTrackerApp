import React from 'react';
import { Navigate, useLocation } from 'react-router-dom'; // Import Navigate instead of Redirect
import { useAuth } from './AuthContext'; // Assuming you have AuthContext set up

const ProtectedRoute = ({ children, roles }) => {
  const { user } = useAuth(); // Get the current user from AuthContext
  const location = useLocation(); // Get the current location to redirect back to

  // Check if the user is logged in and has the appropriate role
  if (!user) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  if (roles && !roles.includes(user.role)) {
    return <Navigate to="/forbidden" replace />;
  }

  // If the user is authenticated and has the correct role, render the element
  return children;
};

export default ProtectedRoute;

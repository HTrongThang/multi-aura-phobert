import React from 'react';
import { Routes, Route, Router } from 'react-router-dom';
import PostManagementPage from '../pages/Admin/PostManagementPage';
function AdminRoutes() {
  return (
      <Routes>
        <Route path="/PostManagement" element={<PostManagementPage />} />


      </Routes>
  );
}

export default AdminRoutes;

import React from 'react';
import { Routes, Route } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import HomePage from '../pages/Homepage';
import RegisterPage from '../pages/RegisterPage';
import MulRegisterPage from '../pages/multiRegisPage';
import IntroPage from '../pages/IntroPage';
import Myprofile from '../pages/Myprofile';
import Explore from '../pages/Explore';
import Chat from '../pages/ChatPage';
import UserViewProfile from '../pages/UserViewProfile';
import NotificationsPage from '../pages/notificationPage';
import AdminRoutes from './AdminRoutes';

function AppRoutes() {
  return (
    <Routes>
        <Route path="/" element={<IntroPage />} />
        <Route path="*" element={<LoginPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/Home" element={<HomePage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/mulregister" element={<MulRegisterPage />} />
        <Route path="/profile" element={<Myprofile />} />
        <Route path="/explore" element={<Explore />} />
        <Route path="/chat" element={<Chat />} />
        <Route path="/chat/:conversationID" element={<Chat />} />


        <Route path="/notifications" element={<NotificationsPage />} />

        <Route path="/profile/:username" element={<UserViewProfile />} />
        <Route path="/admin/*" element={<AdminRoutes />} /> 

    </Routes>
  
  );
}

export default AppRoutes;

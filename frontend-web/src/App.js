import React from "react";
import "./App.css";
import AppRoutes from "./routes/AppRoutes";
import "./Reset.css";
import "./assets/css/LightMode.css";
import { UserProvider } from "./contexts/UserContext";
function App() {
  return (
    <UserProvider>
      <AppRoutes />
    </UserProvider>
  );
}

export default App;

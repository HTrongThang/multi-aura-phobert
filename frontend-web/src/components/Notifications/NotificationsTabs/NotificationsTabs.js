import React from "react";
import "./NotificationsTabs.css";

const NotificationsTabs = ({ activeTab, setActiveTab }) => {
  const tabs = [
    { label: "Follow", value: "Follow" },
    { label: "Common", value: "Common" },
    { label: "Mentions", value: "Mentions" },
  ];

  return (
    <div className="tabs">
      {tabs.map((tab) => (
        <button
          key={tab.value}
          className={`tab ${activeTab === tab.value ? "active" : ""}`}
          onClick={() => setActiveTab(tab.value)}
        >
          {tab.label}
        </button>
      ))}
    </div>
  );
};

export default NotificationsTabs;

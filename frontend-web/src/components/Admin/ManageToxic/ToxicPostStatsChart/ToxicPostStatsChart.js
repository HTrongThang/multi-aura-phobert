import React from 'react';
import { Line } from 'react-chartjs-2'; // Import biểu đồ Line từ react-chartjs-2
import { Chart as ChartJS } from 'chart.js/auto'; // Import Chart.js

const ToxicPostStatsChart = ({ posts }) => {
  const chartData = {
    labels: posts.map(post => new Date(post.createdAt).toLocaleDateString()), // Đổi định dạng ngày tháng
    datasets: [
      {
        label: 'Số lượng bài viết độc hại',
        data: posts.map(post => post.toxicScore), // Giả sử `toxicScore` là điểm độc hại của bài đăng
        borderColor: 'rgba(75, 192, 192, 1)',
        backgroundColor: 'rgba(75, 192, 192, 0.2)',
        fill: true,
      },
    ],
  };

  return (
    <div className="chart-container">
      <h3 className='text-black'>Biểu đồ thống kê bài viết độc hại</h3>
    </div>
  );
};

export default ToxicPostStatsChart;

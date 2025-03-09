import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import LogoSection from '../components/LogoSection/LogoSection';
import RegisterForm from '../components/RegisterForm/RegisterForm';
import logoImage from '../assets/img/Logo.png';
import { register } from '../services/authService';
import '../assets/css/RegisterPage.css';

function RegisterPage() {
  const [errorMessage, setErrorMessage] = useState(''); // Trạng thái thông báo lỗi
  const navigate = useNavigate();

  // Hàm xử lý đăng ký
  const handleRegister = async (credentials) => {
    try {
      // Thực hiện đăng ký
      const response = await register(credentials.username, credentials.email, credentials.phone, credentials.password);
      console.log('Đăng ký thành công:', response);

      navigate('/');
    } catch (error) {
      console.error("Đăng ký thất bại:", error);

      if (error.response) {
        const status = error.response.status;
        const errorMessage = error.response.data?.message || 'Không có thông tin chi tiết.';

        if (status === 500) {
          setErrorMessage(`Lỗi hệ thống. Vui lòng thử lại sau. Chi tiết: ${errorMessage}`);
        } else if (status === 400) {
          setErrorMessage(`Thông tin đăng ký không hợp lệ. Vui lòng kiểm tra lại. Chi tiết: ${errorMessage}`);
        } else {
          setErrorMessage(`Đăng ký thất bại. Vui lòng thử lại. Chi tiết: ${errorMessage}`);
        }
      } else {
        setErrorMessage(`Đã xảy ra lỗi không xác định. Vui lòng kiểm tra kết nối. Chi tiết: ${error?.message || 'Không có thông tin chi tiết.'}`);
      }
    }
  };

  return (
    <div className="container-fluid register-page d-flex align-items-center justify-content-center">
      <div className="row w-100">
        <div className="col-md-6 d-flex justify-content-center align-items-center register-left">
          <LogoSection
            logoImage={logoImage}
            altText="Multi Aura"
          />
        </div>
        <div className="col-md-6 register-right">
          <RegisterForm onSubmit={handleRegister} /> {/* Form đăng ký */}
          {errorMessage && <p className="text-danger text-center">{errorMessage}</p>} {/* Hiển thị thông báo lỗi */}
        </div>
      </div>
    </div>
  );
}

export default RegisterPage;

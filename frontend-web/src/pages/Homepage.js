import React, { useEffect, useState, useRef } from "react";
import Layout from "../layouts/Layout";
import Feed from "../components/Feed/Feed";
import { useLocation, useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import CreatePostModal from "../components/CreatePostModal/CreatePostModal";
import "../assets/css/HomePage.css"; // Đảm bảo file CSS này đã được cập nhật để dùng biến CSS
import SuccessModal from "../components/SuccessModal/SuccessModal";
import {
  createPost,
  deletePostByid,
  uploadImagePost,
} from "../services/exploreSevice";
import { getNewsPosts } from "../services/searchService";

function Homepage() {
  const [userData, setUserData] = useState(null);
  const [showModal, setShowModal] = useState(false);
  const [buttonPosition, setButtonPosition] = useState({ x: 1820, y: 820 });
  const [dragging, setDragging] = useState(false);
  const [startMousePos, setStartMousePos] = useState({ x: 0, y: 0 });
  const [distanceMoved, setDistanceMoved] = useState(0);
  const [showSuccessModal, setShowSuccessModal] = useState(false);
  const [showSuccessDeleteModal, setshowSuccessDeleteModal] = useState(false);

  const [posts, setPosts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [page, setPage] = useState(1);
  const [hasMorePosts, setHasMorePosts] = useState(true);
  const [errorMessage, setErrorMessage] = useState("");
  const debounceLoadMore = useRef(false);
  const navigate = useNavigate();
  const location = useLocation();
  const authToken = Cookies.get("authToken");

  useEffect(() => {
    if (!authToken) {
      localStorage.removeItem("activeTab"); 
      navigate("/");
    } else if (location.state && location.state.userData) {
      setUserData(location.state.userData);
      localStorage.setItem("user", JSON.stringify(location.state.userData));
    } else {
      const storedUser = localStorage.getItem("user");
      if (storedUser) {
        setUserData(JSON.parse(storedUser));
      }
    }
  }, [authToken, location, navigate]);

  const fetchNewsPosts = async () => {
    try {
      setLoading(true);
      setErrorMessage("");

      const response = await getNewsPosts(1, page); // Giả sử tham số đầu tiên là userID hoặc một giá trị cố định
      if (response?.data) {
        if (response.data.length > 0) {
          setPosts((prevPosts) => [...prevPosts, ...response.data]);
        } else {
          setHasMorePosts(false);
        }
      } else {
        setHasMorePosts(false);
        setErrorMessage("Không có bài viết nào để hiển thị.");
      }
    } catch (error) {
      setErrorMessage("Lỗi khi tải bài viết.");
      console.error("Lỗi khi lấy bài viết:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchNewsPosts();
  }, [page]); // Chỉ gọi lại khi page thay đổi

  const loadMorePosts = () => {
    if (!debounceLoadMore.current && hasMorePosts && !loading) {
      debounceLoadMore.current = true;
      setTimeout(() => (debounceLoadMore.current = false), 1000);
      setPage((prevPage) => prevPage + 1);
    }
  };

  const handleScroll = () => {
    const { scrollTop, clientHeight, scrollHeight } = document.documentElement;
    if (scrollHeight - scrollTop - clientHeight < 200) { // Ngưỡng để tải thêm
      loadMorePosts();
    }
  };

  useEffect(() => {
    window.addEventListener("scroll", handleScroll);
    return () => {
      window.removeEventListener("scroll", handleScroll);
    };
  }, [loading, hasMorePosts]);

  const handleMouseDown = (event) => {
    setDragging(true);
    setStartMousePos({ x: event.clientX, y: event.clientY });
    setDistanceMoved(0);
  };

  const handleMouseMove = (event) => {
    if (dragging) {
      const distance = Math.sqrt(
        Math.pow(event.clientX - startMousePos.x, 2) +
          Math.pow(event.clientY - startMousePos.y, 2)
      );
      setDistanceMoved(distance);
      setButtonPosition({
        x: event.clientX - 25, // Điều chỉnh để tâm nút ở vị trí con trỏ
        y: event.clientY - 25, // Điều chỉnh để tâm nút ở vị trí con trỏ
      });
    }
  };

  const handleMouseUp = () => {
    if (dragging && distanceMoved < 5) { // Coi như là click nếu di chuyển ít
      setShowModal(true);
    }
    setDragging(false);
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };

  const handlePostSubmit = async (postContent, selectedImages, postText) => {
    try {
      const response = await createPost(postContent); // postContent nên là object { content: actualText }
      const ID_post = response.data._id;

      if (selectedImages && selectedImages.length > 0) { // selectedImages nên là FileList hoặc mảng File
        const uploadResponse = await uploadImagePost(
          ID_post,
          selectedImages, // formData sẽ được tạo trong service
          postText // hoặc nội dung text đi kèm ảnh nếu API cần
        );
        // Xử lý response của uploadResponse nếu cần
      }
      // Sau khi post thành công (kể cả có ảnh hay không)
      setShowSuccessModal(true);
      // Làm mới danh sách bài viết sau khi post
      setPosts([]); // Xóa bài viết cũ
      setPage(1); // Reset về trang 1 để fetchNewsPosts tải lại từ đầu
      setHasMorePosts(true); // Reset lại trạng thái có thêm bài
      // fetchNewsPosts(); // Sẽ được gọi bởi useEffect khi page thay đổi về 1
      handleCloseModal();

    } catch (err) {
      console.error("Failed to create post", err);
      setErrorMessage("Tạo bài viết thất bại.");
    }
  };

  const deletePostByID = async (postId) => {
    try {
      await deletePostByid(postId);
      setshowSuccessDeleteModal(true);
      // Làm mới danh sách bài viết sau khi xóa
      setPosts(prevPosts => prevPosts.filter(post => post._id !== postId));
    } catch (error) {
      console.error("Error deleting post:", error);
      setErrorMessage("Xóa bài viết thất bại.");
    }
  };

  return (
    <Layout userData={userData}> {/* Layout có thể chứa Sidebar, nơi quản lý theme */}
      <Feed posts={posts} userData={userData} deletePost={deletePostByID} />
      {loading && <div style={{ textAlign: 'center', padding: '20px' }}>Đang tải thêm bài viết...</div>}
      {!loading && !hasMorePosts && posts.length > 0 && (
        <div style={{ textAlign: 'center', padding: '20px', color: 'var(--text-secondary)' }}>
          Bạn đã xem hết bài viết.
        </div>
      )}
      {errorMessage && <div style={{ textAlign: 'center', padding: '20px', color: 'red' }}>{errorMessage}</div>}
      <div
        className="floating-button" // Đảm bảo class này được style bằng biến CSS trong HomePage.css
        onMouseDown={handleMouseDown}
        onMouseUp={handleMouseUp}
        onMouseMove={handleMouseMove}
        style={{
          left: `${buttonPosition.x}px`,
          top: `${buttonPosition.y}px`,
        }}
        aria-label="Add Post"
        role="button" // Thêm role cho accessibility
      >
        +
      </div>
      {showModal && (
        <CreatePostModal
          onClose={handleCloseModal}
          onPostSubmit={handlePostSubmit}
          userCurent={userData} // userCurrent thay vì userCurent
        />
      )}
      {showSuccessModal && (
        <SuccessModal
          title="Thành công!"
          description="Cảm ơn bạn đã chia sẻ câu chuyện của mình với cộng đồng."
          onClose={() => setShowSuccessModal(false)}
        />
      )}
      {showSuccessDeleteModal && (
        <SuccessModal
          title="Thành công!"
          description="Bạn đã xóa bài viết thành công!"
          onClose={() => setshowSuccessDeleteModal(false)} // Sửa setShowSuccessModal thành setshowSuccessDeleteModal
        />
      )}
    </Layout>
  );
}

export default Homepage;
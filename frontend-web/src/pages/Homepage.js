import React, { useEffect, useState, useRef } from 'react';
import Layout from '../layouts/Layout';
import Feed from '../components/Feed/Feed';
import { useLocation, useNavigate } from 'react-router-dom';
import Cookies from 'js-cookie';
import CreatePostModal from '../components/CreatePostModal/CreatePostModal';
import '../assets/css/HomePage.css';
import SuccessModal from '../components/SuccessModal/SuccessModal';
import { createPost, deletePostByid, uploadImagePost } from '../services/exploreSevice';
import { getNewsPosts } from '../services/searchService';


function Homepage() {
    const [userData, setUserData] = useState(null);
    const [showModal, setShowModal] = useState(false);
    const [buttonPosition, setButtonPosition] = useState({ x: 1820, y: 820 });
    const [dragging, setDragging] = useState(false);
    const [startMousePos, setStartMousePos] = useState({ x: 0, y: 0 });
    const [distanceMoved, setDistanceMoved] = useState(0);
    const [showSuccessModal, setShowSuccessModal] = useState(false);
    const [showSuccessDeleteModal, setshowSuccessDeleteModal] = useState(false);

    const [posts, setPosts] = useState([]); // State to store posts
    const [loading, setLoading] = useState(false);
    const [page, setPage] = useState(1);
    const [hasMorePosts, setHasMorePosts] = useState(true); // Track if more posts can be loaded
    const [errorMessage, setErrorMessage] = useState(''); // Error message state
    const debounceLoadMore = useRef(false); // Prevent rapid multiple API calls
    const navigate = useNavigate();
    const location = useLocation();
    const authToken = Cookies.get('authToken');

    useEffect(() => {
        if (!authToken) {
            localStorage.removeItem('activeTab');
            navigate('/');
        } else if (location.state && location.state.userData) {
            setUserData(location.state.userData);
            localStorage.setItem('user', JSON.stringify(location.state.userData));
        } else {
            const storedUser = localStorage.getItem('user');
            if (storedUser) {
                setUserData(JSON.parse(storedUser));
            }
        }
    }, [authToken, location, navigate]);

    const fetchNewsPosts = async () => {
        try {
            setLoading(true);
            setErrorMessage('');

            const response = await getNewsPosts(1, page);
            if (response?.data) {
                if (response.data.length > 0) {
                    setPosts((prevPosts) => [...prevPosts, ...response.data]);
                } else {
                    setHasMorePosts(false); // Không còn bài viết để tải thêm
                }
            } else {
                setHasMorePosts(false);
                setErrorMessage('Không có bài viết nào để hiển thị.');
            }
        } catch (error) {
            setErrorMessage('Lỗi khi tải bài viết.');
            console.error('Lỗi khi lấy bài viết:', error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchNewsPosts();
    }, [page]);

    const loadMorePosts = () => {
        if (!debounceLoadMore.current && hasMorePosts && !loading) {
            debounceLoadMore.current = true;
            setTimeout(() => (debounceLoadMore.current = false), 1000); // Delay 1s để tránh gọi nhiều lần

            // Tăng page để tải thêm dữ liệu
            setPage((prevPage) => prevPage + 1);  // Tăng số trang lên
        }
    };

    const handleScroll = () => {
        const { scrollTop, clientHeight, scrollHeight } = document.documentElement;
        if (scrollHeight - scrollTop - clientHeight < 200) {
            loadMorePosts(); // Tải thêm khi cuộn đến cuối trang
        }
    };

    useEffect(() => {
        window.addEventListener('scroll', handleScroll);
        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, [loading, hasMorePosts]); // Chỉ tái sử dụng sự kiện khi có sự thay đổi

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
                x: event.clientX - 30,
                y: event.clientY - 30,
            });
        }
    };

    const handleMouseUp = () => {
        if (dragging && distanceMoved < 5) {
            setShowModal(true);
        }
        setDragging(false);
    };

    const handleCloseModal = () => {
        setShowModal(false);
    };

    const handlePostSubmit = async (postContent, selectedImages, postText) => {
        try {
            const response = await createPost(postContent);
            const ID_post = response.data._id;

            if (selectedImages.length > 0) {
                const uploadResponse = await uploadImagePost(ID_post, selectedImages, postText);
                if (uploadResponse.status === 200) {
                    setShowSuccessModal(true);
                    setTimeout(() => {
                        handleCloseModal();
                        fetchNewsPosts();
                    }, 200);
                }
            } else {
                setShowSuccessModal(true);
                setTimeout(() => {
                    handleCloseModal();
                    fetchNewsPosts();
                }, 200);
            }
        } catch (err) {
            console.log('Failed to create post', err);
        }
    };
    const deletePostByID = async (deletePost) => {
            try {
            const respone = await deletePostByid(deletePost);
            window.location.reload();
            setshowSuccessDeleteModal(true);
        } catch (error) {
            console.error("Error deleting post:", error);
        }
    }

    return (
        <Layout userData={userData}>
            <Feed posts={posts} userData={userData} deletePost={deletePostByID} />
            {loading && <div>Đang tải...</div>}
            <div
                className="floating-button"
                onMouseDown={handleMouseDown}
                onMouseUp={handleMouseUp}
                onMouseMove={handleMouseMove}
                style={{
                    left: `${buttonPosition.x}px`,
                    top: `${buttonPosition.y}px`,
                }}
                aria-label="Add"
            >
                +
            </div>
            {showModal && (
                <CreatePostModal
                    onClose={handleCloseModal}
                    onPostSubmit={handlePostSubmit}
                    userCurent={userData}
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
                    description="Bạn đã xóa bài viết thành công !"
                    onClose={() => setShowSuccessModal(false)}
                />
            )}
        </Layout>
    );
}

export default Homepage;

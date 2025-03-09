import React, { useState, useEffect, useRef } from 'react';
import { useParams } from 'react-router-dom';
import Sidebar from '../components/Messages/MessSidebar/SidebarChat';
import ChatContent from '../components/Messages/ChatContent/ChatContent';
import SettingSidebarChat from '../components/Messages/SettingSidebarChat/SettingSidebarChat';
import Layout from '../layouts/Layout';
import '../assets/css/ChatPage.css';
import { getUserConversation, getConversationDetails, sendMessageToConversation, createGroupConversation, uploadImageConversation, addMenberConversation, RemoveMenberConversation } from "../services/chatservice";

import { API_URL_WS } from '../config/config';
import { getFriends } from '../services/RelationshipService';
import SuccessModal from '../components/SuccessModal/SuccessModal';

function ChatPage() {
  const { conversationID } = useParams();
  const [userData, setUserData] = useState(null);
  const [conversations, setConversations] = useState([]);
  const [messages, setMessages] = useState([]);
  const [currentChat, setCurrentChat] = useState(null);
  const [loadingChat, setLoadingChat] = useState(false);
  const [isSidebarOpen, setIsSidebarOpen] = useState(false); // Trạng thái mở/đóng sidebar
  const ws = useRef(null);
  const [newMessageItems, setNewMessageItems] = useState(null);
  const [friends, setFriends] = useState([]);

  const [showSuccessModal, setShowSuccessModal] = useState(false);
  const [showSuccessAddMenberModal, setshowSuccessAddMenberModal] = useState(false);
  const [showSuccessRemoveMenberModal, setshowSuccessRemoveMenberModal] = useState(false);




  useEffect(() => {
    const storedUser = localStorage.getItem('user');
    if (storedUser) {
      setUserData(JSON.parse(storedUser));
    }
  }, []);
  useEffect(() => {
    if (userData && currentChat) {
      ws.current = new WebSocket(`${API_URL_WS}/ws?user_id=${userData.userID}&conversation_id=${currentChat._id}`);

      ws.current.onmessage = (event) => {
        const receivedMessage = JSON.parse(event.data);
        if (receivedMessage.conversationID === currentChat._id) {
          setMessages((prevMessages) => [...prevMessages, receivedMessage]);
          setNewMessageItems(receivedMessage);
        } else {
          console.log("Message does not belong to the current conversation.");
        }
      };

      ws.current.onclose = () => {
        console.log("WebSocket disconnected");
      };

      return () => {
        if (ws.current) ws.current.close();
      };
    }
  }, [userData, currentChat]);

  const fetchConversationDetails = async () => {
    if (userData && conversationID) {
      setLoadingChat(true);
      try {
        const conversationData = await getConversationDetails(conversationID, userData.userID);
        setCurrentChat(conversationData);
        setMessages(conversationData.chats || []);
      } catch (error) {
        console.error('Error fetching conversation details:', error);
      } finally {
        setLoadingChat(false);
      }
    }
  };
  useEffect(() => {
    fetchConversationDetails();
  }, [conversationID, userData]);
  // Lấy danh sách cuộc trò chuyện của người dùng
  const fetchUserConversation = async () => {
    try {
      if (userData) {
        const userConversations = await getUserConversation(userData.userID);
        setConversations(userConversations);
      }
    } catch (error) {
      console.error('Error fetching conversation:', error);
    }
  };
  useEffect(() => {
    if (userData) {
      fetchUserConversation();
    }
  }, [userData]);
  const handleSelectChatMessage = async (conversationID) => {
    setLoadingChat(true);
    try {
      const conversationData = await getConversationDetails(conversationID, userData.userID);
      setCurrentChat(conversationData);
      setMessages(conversationData.chats || []);
      setLoadingChat(false);
    } catch (error) {
      console.error('Error fetching conversation details:', error);
      setLoadingChat(false);
    }
  };

  const handleSendMessage = async (messageContent) => {
    const content = {
      text: messageContent.text || "",
      image: messageContent.image || "",
      voice_url: messageContent.voice_url || ""
    };

    const messageData = {
      conversationID: currentChat._id,
      sender: {
        userID: userData.userID,
        fullname: userData.fullname || "Unknown",
        avatar: userData.avatar || "default-avatar-url"
      },
      content,
      createdat: new Date().toISOString()
    };

    if (ws.current && ws.current.readyState === WebSocket.OPEN) {
      ws.current.send(JSON.stringify(messageData));
    } else {
      console.error("WebSocket is not open.");
    }

    try {
      await sendMessageToConversation(currentChat._id, userData.userID, content);
    } catch (error) {
      console.error("Error sending message:", error);
    }
    setNewMessageItems(messageData);
  };
  const getFriendsbyUser = async () => {
    try {
      const response = await getFriends();
      setFriends(response);
    } catch (err) {
      console.log("fetching get friend", err);
    }

  }

  useEffect(() => {
    getFriendsbyUser();
  }, []);

  const onCreateGroup = async (groupData) => {
    const { title, image, users } = groupData;
    const listUserCurrent = currentChat?.users || [];

    const group = {
      users: [
        ...listUserCurrent.map((user) => user.userID),
        ...users.map((user) => user)
      ]
    };
    try {
      const response = await createGroupConversation(group, title);
      if (response.status === 201) {
        const ID_conversation = response.data._id;
        if (image) {
          const uploadResponse = await uploadImageConversation(ID_conversation, image);
          if (uploadResponse.status === 200) {
            fetchUserConversation();
            setShowSuccessModal(true);

          }
        } else {
        }
      }
    } catch (err) {
      console.error('Lỗi khi tạo cuộc trò chuyện:', err.message || err);
    }
  };

  const onAddMenberGroup = async (groupData_addMenber) => {
    const id_conversation = currentChat?._id;
    try {
      const response = await addMenberConversation(groupData_addMenber, id_conversation);
      if (response.status === 200) {

        setshowSuccessAddMenberModal(true);
        window.location.reload();

      }
    } catch (err) {
      console.error('Lỗi khi thêm thành viên vào cuộc trò chuyện:', err.message || err);
    }
  };

  const onRemoveMenberGroup = async (userID) => {
    const id_conversation = currentChat?._id;
    try {
      const response = await RemoveMenberConversation(userID, id_conversation);
      console.log(response);
      if (response.status === 200) {

        setshowSuccessRemoveMenberModal(true);
        window.location.reload();
      }
    } catch (err) {
      console.error('Lỗi khi xóa thành viên vào cuộc trò chuyện:', err.message || err);
    }
  };
  return (
    <Layout userData={userData}>
      <div className={`container-fluid chat-page ${isSidebarOpen ? 'with-sidebar' : ''}`}>
        <div className="row">
          <div className="col-lg-3 col-md-3 col-sm-12 sidebar-wrapper"
          style={{

            background:"black"
          }}>
            <Sidebar
              conversations={conversations}
              onSelectChat={handleSelectChatMessage}
              newMessageItems={newMessageItems}
              selectedChatId={currentChat?._id}
            />
          </div>
          <div
            className={`col-lg-9 col-md-9 col-sm-12 chat-content-wrapper`}
            style={{
              display: 'flex',
              height: '90vh',
              padding: '0',
              background:"black"
            }}
          >

            <div
              className={`chat-content ${isSidebarOpen ? 'shrink-content' : ''}`}
              style={{ flex: isSidebarOpen ? '0.7' : '1', transition: 'flex 0.3s ease' }}
            >
              {loadingChat ? (
                <div>Loading chat...</div>
              ) : currentChat ? (
                <ChatContent
                  chat={currentChat} // Truyền currentChat xuống
                  messages={messages}
                  currentUserID={userData.userID}
                  onSendMessage={handleSendMessage}
                  onToggleSidebar={() => setIsSidebarOpen(!isSidebarOpen)} // Truyền hàm mở/đóng sidebar
                  isSidebarOpen={isSidebarOpen} // Trạng thái sidebar
                  userData={userData} // Truyền userData xuống
                />

              ) : (
                <div>Please select a chat to view</div>
              )}
            </div>

            {/* Sidebar */}
            {isSidebarOpen && (
              <SettingSidebarChat
                isOpen={isSidebarOpen}
                currentChat={currentChat}
                userCurent={userData}
                dataFriend={friends}
                onCreateGroup={onCreateGroup}
                onAddMenberGroup={onAddMenberGroup}
                onRemoveMenberGroup={onRemoveMenberGroup}
              />
            )}



          </div>
        </div>
      </div>
      {showSuccessModal && (
        <SuccessModal
          title="Thành công!"
          description="Cảm ơn bạn đã tạo nhóm thành công."
          onClose={() => setShowSuccessModal(false)}
        />
      )}

      {showSuccessAddMenberModal && (
        <SuccessModal
          title="Thành công!"
          description="Bạn đã thêm thành viên mới thành công."
          onClose={() => setShowSuccessModal(false)}
        />
      )}

      {showSuccessRemoveMenberModal && (
        <SuccessModal
          title="Thành công!"
          description="Bạn đã rời nhóm thành công."
          onClose={() => setShowSuccessModal(false)}
        />
      )}
    </Layout>
  );
}

export default ChatPage;

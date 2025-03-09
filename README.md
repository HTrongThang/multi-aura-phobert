<h2>Team Name: Workajolibee</h2>
<h3 style="text-align:center">Social Network</h3>

-----------------------------------------------
-----------------------------------------------

<h3>Team Members</h3>

| No. | Student ID  | Full Name          | Role         |
|:---:|:-----------:|:-------------------|:------------:|
| 1   | 2001215790  | Nguyen Huy Hoang   | Team Leader  |
| 2   | 2001216199  | Nguyen Minh Thu     | Member        |
| 3   | 2001216158  | Ha Trong Thang      | Member        |

-----------------------------------------------
### Technologies Used
- .NET Framework version 4.7.2
- Visual Studio 2019
- Python 3.10.2
- Go 1.23.1
-----------------------------------------------
-----------------------------------------------
<h1>Project Introduction</h1>
# Project
## <h2>Multi Aura Social Network</h2>

<h3>Project Description:</h3>
<p>Multi Aura is a multi-platform social networking application system that allows users to post articles, comment using text, and utilize an API to convert text into sound. This enables users to understand content without reading text, interact, send messages, make friends, and more.</p>

<p>When using the application, users will experience the 4.0 digital space where everyone can share wonderful moments and chat together. We have noticed that some users, especially those new to technology, may face communication challenges, such as not being able to read text or visually impaired individuals who want to read news or communicate with their loved ones. Understanding this need, our small team aims to realize our idea by providing a space where everyone can communicate without any restrictions. This is the purpose and mission of Multi Aura.</p>

<h3>Project Scope:</h3>
<p>The "Multi Aura Social Network" project will focus on developing a social networking system that supports:</p>

- Converting text to sound via API to help users easily access content without reading.
- Enabling users to interact, send messages, make friends, and share moments through posts and comments.
- Developing the application across multiple platforms (web, mobile) to ensure users can experience it on various devices.
- Providing strong support for users with visual impairments or those who prefer listening to content instead of reading.

<h3>Objectives and Necessity of the Topic:</h3>

<p>Objectives:</p>
- Develop a user-friendly social network for all users, especially those with visual impairments or those who prefer experiencing content through sound.
- Create a connected space for everyone without language barriers or reading capabilities by converting text to sound.

<p>Necessity:</p>
- Currently, social networks primarily focus on providing content through text, images, and videos, without adequately supporting users who prefer accessing information through sound. This creates difficulties for users, especially visually impaired individuals or the elderly.
- Multi Aura is created to address this issue by providing a text-to-sound conversion solution. This allows everyone, regardless of their reading ability, to participate and share content easily, seamlessly integrating into an environment without language barriers.

-----------------------------------------------

### Requirements
<p>AI: Text-to-Sound API</p>
<p>Web</p>
<p>Languages: Go, JavaScript</p>
<p>Frameworks: Bootstrap, Golang, ReactJS</p>
-----------------------------------------------

| No. | Feature               | Assignment | Progress |
|:---:|:---------------------:|:----------:|:--------:|
| 1   | Login/Logout          |            |          |
| 2   | Register              |            |          |
| 3   | CRUD Post             |            |          |
| 4   | Share Post            |            |          |
| 5   | Save Post             |            |          |
| 6   | Comment Post          |            |          |
| 7   | Post Reaction         |            |          |
| 8   | Chat (CRUD Message)   |            |          |
| 9   | Chat (Message Reaction)|           |          |
| 10  | Add/Delete Friend     |            |          |
| 11  | Manage Profile        |            |          |
| 12  | Search                |            |          |

-----------------------------------------------
<p>Winform</p>
<p>Languages: C#, JavaScript</p>
<p>Framework: ADO.NET</p>

| No. | Feature               | Assignment | Progress |
|:---:|:---------------------:|:----------:|:--------:|
| 1   | Login/Logout          |            |          |
| 2   | Register              |            |          |
| 3   | CRUD Post             |            |          |
| 4   | Share Post            |            |          |
| 5   | Save Post             |            |          |
| 6   | Comment Post          |            |          |
| 7   | Post Reaction         |            |          |
| 8   | Chat (CRUD Message)   |            |          |
| 9   | Chat (Message Reaction)|           |          |
| 10  | Add/Delete Friend     |            |          |
| 11  | Manage Profile        |            |          |
| 12  | Search                |            |          |

-------------------------------------------------

<h2>Business Processes</h2>

<h3>User Registration and Verification Process:</h3>

- **Description:** New users must register an account using their email or social media information. The system will then send a verification email to activate the account.
- **Process:**
  1. User enters registration information.
  2. System verifies the entered user information.
  3. System sends a verification email.
  4. After verification, the user can log in to the system.

<h3>Login Process:</h3>

- **Description:** Users can log in after registering an account.
- **Process:**
  1. User enters login information.
  2. System verifies the entered user information.
  3. After verification:
     - **Success:** User is redirected to the homepage.
     - **Failure:** User receives a notification to check their information.

<h3>Profile Management Process:</h3>
- **Description:** Users can update their personal information and manage the privacy settings of their profiles.

- **Process:**
  1. User accesses the profile management page:
     - User selects the "Profile" section in the application to view and edit personal information.
  2. User updates personal information:
     - User can change their name, avatar, gender, birthdate, address, or other information.
  3. System saves the updated information:
     - After editing, the system records and updates the personal information in the database.
  4. Manage privacy settings:
     - User can set privacy levels for their profile (Public, Friends, Private) to determine who can view their information.

<h3>Friend Search:</h3>
- **Description:** Users can search for friends by name, email, or username.

- **Process:**
  1. User enters a search keyword:
     - User inputs name, email, or username into the search bar.
  2. System searches and displays results:
     - System queries the database and returns a list of users matching the keyword.
  3. User can follow the selected user:
     - User selects from the search results and follows them.

<h3>Post Creation Process:</h3>
- **Description:** Users can create, read, update, and delete their own posts.

- **Process:**
  1. User logs into their account:
     - User completes the login process.
     - After logging in, the system redirects the user to the homepage.
  2. User selects the create post function:
     - On the homepage, there is a function to create a new post.
     - Clicking it will display all the features for creating a new post.
  3. Enter post content and options (images, tags, etc.):
     - User can input the post information.
     - Attaching images is optional.
  4. Click to confirm post submission.
  5. System saves the post to the database.
  6. After posting, the post is displayed on the news feed.
  7. User can edit or delete their created post:
     - User can review their post information on their profile page.
     - Select the post to edit its content or delete it.

<h3>Commenting Process:</h3>
- **Description:** Users can comment on posts.

- **Process:**
  1. User logs into their account:
     - User completes the login process.
     - After logging in, the system redirects the user to the homepage.
  2. User selects the post they want to comment on:
     - While viewing the list of new or friends' posts.
     - To leave a comment on a post.
     - Select the desired post.
     - Choose the comment function on the right side of the post.
  3. Enter comment content:
     - User can input their comment on the post.
     - Attaching images is optional.
  4. System saves the comment and displays it under the post.
  5. User can edit or delete their own comment:
     - User can review their comment information by selecting the post.
     - Or view commented posts in the activity management function.
     - Can edit or delete their own comments.

<h3>Post Sharing Process</h3>
- **Description:** Users can share their own or others' posts to their personal timeline.

- **Process:**
  1. User logs into their account:
     - User completes the login process.
     - After logging in, the system redirects the user to the homepage.
  2. User selects the post they want to share:
     - While viewing the list of new or friends' posts.
     - To share the post so friends can see it.
     - Select the desired post.
     - Choose the share function on the right side of the post.
  3. Enter status content when sharing:
     - User can input introductory content about the post.
  4. Choose the sharing method:
     - Share to their personal profile.
     - Or send to friends via messaging.
  5. System saves the shared post status.
  6. System displays the shared post on the platform:
     - User can review the posts they have shared on their personal profile.
     - Or view shared posts in the activity management function.
  7. User can modify the post status or delete it.

<h3>Following Process</h3>
- **Description:** Users can follow other users to receive notifications about their activities.

- **Process:**
  1. User logs into their account:
     - User completes the login process.
     - After logging in, the system redirects the user to the homepage.
  2. User searches for other users:
     - User can search by name, email, or username.
     - When the system returns results, user can select the desired user.
  3. Select the user to follow:
     - Upon selection, the user is redirected to the selected user's profile page.
     - Displays user information (full name, number of followers, following), list of mutual friends, etc.
  4. Click the "Follow" button.
  5. System records the follow action in the database.
  6. System updates the following list and notifies the user.
  7. Transition to Friend:
     - When a user follows another user.
     - If the followed user is also following back, the system updates both statuses to friends.
     - When a user clicks "Follow Back," the system updates the status of both users to friends.


<h2>Tên nhóm: Workajolibee</h2>
<h3 style="text-align:center">Social Network</h3>

-----------------------------------------------
-----------------------------------------------

<h3>Thành viên nhóm</h3>

| Số thứ tự | Mã số sinh viên  | Họ và tên  | Chức vụ |
|:---------:|:------------:|:---------------:|:-----:|
| 1 | 2001215790  | Nguyễn Huy Hoàng | Trưởng nhóm  |
| 2 | 2001216199  | Nguyễn Minh Thư | Thành viên  |
| 3 | 2001216158  | Hà Trọng Thắng | Thành viên  |

-----------------------------------------------
### Sử dụng 
 - .Net Framework version 4.7.2
 - Visual studio 2019
 - Python 3.10.2
 - go 1.23.1
-----------------------------------------------
-----------------------------------------------
<h1>Giới thiệu đồ án</h1>
# Dự án
## <h2>Mạng xã hội multi aura</h2>

<h3>Mô tả dự án: </h3>
<p>multi aura là một hệ thống ứng dụng mạng xã hội đa nền tảng cho phép người dùng có thể đăng bài viết, bình luận bằng text sử dụng api để chuyển thành sound giúp cho người dùng có thể hiểu được nội dung mà không cần phải đọc chữ, tương tác, nhắn tin, kết bạn,...</p>

<p>Người dùng khi sử dụng ứng dụng sẽ được trải nghiệm không gian mạng 4.0 một nơi mà tất cả mọi người có thể cùng nhau chia sẽ cac khoảnh khắc tuyệt vời và trò chuyện cùng nhau nhận thấy hiện nay một số người khi vừa mới tiếp cận với công nghệ thì sẽ có thể gặp một số khăn về vấn đề giao tiếp chẳng hạn như họ không nhìn được mặt chữ hay là những người mà có vấn đề về thị giác họ muốn đọc báo tin tức giao tiếp cùng những người thân quen của họ chẳng hạn. Nắm được nhu cầu ấy chúng em một bộ phận nhỏ muốn hiện thực hóa ý tưởng của chúng em là mang đến một không gian cho tất cả mọi người đều có thể giao tiếp với nhau không có bất kì sự ràng buộc nào cả. Đó là mục đích và là sứ mệnh của multi aura</p>

<h3>Phạm vi của đồ án:</h3>
<p>Dự án "Mạng xã hội Multi Aura" sẽ tập trung vào việc phát triển một hệ thống mạng xã hội hỗ trợ:</p>

- Chuyển đổi văn bản thành âm thanh qua API giúp người dùng dễ dàng tiếp cận nội dung mà không cần đọc.
- Hỗ trợ người dùng tương tác, nhắn tin, kết bạn và chia sẻ khoảnh khắc với nhau thông qua các bài viết, bình luận.
- Ứng dụng được phát triển trên đa nền tảng (web, mobile), đảm bảo người dùng có thể trải nghiệm từ nhiều thiết bị khác nhau.
- Đảm bảo hỗ trợ tốt cho những người gặp khó khăn về thị giác hoặc người thích nghe nội dung thay vì đọc.
  
<h3>Mục tiêu, sự cần thiết của đề tài:</h3>

<p>Mục tiêu:</p>
- Phát triển một mạng xã hội thân thiện với tất cả người dùng, đặc biệt là những người gặp khó khăn về thị giác hoặc những người thích trải nghiệm nội dung qua âm thanh.
- Tạo ra một không gian kết nối mọi người mà không có rào cản về ngôn ngữ hay khả năng đọc, thông qua việc chuyển đổi văn bản thành âm thanh.

<p>Sự cần thiết:</p>
- Hiện tại, các mạng xã hội chủ yếu tập trung vào việc cung cấp nội dung bằng văn bản, hình ảnh và video, mà chưa hỗ trợ tốt cho người dùng muốn tiếp cận thông tin bằng âm thanh. Điều này khiến cho người dùng gặp khó khăn, đặc biệt là những người khiếm thị hoặc người lớn tuổi.
- Multi Aura ra đời để giải quyết vấn đề này, bằng cách cung cấp giải pháp chuyển đổi văn bản thành âm thanh. Điều này giúp mọi người, bất kể khả năng đọc, đều có thể tham gia và chia sẻ nội dung một cách dễ dàng và dễ dàng hòa nhập vào một môi trường mà tại đó không có bất kì rào cản về ngôn ngữ.

-----------------------------------------------

### Yêu cầu 
<p>AI: api text to sound</p>
<p>Web</p>
<p>Ngôn ngữ: Go, Javascript</p>
<p>Framework: Bootstrap,  Golang , Reactjs </p>
-----------------------------------------------

| Số thứ tự | Nghiệp vụ  | Phân công  | Tiến độ |
|:---------:|:------------:|:---------------:|:-----:|
| 1 | Login/Logout  |  | |
| 2 | Register  | | |
| 3 | CRUD Post  | |  |
| 4 | Share Post  | | |
| 5 | Save Post  | | |
| 6 | Comment Post  | |  |
| 7 | Post Reaction | | |
| 8 | Chat (CRUD Message) | |  |
| 9 | Chat (Message Reaction)  ||  |
| 10 | Add/Delete Friend  ||  |
| 11 | Manager Profile  ||  |
| 12 | Search  ||  |



-----------------------------------------------
<p>Winform</p>
<p>Ngôn ngữ: C#, Javascript</p>
<p>Framework: ADO.NET</p>

| Số thứ tự | Nghiệp vụ  | Phân công  | Tiến độ |
|:---------:|:------------:|:---------------:|:-----:|
| 1 | Login/Logout  |  | |
| 2 | Register  | | |
| 3 | CRUD Post  | |  |
| 4 | Share Post  | | |
| 5 | Save Post  | | |
| 6 | Comment Post  | |  |
| 7 | Post Reaction | | |
| 8 | Chat (CRUD Message) | |  |
| 9 | Chat (Message Reaction)  ||  |
| 10 | Add/Delete Friend  ||  |
| 11 | Manager Profile  ||  |
| 12 | Search  ||  |


-------------------------------------------------

<h2>Các quy trình nghiệp vụ</h2>

<h3>Quy trình đăng ký và xác thực người dùng:</h3>

- Mô tả: Người dùng mới cần phải đăng ký tài khoản bằng email hoặc thông tin mạng xã hội, sau đó hệ thống sẽ gửi email xác nhận để kích hoạt tài khoản.
- Quy trình:
  
  1 Người dùng nhập thông tin đăng ký.
    
  2 Hệ thống kiểm tra thông tin người dùng nhập. 
  
  3 Hệ thống gửi email xác thực. 
  
  4 Sau khi xác thực, người dùng có thể đăng nhập vào hệ thống.

<h3>Quy trình đăng nhập:</h3>

- Mô tả: Người dùng sau khi đăng kí tài khoản có thể đăng nhập.
- Quy trình:
  
  1 Người dùng nhập thông tin đăng nhập.
  
  2 Hệ thống kiểm tra thông tin người dùng nhập.
  
  3 Sau khi kiểm tra nếu:
    - Thành công: người dùng sẽ được chuyển đến trang chủ.
    - Thất bại: người dùng sẽ nhận được thông báo kiểm tra lại thông tin.

<h3>Quy trình quản lý hồ sơ cá nhân (Profile Management):</h3>
- Mô tả: Người dùng có thể cập nhật thông tin cá nhân và quản lý quyền riêng tư của hồ sơ.

- Quy trình:

  1 Người dùng truy cập trang quản lý hồ sơ:

   - Người dùng chọn phần "Hồ sơ" trong ứng dụng để xem và chỉnh sửa thông tin cá nhân.
     
  2 Người dùng cập nhật thông tin cá nhân:

   - Người dùng có thể thay đổi tên, ảnh đại diện, giới tính, ngày sinh, địa chỉ hoặc các thông tin khác.
     
  3 Hệ thống lưu thông tin cập nhật:

   - Sau khi người dùng chỉnh sửa, hệ thống ghi nhận và cập nhật thông tin cá nhân trong cơ sở dữ liệu.
     
  4 Quản lý quyền riêng tư:

   - Người dùng có thể cài đặt quyền riêng tư cho hồ sơ (Công khai, Bạn bè, Cá nhân) để quyết định ai có thể xem thông tin của họ.


<h3>Tìm kiếm bạn bè:</h3>
- Mô tả: Người dùng có thể tìm kiếm bạn bè qua tên, email hoặc username.

- Quy trình:

   1 Người dùng nhập từ khóa tìm kiếm:

    - Người dùng nhập tên, email hoặc username vào thanh tìm kiếm.
      
   2 Hệ thống tìm kiếm và hiển thị kết quả:

    - Hệ thống truy vấn cơ sở dữ liệu và trả về danh sách người dùng phù hợp với từ khóa.
      
   3 Người dùng có thể follow người đã chọn

    - Người dùng có thể chọn từ danh sách kết quả và follow họ.


<h3>Quy trình tạo bài viết:</h3>
- Mô tả: Người dùng có thể tạo, đọc, cập nhật và xóa bài viết của mình.

- Quy trình:

   1 Người dùng cần đăng nhập tài khoản của mình:

    - Người dùng cần hoàn tất quy trình đăng nhập tài khoản cá nhân.
    - Sau khi hoàn tất đăng nhập hệ thống sẽ chuyển hướng người dùng đến trang 
      
   2 Người dùng chọn chức năng tạo bài viết.:

    - Ở dầu trang Home có chức năng tạo bài viết mới.
    - Khi nhấn vào sẽ hiễn thi toàn bộ chức năng của tạo bài viết mới 
      
   3 Nhập nội dung bài viết và các tùy chọn (hình ảnh, tag, v.v.).

    - Người dùng có thể nhập thông tin bài viết
    - Đăng kèm với hình ảnh hoặc không đều được
  
   4 Nhấn chọn xác nhận đăng bài viết.
  
   5 Hệ thống lưu bài viết vào cơ sở dữ liệu.

   6 Sau khi hoàn tất đăng bài. bài viết sẽ được hiển thị lên trang new Feed.

   7 Người dùng có thể chỉnh sửa hoặc xóa bài viết đã tạo.
  
     - Người dùng có thể xem lại thông tin bài viết của mình ở trang cá nhân
     - Chọn vào bài viết và có thể sửa nội dung bài viết hoặc xóa bài viết 
   

<h3>Quy trình bình luận:</h3>
- Mô tả: Người dùng có thể bình luận về các bài viết.

- Quy trình:

   1 Người dùng cần đăng nhập tài khoản của mình:

    - Người dùng cần hoàn tất quy trình đăng nhập tài khoản cá nhân.
    - Sau khi hoàn tất đăng nhập hệ thống sẽ chuyển hướng người dùng đến trang 
      
   2 Người dùng chọn bài viết muốn bình luận.
  
    - Người dùng khi đang xem danh sách bài viết mới hay của bạn bè.
    - Muốn dể lại bình luận cho bài viết
    - Chọn vào bài viết đấy.
    - Chọn chức năng bình luận ở bên phải của bài viết.
      
   3 Nhập nội dung bình luận..

    - Người dùng có thể nhập nội dung bình luận về bài viết
    - Có thẻ Đính kèm với hình ảnh hoặc không đều được
  
   4 Hệ thống lưu bình luận và hiển thị dưới bài viết.
  
   5 Người dùng có thể chỉnh sửa hoặc xóa bình luận của mình.
  
    - Người dùng có thể xem lại thông tin bình luận của mình khi chọn vào bài viết ấy
    - Hoặc có thể xem lại các bài viết đã bình luận ở chức năng quản lí hoạt dộng.
    - Có thể chỉnh sửa hoặc xóa bình luận của bản thân.
      
<h3>Quy trình chia sẻ bài viết</h3>
- Mô tả: Người dùng có thể chia sẻ bài viết của mình hoặc của người khác lên dòng thời gian cá nhân.

- Quy trình:

   1 Người dùng cần đăng nhập tài khoản của mình:

    - Người dùng cần hoàn tất quy trình đăng nhập tài khoản cá nhân.
    - Sau khi hoàn tất đăng nhập hệ thống sẽ chuyển hướng người dùng đến trang 
      
   2 Người dùng chọn bài viết muốn chia sẻ.
  
    - Người dùng khi đang xem danh sách bài viết mới hay của bạn bè.
    - Muốn chia sẽ bài viết dể bạn bè của mình được thấy.
    - Chọn vào bài viết đấy.
    - Chọn chức năng chia  ở bên phải của bài viết.
      
   3 Nhập nội dung status khi chia sẽ.

    - Người dùng có thể nhập nội dung giới thiệu về bài viết
  
   4 Chọn phương thức chia sẻ

    - Chia sẽ về trang cá nhân của mình
    - Hay gửi cho bạn bè thông qua tin

   5 Hệ thống Lưu trạng thái chia sẽ bài viết.
  
   6 Hệ thống hiển thị bài viết đã được chia sẻ trên nền tảng.
  
    - Người dùng có thể xem lại các bài viết mình đã chia sẽ ở trang cá nhân bản thân.
    - Hoặc có thể xem lại các bài viết đã chia sẽ ở chức năng quản lí hoạt dộng.
  
   7 Người dùng có thể thay đổi status bài đăng hoặc xóa đi.


<h3>Quy trình theo dõi</h3>
- Mô tả: Người dùng có thể theo dõi những người dùng khác để nhận thông báo về hoạt động của họ.

- Quy trình:

   1 Người dùng cần đăng nhập tài khoản của mình:

    - Người dùng cần hoàn tất quy trình đăng nhập tài khoản cá nhân.
    - Sau khi hoàn tất đăng nhập hệ thống sẽ chuyển hướng người dùng đến trang 
      
   2 Người dùng tìm kiếm..
  
    - Người dùng có thể tìm kiếm theo tên, gmail, username
    - Khi hệ thống trả về kết quả có thể chọn người dùng mà mình cần 

      
   3 chọn người dùng muốn theo dõi.

    - Khi chọn sẽ chuyển đến trang giới thiệu người dùng.
    - Tại dây hiển thị thông tin người dùng (họ tên, số lượt follower, following), danh sách bạn bè chung, ...)
  
   4 Nhấn nút "Theo dõi".
  
   5 Hệ thống ghi nhận vào cơ sỏ dữ liệu.

   6 Hệ thống cập nhật danh sách theo dõi và thông báo cho người dùng.

   7 Chuyển dổi thành Friend

     - Khi một người dùng follow người khác.
     - Khi một người bạn đang follow vào trang cá nhân của bạn. Hệ thông sẽ kiểm tra mỗi quan hệ của cả hai nếu đối phương đang follow bạn sẽ hiện follow back.
     - Khi người dùng nhấn vào follow back hệ thống sẽ cập nhật lại trạng thái của cả 2 thành friend
   
  

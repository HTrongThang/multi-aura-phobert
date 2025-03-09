using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;

namespace CustomControl.Commons
{
    public partial class VoicePlayerCommon : UserControl
    {
        private Image gifImage;        // Ảnh GIF động
        private Image staticImage;     // Ảnh tĩnh từ GIF (Frame đầu tiên)
        private Timer gifTimer;        // Timer để điều khiển việc bật lại GIF
        private int timeLeft;          // Thời gian còn lại
        private int totalTime = 0;     // Tổng thời gian

        private WindowsMediaPlayer player;

        private string mp3URL;

        public string Mp3URL
        {
            get => mp3URL;
            set
            {
                mp3URL = value;
                ResetPlayer();
            }
        }

        public VoicePlayerCommon()
        {
            InitializeComponent();

            gifImage = buttonVoicePlayer.Image;

            staticImage = ExtractFirstFrame((Bitmap)gifImage);

            gifTimer = new Timer();
            gifTimer.Interval = 1000;
            gifTimer.Tick += GifTimer_Tick;

            this.labelTimer.Text = $"00:{totalTime:00}";

            buttonVoicePlayer.Click += ButtonVoicePlayer_Click;

            buttonVoicePlayer.Image = staticImage;

            player = new WindowsMediaPlayer();
        }

        private void ButtonVoicePlayer_Click(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                // Nếu đang phát, dừng phát và reset lại thời gian
                StopAudio();
                gifTimer.Stop();
                buttonVoicePlayer.Image = staticImage;  // Đổi lại ảnh thành tĩnh
                labelTimer.Text = $"00:{totalTime:00}";  // Reset lại thời gian hiển thị
            }
            else
            {
                // Nếu không đang phát, chuẩn bị và phát nhạc
                if (!string.IsNullOrEmpty(mp3URL))
                {
                    SetTotalTime(mp3URL); // Thiết lập URL và tổng thời gian
                    buttonVoicePlayer.Image = gifImage;  // Đổi lại ảnh thành gif động
                    timeLeft = totalTime;
                    labelTimer.Text = $"00:{timeLeft:00}";

                    gifTimer.Start();
                    PlayAudio(mp3URL);  // Phát âm thanh khi người dùng nhấn nút
                }
                else
                {
                    MessageBox.Show("URL MP3 chưa được thiết lập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void GifTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                labelTimer.Text = $"00:{timeLeft:00}";
            }
            else
            {
                gifTimer.Stop();
                buttonVoicePlayer.Image = staticImage;
                labelTimer.Text = $"00:{totalTime:00}";
            }
        }

        // Hàm để lấy frame đầu tiên của GIF (tạo ảnh tĩnh)
        private Image ExtractFirstFrame(Bitmap gif)
        {
            Bitmap firstFrame = new Bitmap(gif.Width, gif.Height);

            using (Graphics g = Graphics.FromImage(firstFrame))
            {
                g.DrawImage(gif, new Point(0, 0));
            }

            return firstFrame;
        }

        private void SetTotalTime(string mp3Url)
        {
            if (player != null && !string.IsNullOrEmpty(mp3Url))
            {
                // Đặt URL cho player
                player.URL = mp3Url;

                // Đăng ký sự kiện PlayStateChange thủ công
                player.PlayStateChange += Player_PlayStateChange;
            }
        }

        private void Player_PlayStateChange(int newState)
        {
            // Kiểm tra nếu trạng thái đã chuyển sang Playing (bài hát đã bắt đầu phát)
            if (newState == (int)WMPPlayState.wmppsPlaying)
            {
                totalTime = (int)player.currentMedia.duration; // Lấy tổng thời gian (duration)
                labelTimer.Text = $"00:{totalTime:00}"; // Cập nhật thời gian hiển thị
            }
            else if (newState == (int)WMPPlayState.wmppsMediaEnded)
            {
                // Khi bài hát kết thúc, dừng phát và reset lại thời gian
                StopAudio();
                gifTimer.Stop();
                buttonVoicePlayer.Image = staticImage; // Đổi ảnh về trạng thái tĩnh
                labelTimer.Text = $"00:{totalTime:00}"; // Reset lại thời gian hiển thị
            }
        }

        private void PlayAudio(string mp3Url)
        {
            if (player != null && !string.IsNullOrEmpty(mp3Url))
            {
                player.URL = mp3Url;
                player.controls.play();
            }
        }

        private void StopAudio()
        {
            if (player != null)
            {
                player.controls.stop();
            }
        }

        // Reset lại trạng thái player khi thay đổi URL
        private void ResetPlayer()
        {
            StopAudio();
            gifTimer.Stop();
            buttonVoicePlayer.Image = staticImage; // Reset lại ảnh
            labelTimer.Text = $"00:00"; // Reset lại thời gian hiển thị
            totalTime = 0;
            timeLeft = 0;
        }
    }
}

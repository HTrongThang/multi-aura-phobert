using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL.Services;
using BLL.Repository;
using System.Configuration;
using System.Collections.Generic;

namespace BLL.DataProviders
{
    public class AuthDataProvider
    {
        private static AuthDataProvider instance;
        private static readonly object padlock = new object();

        public static AuthDataProvider Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AuthDataProvider();
                    }
                    return instance;
                }
            }
        }

        private AppDataProvider appDataProvider = AppDataProvider.Instance;
        private AuthRepository authRepository;
        private AuthService authService;

        private User currentUser = null;
        public User CurrentUser
        {
            get => currentUser;
        }

        public event Action UserLoggedIn;
        public event Action UserLoggedOut;
        public event Action OnRequestReloadApp;

        private AuthDataProvider()
        {
            authRepository = AuthRepository.Instance;
            if (authRepository == null)
            {
                throw new Exception("AuthRepository is not initialized.");
            }

            authService = new AuthService(authRepository);
            if (authService == null)
            {
                throw new Exception("AuthService is not initialized.");
            }
            currentUser = appDataProvider.User;
        }

        public async Task LoginAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                var (user, errorMessage) = await authService.LoginAsync(loginRequest);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    currentUser = user;
                    appDataProvider.User = user;

                    SaveUserConfiguration(user.Token, username);

                    UserLoggedIn?.Invoke();
                }
                else
                {
                    MessageBox.Show($"Login failed: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Logout()
        {
            currentUser = null;
            appDataProvider.User = null;
            ClearUserConfiguration();

            UserLoggedOut?.Invoke();
            //MessageBox.Show("Logged out successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public async Task<(bool, string)> UpdateProfileAsync(string photoPath = "", Dictionary<string, object> changes = null)
        {
            if (changes == null && string.IsNullOrEmpty(photoPath))
            {
                return (false, "No any changes");
            }
            if (appDataProvider.User != null && !string.IsNullOrEmpty(appDataProvider.User.Token))
            {
                var (result, errorMessage) = await authService.UpdateProfileAsync(photoPath, changes);

                if (!result)
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    OnRequestReloadApp?.Invoke();
                }

                return (result, "Update failed");
            }
            return (false, "Update failed");
        }

        private void SaveUserConfiguration(string token, string username)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["UserToken"] != null)
            {
                config.AppSettings.Settings["UserToken"].Value = token;
            }
            else
            {
                config.AppSettings.Settings.Add("UserToken", token);
            }

            if (config.AppSettings.Settings["Username"] != null)
            {
                config.AppSettings.Settings["Username"].Value = username;
            }
            else
            {
                config.AppSettings.Settings.Add("Username", username);
            }

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void ClearUserConfiguration()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings["UserToken"] != null)
            {
                config.AppSettings.Settings["UserToken"].Value = string.Empty;
            }

            if (config.AppSettings.Settings["Username"] != null)
            {
                config.AppSettings.Settings["Username"].Value = string.Empty;
            }

            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}

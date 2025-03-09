using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControl.Extensions
{
    public static class FormExtensions
    {
        private static bool isResizing;
        private static bool isDragging;
        private static Point lastCursor;
        private static Point startPoint;
        private static Rectangle lastFormBounds;
        private static bool isResizingLeft;
        private static bool isResizingRight;
        private static bool isResizingTop;
        private static bool isResizingBottom;

        private static int resizeBorder = 4;

        // Extension method for enabling window dragging
        public static void EnableWindowDrag(this Form form, Control dragControl)
        {
            dragControl.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    startPoint = new Point(e.X, e.Y);
                }
            };

            dragControl.MouseMove += (sender, e) =>
            {
                if (isDragging)
                {
                    Point p = form.PointToScreen(e.Location);
                    form.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            };

            dragControl.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = false;
                }
            };
        }

        // Extension method for enabling window resizing
        public static void EnableWindowResize(this Form form)
        {
            form.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.Location.X < resizeBorder) // Left side
                    {
                        isResizingLeft = true;
                    }
                    else if (e.Location.X > form.Width - resizeBorder) // Right side
                    {
                        isResizingRight = true;
                    }

                    if (e.Location.Y < resizeBorder) // Top side
                    {
                        isResizingTop = true;
                    }
                    else if (e.Location.Y > form.Height - resizeBorder) // Bottom side
                    {
                        isResizingBottom = true;
                    }

                    lastCursor = Cursor.Position;
                    lastFormBounds = form.Bounds;
                    isResizing = true;
                }
            };

            form.MouseMove += (sender, e) =>
            {
                if (isResizing)
                {
                    int deltaX = Cursor.Position.X - lastCursor.X;
                    int deltaY = Cursor.Position.Y - lastCursor.Y;

                    if (isResizingLeft)
                    {
                        int newWidth = form.Width - deltaX;
                        if (newWidth > form.MinimumSize.Width)
                        {
                            form.Width = newWidth;
                            form.Left += deltaX;
                        }
                    }

                    if (isResizingRight)
                    {
                        int newWidth = form.Width + deltaX;
                        if (newWidth > form.MinimumSize.Width)
                        {
                            form.Width = newWidth;
                        }
                    }

                    if (isResizingTop)
                    {
                        int newHeight = form.Height - deltaY;
                        if (newHeight > form.MinimumSize.Height)
                        {
                            form.Height = newHeight;
                            form.Top += deltaY;
                        }
                    }

                    if (isResizingBottom)
                    {
                        int newHeight = form.Height + deltaY;
                        if (newHeight > form.MinimumSize.Height)
                        {
                            form.Height = newHeight;
                        }
                    }

                    lastCursor = Cursor.Position;
                }
                else
                {
                    UpdateCursor(form, e);
                }
            };

            form.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isResizing = false;
                    isResizingLeft = false;
                    isResizingRight = false;
                    isResizingTop = false;
                    isResizingBottom = false;
                }
            };
            form.MouseLeave += (sender, e) =>
            {
                form.Cursor = Cursors.Default;
            };
        }

        public static void EnableWindowControlButtons(
            this Form form,
            Button minimizeButton = null,
            Button maximizeButton = null,
            Button closeButton = null)
        {
            if (minimizeButton != null)
            {
                minimizeButton.Click += async (sender, e) => await MinimizeWindowAsync(form);
            }

            if (maximizeButton != null)
            {
                maximizeButton.Click += async (sender, e) => await MaximizeOrRestoreWindowAsync(form);
            }

            if (closeButton != null)
            {
                closeButton.Click += (sender, e) => form.Close();
            }
        }

        // Private helper methods for window control actions
        private static async Task MinimizeWindowAsync(Form form)
        {
            await TransitionEffectAsync(form);
            form.WindowState = FormWindowState.Minimized;
        }

        private static async Task MaximizeOrRestoreWindowAsync(Form form)
        {
            await TransitionEffectAsync(form);
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        private static async Task TransitionEffectAsync(Form form)
        {
            form.Opacity = 0;
            await Task.Delay(100); // Delay for transition effect
            form.Opacity = 1;
        }

        // Update cursor icon for resizing
        private static void UpdateCursor(Form form, MouseEventArgs e)
        {
            if (e.Location.X < resizeBorder && e.Location.Y < resizeBorder)
            {
                form.Cursor = Cursors.SizeNWSE;
            }
            else if (e.Location.X < resizeBorder && e.Location.Y > form.Height - resizeBorder)
            {
                form.Cursor = Cursors.SizeNESW;
            }
            else if (e.Location.X > form.Width - resizeBorder && e.Location.Y < resizeBorder)
            {
                form.Cursor = Cursors.SizeNESW;
            }
            else if (e.Location.X > form.Width - resizeBorder && e.Location.Y > form.Height - resizeBorder)
            {
                form.Cursor = Cursors.SizeNWSE;
            }
            else if (e.Location.X < resizeBorder)
            {
                form.Cursor = Cursors.SizeWE;
            }
            else if (e.Location.X > form.Width - resizeBorder)
            {
                form.Cursor = Cursors.SizeWE;
            }
            else if (e.Location.Y < resizeBorder)
            {
                form.Cursor = Cursors.SizeNS;
            }
            else if (e.Location.Y > form.Height - resizeBorder)
            {
                form.Cursor = Cursors.SizeNS;
            }
            else
            {
                form.Cursor = Cursors.Default;
            }
        }
    }
}

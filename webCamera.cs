using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace CNC_Assist
{
    public partial class webCamera : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;

        public webCamera()
        {
            InitializeComponent();
        }

        // Enable/disable connection related controls
        private void EnableConnectionControls(bool enable)
        {
            devicesCombo.Enabled = enable;
            videoResolutionsCombo.Enabled = enable;
            connectButton.Enabled = enable;
            disconnectButton.Enabled = !enable;
        }

        private void webCamera_Load(object sender, EventArgs e)
        {
            // enumerate video devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videoDevices.Count != 0)
            {
                // add all devices to combo
                foreach (FilterInfo device in videoDevices)
                {
                    devicesCombo.Items.Add(device.Name);
                }
            }
            else
            {
                devicesCombo.Items.Add("Не найдено ни одной камеры");
            }
            devicesCombo.SelectedIndex = 0;
            EnableConnectionControls(true);
        }

        private void webCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void devicesCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                EnumeratedSupportedFrameSizes(videoDevice);
            }
        }



        // Collect supported video and snapshot sizes
        private void EnumeratedSupportedFrameSizes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            videoResolutionsCombo.Items.Clear();
            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;
                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    videoResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                if (videoCapabilities.Length == 0)
                {
                    videoResolutionsCombo.Items.Add("Not supported");
                }

                videoResolutionsCombo.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[videoResolutionsCombo.SelectedIndex];
                }

                EnableConnectionControls(false);
                videoSourcePlayer1.VideoSource = videoDevice;
                videoSourcePlayer1.Start();
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        // Disconnect from video device
        private void Disconnect()
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
                videoSourcePlayer1.VideoSource = null;

                EnableConnectionControls(true);
            }
        }



        //дорисовка данных на изображение перед выводом
        private void videoSourcePlayer1_Paint(object sender, PaintEventArgs e)
        {

            lock (this)
            {
                Graphics g = e.Graphics;
                Rectangle rect = this.ClientRectangle;
                Pen Pen1 = new Pen(Color.Green, 1);
                Pen Pen2 = new Pen(Color.DarkRed, 1);


                g.DrawLine(Pen1, 320, 0, 320, 480);
                g.DrawLine(Pen2, 0, 240, 640, 240);




                Pen1.Dispose();
                Pen2.Dispose();
            }


        }


        // Преобразования до вывода изображения
        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {

            if (checkBox1.Checked)
            {
                
                //Process each frame
                Bitmap bitmap = (Bitmap)image.Clone();  //Very important - Clone the Bitmap
            
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                image = bitmap;


            }

            if (numericUpDown1.Value > 0)
            {

                //Process each frame
                Bitmap bitmap = (Bitmap)image.Clone();  //Very important - Clone the Bitmap

                image = RotateImageByAngle(bitmap,(float)numericUpDown1.Value);




            }


        }



        /// <summary>
        /// Rotates the image by angle.
        /// </summary>
        /// <param name="oldBitmap">The old bitmap.</param>
        /// <param name="angle">The angle.</param>
        /// <returns></returns>
        private static Bitmap RotateImageByAngle(System.Drawing.Image oldBitmap, float angle)
        {
            var newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)oldBitmap.Width / 2, (float)oldBitmap.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)oldBitmap.Width / 2, -(float)oldBitmap.Height / 2);
            graphics.DrawImage(oldBitmap, new Point(0, 0));
            return newBitmap;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

    }
}

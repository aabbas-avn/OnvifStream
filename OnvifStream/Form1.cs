using OnvifStream.Device;
using OnvifStream.Media;
using OnvifStream.PTZ;
using OnvifStream.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnvifStream
{
    public partial class Form1 : Form
    {
        #region PTZ Initializations Properties
        MediaClient Media;
        Profile[] profiles;
        Profile profile;
        PTZClient PTZ;
        DeviceClient Device;
        PTZ.PTZPreset[] presets;
        PTZConfigurationOptions options;
        PTZ.PTZSpeed velocity;
        PTZ.PTZVector vector;
        PTZ.PTZConfiguration[] configs;
        bool initialised = false, result = false;
        public string IPAddress, User, Pass, Port, _Profiletoken, _Presettoken;
        string[] data;
        string timeout;
        #endregion

        public Form1(string[] args)
        {
            InitializeComponent();
            try
            {
                if (args.Length != 0)
                {
                    data = args[0].ToString().Split(',');
                    IPAddress = data[0];
                    Port = data[1];
                    User = data[2];
                    Pass = data[3];
                    PTZInitialization();
                }

                else
                {
                    PTZInitialization(); //Comment it for production.its only for testing
                }

            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Form1()" + ex);

            }
        }

        #region Mathods

        private void PTZInitialization()
        {
            try
            {
                //Comment this region for production.its only for testing
                #region Test working IP's
                //IPAddress = "10.11.22.32"; //NoPTZ and authentication
                //User = "Admin";
                //Pass = "1234";

                //IPAddress = "10.11.66.31";//no authentication IP

                IPAddress = "10.11.113.54"; //With PTZ and authentication
                User = "service";
                Pass = "IT$rayyan2";
                #endregion

                System.Net.ServicePointManager.Expect100Continue = false;

                Media = OnvifServices.GetOnvifMediaClient(IPAddress, User, Pass);

                PTZ = OnvifServices.GetOnvifPTZClient(IPAddress, User, Pass);

                profiles = Media.GetProfiles();

                profile = Media.GetProfile(profiles[0].token);

                if (profiles[0].PTZConfiguration != null)
                {
                    timeout = profiles[0].PTZConfiguration.DefaultPTZTimeout;
                    
                    configs = PTZ.GetConfigurations();
                    options = PTZ.GetConfigurationOptions(configs[0].token);

                    velocity = new PTZ.PTZSpeed()
                    {
                        PanTilt = new PTZ.Vector2D()
                        {
                            x = 0,
                            y = 0,
                            space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                        },
                        Zoom = new PTZ.Vector1D()
                        {
                            x = 0,
                            space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                        }
                    };
                    vector = new PTZ.PTZVector()
                    {
                        PanTilt = new PTZ.Vector2D()
                        {
                            x = 0,
                            y = 0,
                            space = options.Spaces.RelativePanTiltTranslationSpace[0].URI
                        },
                        Zoom = new PTZ.Vector1D()
                        {
                            x = 0,
                            //space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                        }

                    };
                }
                else
                {
                    panel1.Size = new Size(this.Width, this.Height);
                    groupBox1.Visible = false;
                }
                if (configs != null && configs.Length != 0)
                {
                    presets = PTZ.GetPresets(configs[0].token);
                }
                if (presets != null && presets.Length != 0)
                {
                    _Presettoken = presets[0].token;
                }


                var MediaUri = OnvifServices.GetStreamURI(Media, profiles[0].token);
                var streamUri = MediaUri.Uri.Insert(7, User + ":" + Pass + "@");
                Stream_Player.StartPlay(streamUri);
                textBox1.Text = MediaUri.Uri;
                initialised = true;

            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: PTZInitialization()" + ex);
            }
        }

        public void Zoomin()
        {
            float speed = 0.3F;
            try
            {
                velocity = new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };
                if (initialised)
                {
                    velocity.Zoom.x = speed * options.Spaces.ContinuousZoomVelocitySpace[0].XRange.Max;
                    velocity.Zoom.space = options.Spaces.ContinuousZoomVelocitySpace[0].URI;
                    PTZ.ContinuousMove(profile.token, velocity, timeout);
                }
            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Zoomin()" + ex);
            }
        }

        public void Zoomout()
        {
            float speed = 0.5F;
            try
            {
                velocity = new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };
                if (initialised)
                {

                    velocity.Zoom.x = speed * options.Spaces.ContinuousZoomVelocitySpace[0].XRange.Min;
                    velocity.Zoom.space = options.Spaces.ContinuousZoomVelocitySpace[0].URI;
                    PTZ.ContinuousMove(profile.token, velocity, timeout);
                }

            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Zoomout()" + ex);
            }

        }

        public void PanLeft()
        {
            try
            {
                velocity = new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };

                if (initialised)
                {
                    velocity.PanTilt.x = options.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Min / 5;
                    velocity.PanTilt.y = 0;
                    PTZ.ContinuousMoveAsync(profile.token, velocity, timeout);

                }
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: PanLeft()" + ex);
            }
        }

        public void PanRight()
        {
            try
            {
                velocity = new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };
                if (initialised)
                {
                    velocity.PanTilt.x = options.Spaces.ContinuousPanTiltVelocitySpace[0].XRange.Max / 5;
                    velocity.PanTilt.y = 0;
                    PTZ.ContinuousMoveAsync(profile.token, velocity, timeout);
                }
            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: PanRight()" + ex);
            }
        }

        public void TiltUp()
        {
            try
            {
                velocity = new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };
                if (initialised)
                {
                    velocity.PanTilt.x = 0;
                    velocity.PanTilt.y = options.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Max / 5;
                    PTZ.ContinuousMoveAsync(profile.token, velocity, timeout);
                }
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: TiltUp()" + ex);
            }
        }

        public void TiltDown()
        {
            try
            {
                velocity = new PTZ.PTZSpeed()
                {
                    PanTilt = new PTZ.Vector2D()
                    {
                        x = 0,
                        y = 0,
                        space = options.Spaces.ContinuousPanTiltVelocitySpace[0].URI,
                    },
                    Zoom = new PTZ.Vector1D()
                    {
                        x = 0,
                        space = options.Spaces.ContinuousZoomVelocitySpace[0].URI,
                    }
                };
                if (initialised)
                {
                    velocity.PanTilt.x = 0;
                    velocity.PanTilt.y = options.Spaces.ContinuousPanTiltVelocitySpace[0].YRange.Min / 5;
                    PTZ.ContinuousMoveAsync(profile.token, velocity, timeout);

                }

            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: TiltDown()" + ex);
            }
        }

        public void Stop()
        {
            try
            {
                profile = Media.GetProfile(profile.token);
                PTZ.Stop(profile.token, true, true);
            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Stop()" + ex);
            }
        }
        #endregion 

        #region Events 
        private void Zoom_Out_MouseDown(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Zoomout));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Zoom_Out_MouseDown()" + ex);
            }
        }

        private void Zoom_Out_MouseUp(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Stop));
                thread.Start();
            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Zoom_Out_MouseUp()" + ex);
            }
        }

        private void Zoom_In_MouseDown(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Zoomin));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Zoom_In_MouseDown()" + ex);
            }
        }

        private void Zoom_In_MouseUp(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Stop));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Zoom_In_MouseUp()" + ex);
            }
        }

        private void Down_MouseDown(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(TiltDown));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Down_MouseDown()" + ex);
            }
        }

        private void Down_MouseUp(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Stop));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Down_MouseUp()" + ex);
            }
        }

        private void Right_MouseDown(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(PanRight));
                thread.Start();
            }

            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Right_MouseDown()" + ex);
            }
        }

        private void Right_MouseUp(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Stop));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Right_MouseUp()" + ex);
            }
        }

        private void Left_MouseDown(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(PanLeft));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Left_MouseDown()" + ex);
            }
        }

        private void Left_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Down_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Down_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Left_MouseUp(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Stop));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Left_MouseUp()" + ex);
            }

        }

        private void Up_MouseDown(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(TiltUp));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Up_MouseDown()" + ex);
            }
        }

        private void Up_MouseUp(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(new ThreadStart(Stop));
                thread.Start();
            }
            catch (Exception ex)
            {
                EventLogging.LogEvents("Function: Up_MouseUp()" + ex);
            }

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            PTZ.GotoPreset(profile.token, _Presettoken, velocity);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GitHub_API_GUI
{
    public partial class GithubGUIForm : Form
    {
        public GithubGUIForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTag.Text = getReleaseTag();
            /*try
            {
                Stream streamTry = new FileStream("H:\\latestRelease.dat", System.IO.FileMode.Open, FileAccess.Read);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                Serializer objNew = new Serializer();
                objNew.release = "0.0.0";
                IFormatter formatterNew = new BinaryFormatter();
                Stream streamNew = new FileStream("H:\\latestRelease.dat", System.IO.FileMode.Create, FileAccess.Write);

                formatterNew.Serialize(streamNew, objNew);
                streamNew.Close();

            } 

            Stream stream = new FileStream("H:\\latestRelease.dat", System.IO.FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            Serializer obj = (Serializer)formatter.Deserialize(stream);
            
            if (!obj.release.Equals(getReleaseTag()))
            {
                MessageBox.Show("New Atmosphere release available!");
            }

        */    
        }

        //Minimize to Tray

        /*
        void ImportStatusForm_Resize(object sender, EventArgs e)
        {
            notifyIcon.Icon = ((System.Drawing.Icon)(System.Resources.ResourceManager.GetObject("notifyIcon.Icon")));
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }
        */

        static string getReleaseTag()
        {
            var client = new GitHubClient(new ProductHeaderValue("Insert Client Name Here"));
            var tokenAuth = new Credentials("Enter Auth Token Here");
            client.Credentials = tokenAuth;
            var user = client.User.Get("Atmosphere-NX").Result;
            var apiInfo = client.GetLastApiInfo();
            //txtUsername.Text = user.Name;
            var releases = client.Repository.Release.GetLatest("Atmosphere-NX", "Atmosphere").Result;

            return releases.TagName;
        }
       
        
        
        /*
        static void SaveReleaseTag(Release releases)
        {
            Serializer obj = new Serializer();
            obj.release = releases.TagName;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("H:\\latestRelease.dat", System.IO.FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, obj);
            stream.Close();
        }

        public class Serializer
        {
            public string release;
        }
        */
    }
}

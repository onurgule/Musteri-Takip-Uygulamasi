using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;

namespace MusteriTakipProjesi
{
    public partial class frmCamera : Form
    {
        public Form gelenform = null;
        public frmCamera()
        {
            InitializeComponent();
        }
        VideoCaptureDevice FinalFrame;
        FilterInfoCollection videosources;
        private void frmCamera_Load(object sender, EventArgs e)
        { 
            videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (var cam in videosources)
            {
               cbKameralar.Items.Add((cam as FilterInfo).Name);
            }
            cbKameralar.SelectedIndex = 0; // default
            FinalFrame = new VideoCaptureDevice();
            btnKameraSec_Click(sender, e);
            
        }
        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs) // must be void so that it can be accessed everywhere.
        // New Frame Event Args is an constructor of a class
        {
            pbGoruntu.Image = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
        }
        private void frmCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
        }

        private void cbKameralar_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnKameraSec_Click(object sender, EventArgs e)
        {
            if (FinalFrame.IsRunning == true) 
                FinalFrame.Stop();
            FinalFrame = new VideoCaptureDevice(videosources[cbKameralar.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
            FinalFrame.Start();
        }

        private void btnResimCek_Click(object sender, EventArgs e)
        {
            if (pbGoruntu.Image != null)
            {
                //Save First
                Bitmap varBmp = new Bitmap(pbGoruntu.Image);
                Bitmap newBitmap = new Bitmap(varBmp);
                //Now Dispose to free the memory
                if (gelenform.Name == "frmMusteriEkle")
                {
                    frmMusteriEkle f1 = (frmMusteriEkle)Application.OpenForms["frmMusteriEkle"];
                    f1.Resmet(newBitmap);
                }
                else if (gelenform.Name == "frmMusteriKarti")
                {
                    frmMusteriKarti f1 = (frmMusteriKarti)Application.OpenForms["frmMusteriKarti"];
                    f1.Resmet(newBitmap);
                }
                varBmp.Dispose();
                varBmp = null;
               if (FinalFrame.IsRunning == true) FinalFrame.Stop();
                this.Close();
            }
        }

    }
}

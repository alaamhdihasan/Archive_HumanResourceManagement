using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using System.IO;

namespace MechanismsCD.FRMS
{
    public partial class FRMSignature : DevExpress.XtraEditors.XtraForm
    {
        string path;
        public FRMSignature(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void picSin_Click(object sender, EventArgs e)
        {

        }

        private void FRMSignature_Load(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.Treeandthatyia archSin = new CLS_FRMS.Treeandthatyia();
                archSin.thatyia2selectbylistview(path, archtb1, archtb2, archtb3, archtb4,
                archtb5, archtb6, archtb7, archtb8, archtb9, pn);
                
                picSin.Image = new Bitmap(path);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {

                string nameimage = System.IO.Path.GetFileName(archtb6.Text);
                Random x = new Random();
                string newpath = Properties.Settings.Default.PathOfArchieves + x.Next().ToString() + Path.GetExtension(nameimage);
                int width = panelSin.Size.Width;
                int height = panelSin.Size.Height;

                Bitmap bm = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(bm);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //Rectangle rect = panelSin.RectangleToScreen(panelSin.ClientRectangle);
                //g.CopyFromScreen(rect.Location, Point.Empty, panelSin.Size);
                panelSin.DrawToBitmap(bm, panelSin.ClientRectangle);

                g.DrawImage(bm, 0, 0, 3508, 2480);
                //Bitmap panelImage = new Bitmap(Width, Height);

                //Graphics g = Graphics.FromImage((Image)panelImage);
                //g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                //panelSin.DrawToBitmap(panelImage, panelSin.ClientRectangle);

                //g.DrawImage(panelImage, 0, 0, panelSin.Width, panelSin.Height);
                //g.Dispose();

                picSin.Image = bm;
                bm.Save(newpath);


                archtb6.Text = newpath;


                archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");

                CLS_FRMS.Treeandthatyia archSin = new CLS_FRMS.Treeandthatyia();
                archSin.Thatyia2Update(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                    archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text, int.Parse(archtb1.Text));


                MessageBox.Show("تم الحفظ");
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        float PointX = 0;
        float PointY = 0;
        float LastX = 0;
        float LastY = 0;
        private void picSin_MouseDown(object sender, MouseEventArgs e)
        {
            LastX = e.X;
            LastY = e.Y;
        }

        private void picSin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointX = e.X;
                PointY = e.Y;
                picSin_Paint(this, null);
            }
        }
        Pen blackPen;
        private void picSin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = picSin.CreateGraphics();
            blackPen = new Pen(colorPenEdit.Color, int.Parse(numPenSize.Value.ToString()));
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawLine(blackPen, PointX, PointY, LastX, LastY);
            //g.DrawLine(blackPen, 0, 0, 12, 8);
            LastX = PointX;
            LastY = PointY;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picSin.Image);
            bm.RotateFlip(RotateFlipType.Rotate90FlipXY);
            picSin.Image = bm;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(picSin.Image);
            bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
            picSin.Image = bm;
        }

        private void colorPenEdit_EditValueChanged(object sender, EventArgs e)
        { 
        }

        private void numPenSize_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
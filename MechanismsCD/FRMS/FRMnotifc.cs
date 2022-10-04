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
using DevExpress.Skins;
using DevExpress.Utils.Design;
using DevExpress.DataAccess.UI.Native;

namespace MechanismsCD.FRMS
{
    public partial class FRMnotifc : DevExpress.XtraEditors.XtraForm
    {
        MAINFRM frm1;  
        public FRMnotifc(List<Tuple<string,int>> notifclist,MAINFRM frm1)
        {
            InitializeComponent();
            adddata( notifclist);
            this.frm1 = frm1;

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void windowsUIButtonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void adddata(List<Tuple<string,int>> notifclist)
        {
            foreach (var text in notifclist)
            {
                SimpleButton btn = new SimpleButton();
                btn.Font = new Font("JF Flat", 10, FontStyle.Bold);
                btn.Dock = DockStyle.Top;
                btn.ForeColor = Color.Black;
                btn.Appearance.BackColor = Color.Transparent;
                btn.AppearanceHovered.BackColor = Color.DodgerBlue;
                int x = 0;
                char[] buffer = text.Item1.ToCharArray();
                for (int i = 0; i < buffer.Length; i++)
                {
                    btn.Text += buffer[i];
                    if (x >= 20 && buffer[i] == ' ')
                    {
                        btn.Text += "\n\r";
                        x = 0;
                    }
                    x++;

                }
                btn.AutoSize = true;
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
                btn.ImageOptions.Image = Properties.Resources.reminder_32x32;
                panel1.Controls.Add(btn);

                if (text.Item2 == 1)
                {
                    btn.Click += (sender, args) =>
                    {
                        Label x1 = new Label();
                        x1.Text = "المنتسبين";
                        string name = null;
                        char[] a = text.Item1.ToCharArray();
                        for(int i = 1; i < a.Length; i++)
                        {
                            if (a[i] == ')')
                                break;
                            name += a[i].ToString();
                        }
                        FRMEMPLOYEES f = new FRMEMPLOYEES(x1,name);
                        f.ShowDialog();
                        this.Close();
                    };
                }
                else if (text.Item2 == 2)
                {
                    btn.Click += (sender, args) =>
                    {
                        string name = null;
                        char[] a = text.Item1.ToCharArray();
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i] == '(')
                                break;
                            name += a[i].ToString();
                        }
                        
                        Guidthatyia frm = new Guidthatyia(name,frm1);
                        frm.Show();
                        this.Close();
                    };
                }
                else if (text.Item2 == 3)
                {
                    btn.Click += (sender, args) =>
                    {
                        string name = null;
                        string num = null;
                        char[] a = text.Item1.ToCharArray();
                        int i = 0;
                        for (i = 3; i < a.Length; i++)
                        {
                            if (a[i-1] == ' ' && a[i-2]=='ن' && a[i - 3] == 'م')
                                break;
                            if (a[i] >= '0' && a[i] <= '9')
                            {
                                num += (int)a[i]-'0';
                            }
                        }
                        for (int j = i; j < a.Length; j++)
                        {
                            name += a[j].ToString();
                        }
                        
                        FRMBookReciveInternal frm = new FRMBookReciveInternal(name, num);
                        frm.Show();
                        this.Close();
                    };
                }
            }
        }
    }
}
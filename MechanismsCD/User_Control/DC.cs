using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.User_Control
{
    public partial class DC : UserControl
    {
        public DC()
        {
            InitializeComponent();
        }

        private void DC_Load(object sender, EventArgs e)
        {

        

        }

        #region Properties
        private int _Vlbone;
        private int _VlbTwo;
        private int _VlbThree;
        private int _VlbFour;
        

        [Category("Custome Value")]
        public int VlbOne
        {
            get { return _Vlbone; }
            set { _Vlbone = value; lbOne.Text= value.ToString(); }
        }
        [Category("Custome Value")]
        public int VlTwo
        {
            get { return _VlbTwo; }
            set { _VlbTwo = value;lbTwo.Text = value.ToString(); }
        }
        [Category("Custome Value")]
        public int VlbThree
        {
            get { return _VlbThree; }
            set { _VlbThree = value;lbThree.Text = value.ToString(); }
        }
        [Category("Custome Value")]
        public int VlbFour
        {
            get { return _VlbFour; }
            set { _VlbFour = value; lbFour.Text = value.ToString(); }
        }

    
        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiemDanhChoGV
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            them();
        }

        void them()
        {
            for (int i = 0; i < 20; i++)
            {
                lvDanhSachLop.Items.Add(new ListViewItem(i.ToString()));

            }
        }
    }
}

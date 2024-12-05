using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MLMS.addMemberForm;

namespace MLMS
{
    public partial class AdminMainDashBoard : Form
    {
        public AdminMainDashBoard()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddBook D = new AddBook();
            D.Show();
            this.Hide();
        }

        private void memberButton_Click(object sender, EventArgs e)
        {
            addMemberForm D = new addMemberForm(FormType.AdminMainDashBoard);
            D.Show();
            this.Hide();
        }

        private void reserveButton_Click(object sender, EventArgs e)
        {
            ViewReserve VR = new ViewReserve();
            VR.Show();
            this.Hide();
        }
    }
}

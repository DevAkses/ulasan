using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ulasan
{
    public partial class Form3 : Form
    {
        private Form1.User user;
        public Form3(Form1.User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}

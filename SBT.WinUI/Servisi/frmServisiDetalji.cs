using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBT.WinUI.Servisi
{
    public partial class frmServisiDetalji : Form
    {
        private int? _id = null;
        private readonly APIService _service = new APIService("Servisi");
        public frmServisiDetalji(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private void frmServisiDetalji_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace INCUserver
{
    public partial class frm_PassWord : Form
    {
        /// <summary>
        /// √‹¬Î
        /// </summary>
        public string Password
        {
            get { return txt_PassWord.Text; }
        }

        public frm_PassWord()
        {
            InitializeComponent();
            txt_PassWord.Focus();
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
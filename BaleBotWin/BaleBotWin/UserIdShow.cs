using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaleBotWin.Model;

namespace BaleBotWin
{
    public partial class UserIdShow : Form
    {
        public Peer UserInfo { get; private set; }

        public UserIdShow(Peer info)
        {
            InitializeComponent();
            txtHash.Text = info.accessHash;
            txtUserId.Text = info.id;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserId.Text) || string.IsNullOrEmpty(txtHash.Text))
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            UserInfo = new Peer()
            {
                type = "User",
                id = txtUserId.Text,
                accessHash = txtHash.Text
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

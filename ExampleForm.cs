using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winforms_chat
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();

            var chatPanel = new ChatForm.ChatPanel();
            chatPanel.Name = "chatPanel";
            chatPanel.Dock = DockStyle.Fill;
            this.Controls.Add(chatPanel);
        }

    }
}

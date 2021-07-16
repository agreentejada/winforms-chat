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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ChatForm.ChatboxInfo cbi = new ChatForm.ChatboxInfo();
			cbi.NamePlaceholder = "testing";
			cbi.PhonePlaceholder = "(111) 222-3333";

			var chat_panel = new ChatForm.Chatbox(cbi);
			chat_panel.Name = "chat_panel";
			chat_panel.Dock = DockStyle.Fill;
			this.Controls.Add(chat_panel);
		}
	}
}


namespace winforms_chat.ChatForm
{
	partial class ChatItem
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.authorPanel = new System.Windows.Forms.Panel();
			this.authorLabel = new System.Windows.Forms.Label();
			this.bodyPanel = new System.Windows.Forms.Panel();
			this.bodyTextBox = new System.Windows.Forms.TextBox();
			this.authorPanel.SuspendLayout();
			this.bodyPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// authorPanel
			// 
			this.authorPanel.Controls.Add(this.authorLabel);
			this.authorPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.authorPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.authorPanel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.authorPanel.Location = new System.Drawing.Point(12, 52);
			this.authorPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.authorPanel.Name = "authorPanel";
			this.authorPanel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.authorPanel.Size = new System.Drawing.Size(683, 30);
			this.authorPanel.TabIndex = 8;
			// 
			// authorLabel
			// 
			this.authorLabel.AutoSize = true;
			this.authorLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.authorLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.authorLabel.Location = new System.Drawing.Point(0, 6);
			this.authorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.authorLabel.Name = "authorLabel";
			this.authorLabel.Size = new System.Drawing.Size(110, 13);
			this.authorLabel.TabIndex = 0;
			this.authorLabel.Text = "System - 10/22/2020";
			// 
			// bodyPanel
			// 
			this.bodyPanel.BackColor = System.Drawing.Color.RoyalBlue;
			this.bodyPanel.Controls.Add(this.bodyTextBox);
			this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.bodyPanel.Location = new System.Drawing.Point(12, 6);
			this.bodyPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.bodyPanel.Name = "bodyPanel";
			this.bodyPanel.Padding = new System.Windows.Forms.Padding(2);
			this.bodyPanel.Size = new System.Drawing.Size(424, 46);
			this.bodyPanel.TabIndex = 9;
			// 
			// bodyTextBox
			// 
			this.bodyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bodyTextBox.BackColor = System.Drawing.Color.RoyalBlue;
			this.bodyTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.bodyTextBox.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.bodyTextBox.ForeColor = System.Drawing.Color.White;
			this.bodyTextBox.Location = new System.Drawing.Point(6, 6);
			this.bodyTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.bodyTextBox.Multiline = true;
			this.bodyTextBox.Name = "bodyTextBox";
			this.bodyTextBox.ReadOnly = true;
			this.bodyTextBox.Size = new System.Drawing.Size(412, 35);
			this.bodyTextBox.TabIndex = 4;
			this.bodyTextBox.Text = "Hello there. This is a test for the longer word usage.";
			// 
			// ChatItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.Controls.Add(this.bodyPanel);
			this.Controls.Add(this.authorPanel);
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.Name = "ChatItem";
			this.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
			this.Size = new System.Drawing.Size(707, 88);
			this.Load += new System.EventHandler(this.ChatItem_Load);
			this.authorPanel.ResumeLayout(false);
			this.authorPanel.PerformLayout();
			this.bodyPanel.ResumeLayout(false);
			this.bodyPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel authorPanel;
		private System.Windows.Forms.Label authorLabel;
		private System.Windows.Forms.Panel bodyPanel;
		private System.Windows.Forms.TextBox bodyTextBox;
	}
}

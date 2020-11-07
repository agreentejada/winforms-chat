using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ChatForm
{
    //VS Designer can't handle more than two partial classes. This one was intentionally created so that when you are developing the interface, you replace this
    //partial class with actual parameters.
    public partial class ChatPanel : UserControl
    {
        string user = "Mrs. Coolio";
        string nameplaceholder = "Client Name";
        string phoneplaceholder = "(111) 222-3333";
        string statusplaceholder = string.Empty;
        string chatplaceholder = "Please enter a message...";
        byte[] attachment = null;
        string attachmentname = null;
        string attachmenttype = null;
        OpenFileDialog fileDialog = new OpenFileDialog();
        string initialdirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    }

    public partial class ChatPanel : UserControl
    { 
        public ChatPanel()
        {
            InitializeComponent();
            clientnameLabel.Text = nameplaceholder;
            statusLabel.Text = statusplaceholder;
            phoneLabel.Text = phoneplaceholder;
            chatTextbox.Text = chatplaceholder;

            chatTextbox.Enter += ChatEnter;
            chatTextbox.Leave += ChatLeave;
            sendButton.Click += SendMessage;
            attachButton.Click += BuildAttachment;
            removeButton.Click += CancelAttachment;

            chatTextbox.KeyDown += OnEnter;

            AddMessage(null);
        }

        /// <summary>
        /// ChatItem objects are generated dynamically from IChatModel. By default, a ChatItem is allowed to be resized up to 60% of the entire screen.
        /// I've thought about it being editable from outside, but there's no real need to.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(IChatModel message)
        {
            var chatItem = new ChatItem(message);
            chatItem.Name = "chatItem" + itemsPanel.Controls.Count;
            chatItem.Dock = DockStyle.Top;
            itemsPanel.Controls.Add(chatItem);
            chatItem.BringToFront();

            chatItem.ResizeBubbles((int)(itemsPanel.Width * 0.6));

            itemsPanel.ScrollControlIntoView(chatItem);
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(chatTextbox.Text))
            {
                chatTextbox.Text = chatplaceholder;
                chatTextbox.ForeColor = Color.Gray;
            }
        }

        //Improves the chat UI slightly by having a placeholder text. Note that this is implemented because Winforms doesn't have a native "placeholder" UI. Can be buggy.
        void ChatEnter(object sender, EventArgs e)
        {
            chatTextbox.ForeColor = Color.Black;
            if (chatTextbox.Text == chatplaceholder)
            {
                chatTextbox.Text = "";
            }
        }

        //Cross-tested this with the Twilio API and the RingCentral API, and async messaging is the way to go.
        async void SendMessage(object sender, EventArgs e)
        {
            string tonumber = phoneLabel.Text;
            string chatmessage = chatTextbox.Text;

            IChatModel chatModel = null;
            TextChatModel textModel = null;

            //Each IChatModel is specifically built for a single purpose. For that reason, if you want to display a text item AND and image, you'd make two IChatModels for
            //their respective purposes. AttachmentChatModel and ImageChatModel, however, can really be used interchangeably.
            if (attachment != null && attachmenttype.Contains("image"))
            {
                chatModel = new ImageChatModel()
                {
                    Author = user,
                    Image = Image.FromStream(new MemoryStream(attachment)),
                    ImageName = attachmentname,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now,
                };

            }
            else if (attachment != null)
            {
                chatModel = new AttachmentChatModel()
                {
                    Author = user,
                    Attachment = attachment,
                    Filename = attachmentname,
                    Read = true,
                    Inbound = false,
                    Time = DateTime.Now
                };
            }

            if (!string.IsNullOrWhiteSpace(chatmessage) && chatmessage != chatplaceholder)
            {
                textModel = new TextChatModel()
                {
                    Author = user,
                    Body = chatmessage,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
            }

            try
            {
                /*

                    INSERT SENDING LOGIC HERE. Again, this is just a UserControl, not a complete app. For the Ringcentral API, I was able to reduce this section
                    down to a single method.

                */

                if (chatModel != null)
                {
                    AddMessage(chatModel);
                    CancelAttachment(null, null);
                }
                if (textModel != null)
                {
                    AddMessage(textModel);
                    chatTextbox.Text = string.Empty;
                }
            }
            catch (Exception exc)
            {
                //If any exception is found, then it is printed on the screen. Feel free to change this method if you don't want people to see exceptions.
                textModel = new TextChatModel()
                {
                    Author = user,
                    Body = "The message could not be processed. Please see the reason below.\r\n" + exc.Message,
                    Inbound = false,
                    Read = true,
                    Time = DateTime.Now
                };
                AddMessage(textModel);
            }  
        }

        void BuildAttachment(object sender, EventArgs e)
        {
            fileDialog.InitialDirectory = initialdirectory;
            fileDialog.Reset();
            fileDialog.Multiselect = false;

            var result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selected = fileDialog.FileName;
                try
                {
                    var file = File.ReadAllBytes(selected);
                    //Limits the size of the attachment to 1.45 MB, which is less than the max possible size of an SMS attachment of 1.5 MB.
                    if (file.Length > 1450000)
                    {
                        MessageBox.Show("The attachment provided " + fileDialog.SafeFileName + " is too big to be sent by SMS. Please select another.", "Attachment not added.");
                        return;
                    }
                    else
                    {
                        attachment = file;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("There was an issue with retrieving the file.", "File Operation Error");
                }
            }
            else
            {
                return;
            }

            if (attachment != null)
            {
                string smallname = fileDialog.SafeFileName;
                attachmentname = fileDialog.SafeFileName;

                string name = Path.GetFileNameWithoutExtension(smallname);
                string extension = Path.GetExtension(smallname);
                if (smallname.Length > 12)
                {
                    smallname = name.Substring(0, 7) + ".." + extension;
                    attachButton.Text = smallname;
                }
                else
                {
                    attachButton.Text = smallname;
                }

                removeButton.Visible = true;
                attachButton.Width = 115;
                attachmenttype = ChatUtility.GetMimeType(extension);
            }
        }

        void CancelAttachment(object sender, EventArgs e)
        {
            attachButton.Text = string.Empty;
            attachment = null;
            attachmentname = null;
            attachmenttype = null;
            removeButton.Visible = false;
            attachButton.Width = 35;
        }

        //Inspired from Slack, you can also press Shift + Enter to enter text.
        async void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyValue == 13)
            {
                SendMessage(this, null);
            }
        }

        //When the Control resizes, it will trigger the resize event for all the ChatItem object inside as well, again with a default width of 60%.
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            foreach (var control in itemsPanel.Controls)
            {
                if (control is ChatItem)
                {
                    (control as ChatItem).ResizeBubbles((int)(itemsPanel.Width * 0.6));
                }
            }
        }
    }
}
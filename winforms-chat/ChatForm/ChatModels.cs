using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winforms_chat.ChatForm
{
    public interface IChatModel
    {
        bool Inbound { get; set; }
        bool Read { get; set; }
        DateTime Time { get; set; }
        string Author { get; set; }
        string Type { get; }
    }

    public class TextChatModel : IChatModel
    {
        public bool Inbound { get; set; }
        public bool Read { get; set; }
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public string Type { get; } = "text";

        public string Body { get; set; }
    }

    public class ImageChatModel : IChatModel
    {
        public bool Inbound { get; set; }
        public bool Read { get; set; }
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public string Type { get; } = "image";

        public Image Image { get; set; }
        public string ImageName { get; set; }
    }

    public class AttachmentChatModel : IChatModel
    {
        public bool Inbound { get; set; }
        public bool Read { get; set; }
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public string Type { get; } = "attachment";

        public byte[] Attachment { get; set; }
        public string Filename { get; set; }
    }
}

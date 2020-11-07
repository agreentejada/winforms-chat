# winforms-chat
This is a simplified, modern WinForm chat control intended for general use across any API or SDK you need.

# Why did you build this?
Due to a variety of technical reasons, I was working on a desktop application that had been recently upgraded to .NET Core and had a pure base of Windows Forms. I wanted to create a lightweight SMS chat within the application; but couldn't find a single free library that was easy to use. Hence this repo.

# What's in it?
winforms-chat is a bare-bones UserControl that consists of two objects: a ChatPanel and a ChatItem. The ChatPanel has most of the basic controls of a chat platform: it let's you type messages, attach files, and separates files and images up to 1.45 MB. It also clears up messy text and allows for the typical SHIFT + ENTER combo.

ChatItem is the main reason this was built. ChatItem is a rectangular panel that auto - resizes on both text and image.

![](winchat-demo.gif)

ChatItem overrides the OnResize method based on a minimum ratio set by the user, and automatically deals with word-wrapping text so you don't have to. ChatItem also auto-resizes images so that they don't look like malformed spagetthi when put into the client.


# How do I do anything with this control?
ChatModels.cs contains the IChatModel interface. In lieu of using different UserControls to represent different items, IChatModel can be used in different classes to intialize different kinds of ChatItem objects. It is intended for extensibility, and I'm hoping to add video in later versions.

## Why not use chat bubbles?
Didn't feel Windows-y enough.

## Why so much blue?
RoyalBlue was the first color I found.

For adding in other API methods or if you just don't like the look, you can fork this project over to your repo, then work on it. This is not intended to be a full client, but rather a start for struggling WinForms developers who don't want to pay full price for Telerik UI, or deal with some over-engineered drivel.

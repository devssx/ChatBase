<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Chatbase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>
    <link href="css/styles.css" rel="stylesheet" />
    <script src="scripts/script.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="chat-window" id="chatWindow">
            <div class="chat-header">
                <img id="chatIcon" width="35" height="35"
                    src="https://www.chatbase.co/_next/image?url=https%3A%2F%2Fbackend.chatbase.co%2Fstorage%2Fv1%2Fobject%2Fpublic%2Fchatbots-profile-pictures%2F7ba1da4d-e947-4cce-9e5a-85ec139ecac6%2FPyy_eZYqu_fKH-gkhICfc.jpg%3Fwidth%3D35%26quality%3D50&w=48&q=75&dpl=dpl_8Vboo7iLBUsnfmfHGx2Nf6xLya9S"
                    style="color: transparent;">
                <h3 id="chatTitle">Innova</h3>
                <span class="close-btn" onclick="toggleChat()">×</span>
            </div>

            <div class="chat-body" id="chatBody">

                <!-- Los mensajes del chat se agregarán aquí -->
                <div class="conversation-start">
                    <span>Today, 5:38 PM</span>
                </div>

                <!-- messages -->
                <div class="bubble you">
                    Hello, can you hear me?
                </div>
                <div class="bubble you">
                    I'm in California dreaming
                </div>

                <div class="bubble me">
                    ... about who we used to be.about who we used to be.about who we used to be.about who we used to
				be.about who we used to be.about who we used to be.about who we used to be.
                </div>
            </div>

            <div class="write">
                <span id="chatAttachmentBtn" class="write-link attach"></span>
                <input id="chatInput" type="text" />
                <span id="chatEmojiBtn" class="write-link smiley"></span>
                <span id="chatSendMessageBtn" class="write-link send"></span>
            </div>
        </div>

        <span class="chat-toggle-btn" id="chatToggleBtn" onclick="toggleChat()">
            <img src="images/icon.svg" width="30" />
        </span>
    </form>
</body>
</html>

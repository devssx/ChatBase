function toggleChat() {
    const chatWindow = document.getElementById('chatWindow');
    const chatToggleBtn = document.getElementById('chatToggleBtn');

    if (chatWindow.style.display === 'none' || chatWindow.style.display === '') {
        chatWindow.style.display = 'flex';
        chatToggleBtn.style.display = 'none';
    } else {
        chatWindow.style.display = 'none';
        chatToggleBtn.style.display = 'block';
    }
}



document.addEventListener('DOMContentLoaded', () => {
    toggleChat(); // Mostrar el botón de chat al cargar la página
});

onload = function () {
    document.querySelector('.chat-body').classList.add('active-chat');

    document.getElementById('chatAttachmentBtn').onclick = selectFile;
    document.getElementById('chatEmojiBtn').onclick = selectEmoji;
    document.getElementById('chatSendMessageBtn').onclick = sendMessage;

    document.getElementById('chatInput').onkeydown = function (event) {
        if (event.code == 'Enter' || event.code == 'NumpadEnter')
            sendMessage();
    };
}

function selectFile() {
    alert('Attachment')
}

function selectEmoji() {
    alert('Emoji')
}

function sendMessage() {
    const chatInput = document.getElementById('chatInput');
    const chatBody = document.getElementById('chatBody');
    const message = chatInput.value.trim();

    if (message !== '') {
        const messageElement = document.createElement('div');
        messageElement.textContent = message;
        messageElement.className = "bubble me";

        chatBody.appendChild(messageElement);
        chatInput.value = '';
        chatBody.scrollTop = chatBody.scrollHeight;
    }
}

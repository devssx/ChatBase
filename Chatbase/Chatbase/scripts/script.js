function post(url, data, success) {
    $.ajax({
        type: 'POST',
        url: url,
        data: data,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.error("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        },
        success: function (response) {
            success(JSON.parse(response.d));
        }
    });
}

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

        if (event.code == 'Enter' || event.code == 'NumpadEnter') {
            sendMessage();
            return false;
        }
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
    const message = chatInput.value.trim();

    if (message !== '') {

        // clear
        chatInput.value = '';
        addMessage(message, 'user');

        post('Default.aspx/SendMessage', JSON.stringify({ message: message }), (resp) => {
            addMessage(resp, 'bot');
        });
    }
}

function addMessage(message, role) {
    if (message !== '') {
        const chat = document.getElementById('chatBody');

        const messageElement = document.createElement('div');
        messageElement.textContent = message;
        messageElement.className = role == 'user' ? 'bubble me' : 'bubble you';

        chat.appendChild(messageElement);
        chat.scrollTop = chat.scrollHeight;
    }
}

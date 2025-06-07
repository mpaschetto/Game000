"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/Game000/chatHub").build();

let userName = "";

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    connection.invoke("JoinRoom", roomId);
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("joinButton").addEventListener("click", function (event) {
    const nameInput = document.getElementById("userInput");
    const name = nameInput.value.trim();
    if (name !== "") {
        userName = name;
        document.getElementById("usernameForm").style.display = "none";
        const chatArea = document.getElementById("chatArea");
        chatArea.style.display = "flex";
        document.getElementById("sendButton").disabled = false;
        document.getElementById("messageInput").focus();
    }
    event.preventDefault();
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    const message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", roomId, userName, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";
    event.preventDefault();
});

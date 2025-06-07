"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/Game000/chatHub").build();

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

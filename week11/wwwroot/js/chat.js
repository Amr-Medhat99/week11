var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

document.getElementById("btnSendMessage").disabled = true;

connection.on("RecieveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");    
    var encodeMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodeMsg;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("btnSendMessage").disabled = false;
}).catch(function (err) {
    return console.error(err.tostring());
});

document.getElementById("btnSendMessage").addEventListener("click", function (event) {
    var user = document.getElementById("UserInput").value;
    var messgae = document.getElementById("MessageInput").value;
    connection.invoke("sendMessage", user, messgae).catch(function (err) {
        return console.error(err.tostring());
    });
    event.preventDefault();
});
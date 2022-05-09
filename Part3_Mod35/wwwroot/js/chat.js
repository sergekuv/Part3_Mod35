//"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

////Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you 
//    // should be aware of possible script injection concerns.
//    li.textContent = `${user} says ${message}`;
//});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});

"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (fromUser, toUser, message) {

    var currentUser = document.getElementById("ModelYouId").innerHTML;
    var chatWith = document.getElementById("ModelToWhomId").innerHTML;
    //console.log("currentUser:" + currentUser);
    //console.log("chatWith:" + chatWith);

    if (fromUser == chatWith && toUser == currentUser) {
        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        // We can assign user-supplied strings to an element's textContent because it
        // is not interpreted as markup. If you're assigning in any other way, you 
        // should be aware of possible script injection concerns.
        li.textContent = `${message}`;
    }
});

connection.start().then(function () {
    document.getElementById("sendButton1").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton1").addEventListener("click", function (event) {
    //debugger;
    var fromUser = document.getElementById("ModelYouId").innerHTML;
    var toUser = document.getElementById("ModelToWhomId").innerHTML;
    var message = document.getElementById("msgText").value;
    if (message != "") {
        connection.invoke("SendMessage", fromUser, toUser, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
    //event.preventDefault();
});
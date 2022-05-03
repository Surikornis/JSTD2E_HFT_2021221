let games = [];
let connection = null;

let gameIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:62282/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GameDeleted", (user, message) => {
        getdata();
    });

    connection.on("GameCreated", (user, message) => {
        getdata();
    });

    connection.on("GameUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    fetch('http://localhost:62282/game')
        .then(x => x.json())
        .then(y => {
            games = y;
            //console.log(games);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    games.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td ><td>" + t.gameName + "</td><td>"
            + t.type + "</td><td>" + t.price + "</td><td>" + t.buyerId + "</td><td>"
            + t.devTeamId + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>`
            + `<button type="button" onclick="showupdate(${t.id})">Update</button>` + "</td></tr>" + "</td></tr>";
        //console.log(t.gameName);
    });
}

function remove(id) {
    fetch('http://localhost:62282/game/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Delete Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById("gamenametoupdate").value = games.find(t => t['id'] == id)['gameName'];
    document.getElementById("gametypetoupdate").value = games.find(t => t['id'] == id)['type'];
    document.getElementById("gamepricetoupdate").value = games.find(t => t['id'] == id)['price'];
    document.getElementById("buyeridtoupdate").value = games.find(t => t['id'] == id)['buyerId'];
    document.getElementById("devteamidtoupdate").value = games.find(t => t['id'] == id)['devTeamId'];
    document.getElementById("updateformdiv").style.display = "flex";
    gameIdToUpdate = id;
}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let gname = document.getElementById('gamenametoupdate').value;
    let gtype = document.getElementById('gametypetoupdate').value;
    let gprice = document.getElementById('gamepricetoupdate').value;
    let buyid = document.getElementById('buyeridtoupdate').value;
    let devid = document.getElementById('devteamidtoupdate').value;

    fetch('http://localhost:62282/game', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                Id: gameIdToUpdate,
                gameName: gname,
                type: gtype,
                price: gprice,
                buyerId: buyid,
                devTeamId: devid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Create Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function create() {
    let gname = document.getElementById('gamename').value;
    let gtype = document.getElementById('gametype').value;
    let gprice = document.getElementById('gameprice').value;
    let buyid = document.getElementById('buyerid').value;
    let devid = document.getElementById('devteamid').value;

    fetch('http://localhost:62282/game', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                gameName: gname,
                type: gtype,
                price: gprice,
                buyerId: buyid,
                devTeamId: devid
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Create Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
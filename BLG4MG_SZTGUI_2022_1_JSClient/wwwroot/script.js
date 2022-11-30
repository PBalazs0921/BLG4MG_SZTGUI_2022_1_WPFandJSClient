let cars = [];
let connection = null;
let CarIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:61417/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CarCreated", (user, message) => {
        getdata();
    });

    connection.on("CarDeleted", (user, message) => {
        getdata();
    });

    connection.on("CarUpdated", (user, message) => {
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
    await fetch('http://localhost:61417/car')
        .then(x => x.json())
        .then(y => {
            cars = y;
            console.log(cars);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    cars.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>"
            + t.id + "</td><td>"
            + t.model + "</td><td>"
            + t.brandId + "</td><td>"
            + `<button type="button" onclick="remove(${t.id})">Delete</button> ` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button> ` + "</td></tr>";

    });
}

function showupdate(id) {
    document.getElementById('idToUpdate').value = cars.find(t => t['id'] == id)['id'];
    document.getElementById('modelToUpdate').value = cars.find(t => t['id'] == id)['model'];
    document.getElementById('brandIDToUpdate').value = cars.find(t => t['id'] == id)['brandId'];
    document.getElementById('updateformdiv').style.display = 'flex';
    CarIdToUpdate = id;
}

function remove(id) {
    fetch('http://localhost:61417/car/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application.json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Succes', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let id = document.getElementById('id').value;
    let model = document.getElementById('model').value;
    let brandId = document.getElementById('brandID').value;

    fetch('http://localhost:61417/car', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            id: id,
            model: model,
            brandid: brandId,

        }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let IdToUpdate = document.getElementById('idToUpdate').value;
    let modelToUpdate = document.getElementById('modelToUpdate').value;
    let brandIDToUpdate = document.getElementById('brandIDToUpdate').value;
    fetch('http://localhost:61417/car', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({
            id: IdToUpdate,
            model: modelToUpdate,
            brandid: brandIDToUpdate,

        }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });



}
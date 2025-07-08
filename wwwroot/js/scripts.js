const popup = document.getElementById("bosdx");
const closeBtn = document.getElementById("close");
const saveDescription = document.getElementById("save");
const inputField = document.getElementById("input");

closeBtn.addEventListener("click",closePopup);
saveDescription.addEventListener("click",createMark)

var e = null;

window.onload = async function () {
    await loadMarkers();
}

function openPopup() {
    popup.style.display = "flex";
}

function closePopup() {
    popup.style.display = "none";
}

async function loadMarkers() {
    let response = await fetch('/api/get/marks', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
    })
    if (response.ok) {
        let marks = await response.json();
        marks.forEach(function (mark) {
            console.log(mark.lat);
            var marker = L.marker([mark.lat, mark.lng]).addTo(map);
            marker.bindPopup(mark.descr);
        });
    }
}

async function createMark() {

    var popupText = crypto.randomUUID();
    if (inputField.value == "") {
        console.log("typsmth");
    }
    else{
        var marker = L.marker(e.latlng).addTo(map);
        popupText = inputField.value;

        marker.bindPopup(popupText).openPopup();

        let markerData = {
            marker_guid: crypto.randomUUID(),
            lat: e.latlng.lat,
            lng: e.latlng.lng,
            descr: popupText,
            user_id: 1
        }

        await fetch('/api/post/mark', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(markerData)
        })
        .then(response =>{
            if (response.ok) {
            let result = response.json();
            marker.myCustomGUID = result;
            console.log(marker.myCustomGUID);
        }
        })
        
        inputField.value = " ";
        closePopup(); 
    }
    
}

async function onMapClick(data) {
    e = data;
    await openPopup();
}

map.on('click', onMapClick);


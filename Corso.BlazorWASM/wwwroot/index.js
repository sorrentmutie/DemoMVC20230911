window.myFirstJavascriptFunction =
    (name, a, b) => {
        const sum = a + b;
        console.log("Hello " + name + ", from javascript. The total is: " + sum);
    };
window.mySecondJavaScriptFunction =
    (a, b) => {
        console.log("Hello from second function " + a);
        return a * b;
    };
window.myThirdFunction = () => {
    DotNet.invokeMethodAsync('Corso.BlazorLibrary', 'ReturnIntNumber')
    .then(  i => console.log(i));
}

window.sayHello = (myhelper) => {
    myhelper.invokeMethodAsync('SayHello')
        .then(result => console.log(result));
}

let myModal;
window.openModal = (id) => {
    myModal = new bootstrap.Modal(document.getElementById(id));
    myModal.show();
}

window.closeModal = () => {
    myModal.hide();
}

window.showMap = (latitude, longitude, zoomLevel, markers) => {
    var map = L.map('map').setView([latitude, longitude], zoomLevel);
    L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map);


    if (markers != null && markers.length > 0) {
        for (let i = 0; i < markers.length; i++) {
            var m = L.marker([markers[i].latitude, markers[i].longitude]).addTo(map);
        };
    };

    DotNet.invokeMethodAsync('Corso.BlazorLibrary', 'ReturnTooltip', 57)
        .then(result => {
            var marker = L.marker([latitude, longitude]).addTo(map);
            marker.bindPopup("<b>" + result + "</b><br>I am a popup.").openPopup();

        })

}
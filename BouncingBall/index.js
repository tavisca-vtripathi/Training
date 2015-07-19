var axisX = 0;
var axisY = 0;
var dx = 10;
var dy = 10;

function start() {
    setInterval(ballBounce, 20);

}
function ballBounce() {
    var height = (window.innerHeight - 50);
    var width = (window.innerWidth - 50);

    axisX += dx;
    axisY += dy;
    var element = document.getElementById('circle');
    element.style.background = "black";
    element.style.left = axisX + "px";
    element.style.top = axisY + "px";


    if (axisY >= height) {
        dy = -10;
        return;
    }
    if (axisX >= width) {
        dx = -10;
        return;
    }
    if (axisY <= 0) {
        dy = 10;
        return;
    }
    if (axisX <= 0) {
        dx = 10;
        return;
    }

}
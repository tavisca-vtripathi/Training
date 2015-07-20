window.ball = window.ball || {
    axisX: 0,
    axisY: 0,
    dx: 10,
    dy: 10
};

ball.bounce = function () {
    var element = document.getElementById('circle');
    element.style.background = "black";
    element.style.left = ball.axisX + "px";
    element.style.top = ball.axisY + "px";
    ball.container();
    ball.axisX += ball.dx;
    ball.axisY += ball.dy;
}
window.ball.start = function () {
    setInterval(ball.bounce, 10);
}
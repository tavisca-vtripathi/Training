window.ball = window.ball || {}

ball.container = function () {

    var height = (window.innerHeight - 50);
    var width = (window.innerWidth - 50);
    if (ball.axisY >= height) {
        ball.dy = -10;
    }
    if (ball.axisX >= width) {
        ball.dx = -10;
    }
    if (ball.axisY <= 0) {
        ball.dy = 10;
    }
    if (ball.axisX <= 0) {
        ball.dx = 10;
    }
}


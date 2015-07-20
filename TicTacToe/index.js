var painted;
var content;
var winningCombinations;
var canvasNum;
var checkMove;
var context;
var squaresFilled = 0;
window.onload = function ()
{
    painted = new Array();
    content = new Array();
    winningCombinations = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]];
    for (var i = 0; i <= 8; i++) {
        painted[i] = false;
        content[i] = '';
    }
}
function canvasMarked(canvasNumber) {
    canvasNum = "canvas" + canvasNumber;
    checkMove = document.getElementById(canvasNum);
    context = checkMove.getContext("2d");

    if (painted[canvasNumber - 1] == false)
    {
        if (squaresFilled % 2 == 0) {
            context.beginPath();
            context.moveTo(10, 10);
            context.lineTo(40, 40);
            context.moveTo(40, 10);
            context.lineTo(10, 40);
            context.stroke();
            context.closePath();
            content[canvasNumber - 1] = 'X';
        }

        else {
            context.beginPath();
            context.arc(25, 25, 20, 0, Math.PI * 2, true);
            context.stroke();
            context.closePath();
            content[canvasNumber - 1] = 'O';
        }

        
        painted[canvasNumber - 1] = true;
        squaresFilled++;
        checkWinner(content[canvasNumber - 1]);

        if (squaresFilled == 9) {
            alert("Game Over..!! Try Again..!!");
            location.reload(true);
        }

    }
    else {
        alert(" Bad Move..!! Try Empty places. ");
    }

}
function checkWinner(symbol) {

    for (var a = 0; a < winningCombinations.length; a++) {
        if (content[winningCombinations[a][0]] == symbol && content[winningCombinations[a][1]] == symbol && content[winningCombinations[a][2]] == symbol)
        {
            alert(symbol + " WON!");
            location.reload(true);
        }
    }

}

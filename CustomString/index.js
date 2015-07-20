


String.prototype.ConcatString = function () {

    var firstString = this;
    for (var i = 0; i < arguments.length; i++) {
        if (arguments[i] == "null")
            firstString += "null";
        if (arguments[i] == "undefined")
            firstString += "undefined";
        firstString += arguments[i];
    }
    return firstString;

};
String.prototype.Substring = function (numOne, numTwo) {
    if (numOne < 0 || numTwo < 0) {
        document.write("Invalid arguements entered");
        return;
    }
    var str = "";
    for (var index = numOne ; index < numTwo; index++)
    { str = str + (this[index]); }
   
    return str;
}



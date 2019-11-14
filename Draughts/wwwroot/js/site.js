// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var selectedChecker;

var circles = document.getElementsByTagName("circle");
function onClickCircle(event) {
    if (selectedChecker) {
        selectedChecker.setAttribute("stroke", "gray");
    }
    event.preventDefault();
    event.target.setAttribute("stroke", "green");
    selectedChecker = event.target;
}

for (var i = 0; i < circles.length; i += 1) {
    circles[i].addEventListener("click", onClickCircle);
}

var squares = document.getElementsByTagName("rect");
function onClickSquare(event) {
    if (selectedChecker) {
        document.getElementById("cx").value = selectedChecker.getAttribute("data-x");
        document.getElementById("cy").value = selectedChecker.getAttribute("data-y");
        document.getElementById("sx").value = event.target.getAttribute("data-x");
        document.getElementById("sy").value = event.target.getAttribute("data-y");
        document.getElementById("move-form").submit();
    }
}

for (var i = 0; i < squares.length; i += 1) {
    squares[i].addEventListener("click", onClickSquare);
}

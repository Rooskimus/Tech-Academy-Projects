// This project is incomplete due to the instructor
// not showing enough code in his video; he didn't expect us to 
// type it up ourselves.  I'm keeping it because there are some
// useful ideas that I may like to reference in the future.

// define the variables

var index = 13;

// doucment.getElementById('body') = the <body id="body"> on the html
var dom = document.getElementById('body');

// define the function
// in this case we are creating an array of background colors

// this = refers to the function nae, initArray()
// this[i] = initArray[i] = the index of the array equal 
// to i's value in the iteration.

// i++ to increment i's value by 1 for each pass in the loop.

function initArray() {
    this.length = initArray.arguments.length;
    for (var i = 0; i < this.length; i++) {
        this [i] = initArray.arguments[i];
    }
}

// instantiate the initArray
var col=new initAarray();

// dom.style.background = accessing the DOM css background property
function stop() {
    dom.style.background = '#ffffff';
    clearTimeout(loopID);
}


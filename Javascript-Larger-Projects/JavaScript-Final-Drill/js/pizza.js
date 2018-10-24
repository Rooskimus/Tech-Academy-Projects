// Declare Variables
 var acc = document.getElementsByClassName("accordion");
 var i;
 costOne = 0;
 costTwo = 0;
 costThree = 0;
 meatTotal = 0;
 vegTotal = 0;
 selectionOutput = 0;
 totalOutput = 0;
 size = 0
 cheese = 0
 crust = 0
 sauce = 0
 table = ""

// Accordion Feature
 for(i=0; i < acc.length; i++) {
    acc[i].addEventListener("click", function() {
        this.classList.toggle("active");  //toggles accordion element as active on click
        var panel = this.nextElementSibling;
        if(panel.style.maxHeight != 0) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
 }

 // This Function loads a pre-selected value into the accordion header 
 // and updates on click.
 // I haven't figured out how to generalize this yet.
 // ** For pizza size: **
 function accHeadUpdate1() {
    size = document.querySelector('input[name = "size"]:checked').value;
    if (size == "Personal") costOne = 6;
    else if (size == "Medium") costOne = 10;
    else if (size == "Large") costOne = 14;
    else if (size == "Extra Large") costOne = 16;
    if (costOne != 0) costOne = costOne.toFixed(2); // Displays .00 for non-zero only.
    document.getElementById("sizeSelect").innerHTML = "Your size: " + size + " (+ $" + costOne + ")";
 }
 accHeadUpdate1();

// ** For cheese: **
 function accHeadUpdate2() {
    cheese = document.querySelector('input[name = "cheese"]:checked').value;
    if (cheese == "No Cheese") costTwo = 0;
    else if (cheese == "Regular") costTwo = 0;
    else if (cheese == "Extra Cheese") costTwo = 3; 
    if (costTwo != 0) costTwo = costTwo.toFixed(2);
    document.getElementById("cheeseSelect").innerHTML = "Your cheese: " + cheese + " (+ $" + costTwo + ")";
}
accHeadUpdate2();

// For the crust, I wanted the options to just say the item without "crust" at the end
// on the radio buttons, so I added a simple if/else to give the price as a string I could
// then print after the word "crust" is concatenated.
function accHeadUpdate3() {
    crust = document.querySelector('input[name = "crust"]:checked').value;
    if (crust === "Cheese Stuffed") {
        costThree = 3;
        costThree = costThree.toFixed(2);
    } else {
        costThree = 0;
    }
    document.getElementById("crustSelect").innerHTML = "Your crust: " + crust + " Crust (+ $" + costThree + ")";
}
accHeadUpdate3();

// **For sauce: **
function accHeadUpdate4() {
    sauce = document.querySelector('input[name = "sauce"]:checked').value; 
    document.getElementById("sauceSelect").innerHTML = "Your sauce: " + sauce + " (+ $0)";
    // costFour would always be zero; we won't call it so we won't define it.
}
accHeadUpdate4();

// This function creates a string of all the selected items
// as well as tracks the cost.
function printChecked(x){
    var item = document.getElementsByName(x);
    var selectedItem="";
    var total = 0
    for(var i=0; i < item.length; i++){
        if(item[i].type == 'checkbox' && item[i].checked == true) {
            selectedItem += item[i].value + ", ";
            total++;
        }
    }
    selectionOutput = selectedItem;
    totalOutput = total;
}

// This function is to remove the final comma from the list created by printChecked()
function removeLastComma(x){
    var n = x.lastIndexOf(",");
    var a = x.substring(0,n);
    return a;
}

// For Meat:
function accHeadUpdate5() {
    printChecked("meat");
    selectedMeat = selectionOutput;
    meatTotal = totalOutput - 1;
        if (meatTotal < 0) meatTotal = 0;
    selectedMeat = removeLastComma(selectedMeat);
    document.getElementById("meatSelect").innerHTML = "Your Meats: " + selectedMeat + " (+ $" + meatTotal + ".00)";

}
accHeadUpdate5();

// For Veggies:
function accHeadUpdate6() {
    printChecked("veg");
    selectedVeg = selectionOutput;
    vegTotal = totalOutput - 1;
        if (vegTotal < 0) vegTotal = 0;
    selectedVeg = removeLastComma(selectedVeg);
    document.getElementById("vegSelect").innerHTML = "Your Veggies: " + selectedVeg + " (+ $" + vegTotal + ".00)";

}
accHeadUpdate6();

function runningTotal() {
    rTotal = (+costOne + +costTwo + +costThree + +meatTotal + +vegTotal) // The + before the variables ensures the string be read as a number
    document.getElementById("total").innerHTML = "Total: $" + rTotal.toFixed(2);
}
runningTotal();

function makeReceipt() {
    var totalText = "Order Total: ";
    var costText = "$" + rTotal.toFixed(2);
    var totalArray = [size, costOne, cheese, costTwo, crust, costThree, sauce, "0", selectedMeat, meatTotal, selectedVeg, vegTotal, totalText, costText];
    for(i=0; i < totalArray.length; i++){
        var ID = "C"+ i;
        document.getElementById(ID).innerHTML= totalArray[i];
        }
}
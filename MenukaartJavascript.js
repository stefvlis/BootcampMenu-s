const promptsync = require('prompt-sync')()
const menu = require('./menu.json');
var toPay = 0.00;

console.log("Hello, please take a look at our menu:");
menu.forEach(function(item){
    console.log(item.id +" \t "+ item.Dish +" €"+ item.Price)
});
var firstOrder = promptsync('Would you like to order something? (yes/no)');
if(firstOrder != 'yes' && firstOrder != 'no'){
    console.log('That is not a valid reply, please try again');
    firstOrder = promptsync('Would you like to order something? (yes/no)');
}
if(firstOrder == 'yes'){
    var gerechtId = promptsync("Type the ID of the dish you'd like to order: ");
    if(parseInt(gerechtId) > 10 || parseInt(gerechtId) < 0){
        console.log('That is not a valid reply, please try again');
        gerechtId = promptsync("Type the ID of the dish you'd like to order: ");
    }
    toPay += menu[gerechtId].Price
    var moreToOrder = promptsync('Would you like to order something else? (yes/no)');
    if (moreToOrder != 'yes' && $moreToOrder != 'no'){
        console.log('That is not a valid reply, please try again');
        moreToOrder = promptsync('Would you like to order something else? (yes/no)');
    }
    while (moreToOrder == 'yes'){
        gerechtId = promptsync("Type the ID of the dish you'd like to order: ");
        if(parseInt(gerechtId) > 10 || parseInt(gerechtId) < 0){
        console.log('That is not a valid reply, please try again');
        gerechtId = promptsync("Type the ID of the dish you'd like to order: ");
        }
        toPay += menu[gerechtId].Price
        moreToOrder = promptsync('Would you like to order something else? (yes/no)');
        if (moreToOrder != 'yes' && moreToOrder != 'no'){
            console.log('That is not a valid reply, please try again');
            moreToOrder = promptsync('Would you like to order something else? (yes/no)');
        }
    }
    console.log("Your total is €" + toPay)
}
else{
    console.log("Then why are you here?")
}

$menu = Get-Content .\menu.json | ConvertFrom-Json
$toPay = 0

Write-Host "Hello, please take a look at our menu:"
Write-Output $menu | Out-Host

$firstOrder = Read-Host "Would you like to order something? (yes/no)"
if (($firstOrder -ne 'yes') -and ($firstOrder -ne 'no')){
    Write-Host "That is not a valid reply, please try again"
    $firstOrder = Read-Host "Would you like to order something? (yes/no)"
}
if ($firstOrder -eq 'yes'){
    $gerechtId = Read-Host "Type the ID of the dish you'd like to order"
    if ($gerechtId -as [int] -gt 10 -or $gerechtid -as [int] -lt 0){
        Write-Host "That is not a valid reply, please try again"
        $gerechtId = Read-Host "Type the ID of the dish you'd like to order"
    }
    $toPay += $menu[$gerechtId].price
    $moreToOrder = Read-Host "Would you like to order anything else? (yes/no)"
    if (($moreToOrder -ne 'yes') -and ($moreToOrder -ne 'no')){
        Write-Host "That is not a valid reply, please try again"
        $moreToOrder = Read-Host "Would you like to order anything else? (yes/no)"
    }
    while ($moreToOrder -eq 'yes'){
        $gerechtId = Read-Host "Type the ID of the dish you'd like to order"
        if ($gerechtId -as [int] -gt 10 -or $gerechtid -as [int] -lt 0){
            Write-Host "That is not a valid reply, please try again"
            $gerechtId = Read-Host "Type the ID of the dish you'd like to order"
        }
        $toPay += $menu[$gerechtId].price
        $moreToOrder = Read-Host "Would you like to order anything else? (yes/no)"
        if (($moreToOrder -ne 'yes') -and ($moreToOrder -ne 'no')){
            Write-Host "That is not a valid reply, please try again"
            $moreToOrder = Read-Host "Would you like to order anything else? (yes/no)"
        }
    }
    Write-Host "Your total is $toPay euros"
}
else{
    Write-Host "Then why are you here?"
}   



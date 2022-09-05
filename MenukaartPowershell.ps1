$menu = Get-Content .\menu.json | ConvertFrom-Json
$toPay = 0

Write-Host "Hello"
Write-Output $menu | Out-Host

$firstOrder = Read-Host "Would you like to order something? (yes/no)"
if ($firstOrder -eq 'yes'){
    $gerechtId = Read-Host "Type the ID of the dish you'd like to order"
    $toPay += $menu[$gerechtId].price
    $moreToOrder = Read-Host "Would you like to order anything else? (yes/no)"
    while ($moreToOrder -eq 'yes'){
        $gerechtId = Read-Host "Type the ID of the dish you'd like to order"
        $toPay += $menu[$gerechtId].price
        $moreToOrder = Read-Host "Would you like to order anything else? (yes/no)"
    }
    Write-Host "Yor total is $toPay euros"
}
else{
    Write-Host "Then why are you here?"
}   

$a = 2
$b = 3

# If/Else Clause
if ($a -gt $b) {
    $messageOne = "Matched: This is message one"
} else {
    $messageOne = "Not matched: This is message one"
}

if ($a -lt $b ) { 
    $messageTwo = "Matched: This is message two" 
} else { 
    $messageTwo = "Not matched: This is message two" 
}

if ($a -eq $b) { 
    $messageThree = "Matched: This is message three"
} else { 
    $messageThree = "Not matched: This is message three"
}

Write-Host $messageOne
Write-Host $messageTwo
Write-Host $messageThree

$customObject = [PSCustomObject]@{
    "messageOne" = $messageOne
    "messageTwo" = $messageTwo
    "messageThree" = $messageThree
}

# Ternary Clause
$customTernaryObject = [PSCustomObject]@{
    "messageOne" = (($a -gt $b) ? "Matched: This is message one" : "Not Matched: This is message one")
    "messageTwo" = (($a -lt $b) ? "Matched: This is message two" : "Not Matched: This is message two")
    "messageThree" = (($a -eq $b) ? "Matched: This is message three" : "Not Matched: This is message three")
}

Write-Host $customTernaryObject.messageOne
Write-Host $customTernaryObject.messageTwo
Write-Host $customTernaryObject.messageThree
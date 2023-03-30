function Display-Message-1() 
{
    Write-Host "My Message"
}

function Display-Message-2($message) 
{
    Write-Host $message
}

function Display-Message-3()
{
    [String]$value1 = $args[0]
    [String]$value2 = $args[1]

    Write-Host $value1 $value2
}

function Display-Message-4()
{
    Param(
        [Parameter(Mandatory=$true)]
        [ValidateSet("Chevrolet", "Porsche", "Toyota", "Mercedes-Benz", "BMW", "Honda", "Ford", "Lexus")]
        [String]$Text
    )

    Write-Host "I like to drive a "$Text
}
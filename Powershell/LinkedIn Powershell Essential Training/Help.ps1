function Add-FourNumbers() 
{
    param(
        [Int32]
        # gives the first number
        $first, 
        [Int32]
        # gives the second number
        $second, 
        [Int32]
        # gives the third number
        $third, 
        [Int32]
        # gives the fourth number
        $fourth
    )

    # add the four numbers
    $result = $first + $second + $third + $fourth

    # write the sum of the numbers to the console
    Write-Host "$($first) + $($second) + $($third) + $($fourth) = $($result)"
}

function Add-FourNumbers-2
{
    <# 
    .SYNOPSIS
    Adds four numbers together and returns the result.

    .DESCRIPTION
    Adds four numbers together and returns the result. Takes any four numbers

    .Parameter first
    First number

    .Parameter second
    Second number

    .Parameter third
    Third number

    .Parameter fourth
    Fourth number 

    .Inputs 
    None

    .Outputs 
    System.String 
    #>

    param(
        [Int32]$first, 
        [Int32]$second, 
        [Int32]$third, 
        [Int32]$fourth
    )
    $result = $first + $second + $third + $fourth
    Write-Host "$($first) + $($second) + $($third) + $($fourth) = $($result)" 
}

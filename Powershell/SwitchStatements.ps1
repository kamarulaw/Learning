$value = Read-Host "Type your favorite car brand"

Switch ($value)
{
    Brand1 {'You typed: Brand 1'}
    Brand2 {'You typed: Brand 2'}
    Brand3 {'You typed: Brand 3'}
    Brand4 {'You typed: Brand 4'}
    default{'You did not type any brand'}
}

$brand1 = Read-Host "Type your first favorite car brand"
$brand2 = Read-Host "Type your second favorite car brand"

Switch($brand1, $brand2)
{
    Brand1 {'You typed: Brand1'}
    Brand2 {'You typed: Brand2'}
    Brand3 {'You typed: Brand3'}
    Brand4 {'You typed: Brand4'}
    default{'You did not type any brand'}
}
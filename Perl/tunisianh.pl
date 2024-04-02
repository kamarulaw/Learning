#!/usr/bin/perl
use warnings; 

# global variable
$string = "Hello, world \n\n";

sub PrintHello {
    # private variable for PrintHello function
    local $string; 
    $string = "Hello, Perl \n\n";
    PrintMe(); 
    print "Inside PrintHello() $string \n\n";
    
}

sub PrintMe {
    print "Inside PrintMe() $string \n\n"; 
}

&PrintHello; 
print "Global Print $string\n";

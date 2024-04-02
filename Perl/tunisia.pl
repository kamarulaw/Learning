#!/usr/bin/perl
use warnings; 
use strict; 

# global variable
my $string = "Hello, world! \n\n";
print "$string";

# func definition 
sub PrintHello {
    print $string; 
    
    my $string;
    print "<THIS PRINTS w/ WARNING> $string \n\n";
    
    $string = "Hello, Perl! \n\n"; 
    print $string; 
}

&PrintHello; 


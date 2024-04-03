use warnings; 
use strict; 

# state variables in Perl remind me of static variables in Java
# state variables belong to their subroutine ~ static variables belong to their class (?)

my $datestring = localtime( time );
my ($sec,$min,$hour,$mday,$mon,$year,$wday,$yday,$isdst) = localtime( time );
my @datelist = localtime( time ); 

print $datestring . "\n";
print "$datestring" . "\n";
print "\n";

print "$sec" .   "\t"; 
print "$min" .   "\t"; 
print "$hour" .  "\t"; 
print "$mday" .  "\t"; 
print "$mon" .   "\t"; 
print "$year" .  "\t";
print "$wday" .  "\t";
print "$yday" .  "\t";
print "$isdst" . "\t";
print "\n";

foreach my $item(@datelist) {
    print "$item\t";
}

# _______
# Wed Apr  3 14:34:34 2024
# Wed Apr  3 14:34:34 2024
 
# 34      34      14      3       3       124     3       93      0
# 34      34      14      3       3       124     3       93      0

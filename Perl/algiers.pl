use warnings; 
use strict; 

sub math {
    my $numvar1 = 1; 
    my $numvar2 = 2; 
    
    my %simplehash = ("China" => "Chinese", "India" => "Hindi", "Singapore" => "Singlish", "Nigeria" => "Haussian"); 
    
    my $language1 = %simplehash{"China"};
    my $language2 = %simplehash{"India"}; 
    my $language3 = %simplehash{"Nigeria"};
    
    print $language1 . "\n"; 
    print $language2 . "\n"; 
    print $language3 . "\n";
    #for (keys simplehash) {
    #    print $_ , simplehash{$_}; 
    #}
}
######################################################################################################################################

use warnings; 
use strict; 

sub IndexLevelAverage {
    # Compute the Index-level Average for the five length-ten input arrays
    my (@arr1, @arr2, @arr3, @arr4, @arr5) = @_; 
    
    my @result = ();
    
    for (my $i = 0; $i < 10; $i++) {
        push(@result, ($arr1[$i] + $arr2[$i] + $arr3[$i] + $arr4[$i] + $arr5[$i]) / 5);
    }
    print("@result\n");
}
sub PrintArray {
    my (@arr) = @_; 
    for (my $i = 0; $i < scalar @arr; $i++) {
        print "$arr[$i]\t"; 
    }
}

my @a1 = (1..10); my @a2 = (); my @a3 = (); my @a4 = (); my @a5 = ();

foreach my $item (@a1) {
    push(@a2, $item * 10); 
    push(@a3, $item * 20); 
    push(@a4, $item * 30); 
    push(@a5, $item + 4); 
}

&IndexLevelAverage(@a1, @a2, @a3, @a4, @a5);
#my @array_of_arrays = (@a1, @a2, @a3, @a4, @a5);
#&PrintArray(@array_of_arrays[0]);
#&PrintArray(@array_of_arrays[1]);
#&PrintArray(@array_of_arrays[2]);
#&PrintArray(@array_of_arrays[3]);
#&PrintArray(@array_of_arrays[4]);

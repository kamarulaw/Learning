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
    
    my ($arr1, $arr2, $arr3, $arr4, $arr5) = @_; 
    
    my @result = ();
    
    for (my $i = 0; $i < 10; $i++) {
        my $sum = @$arr1[$i] + @$arr2[$i] + @$arr3[$i] + @$arr4[$i] + @$arr5[$i];
        
        my $index_level_average = $sum / 5; 
        
        push(@result, $index_level_average);
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

&IndexLevelAverage(\@a1, \@a2, \@a3, \@a4, \@a5)

#my @array_of_arrays = (@a1, @a2, @a3, @a4, @a5);
#&PrintArray(@array_of_arrays[0]);
#&PrintArray(@array_of_arrays[1]);
#&PrintArray(@array_of_arrays[2]);
#&PrintArray(@array_of_arrays[3]);
#&PrintArray(@array_of_arrays[4]);
# HINT: https://www.perlmonks.org/?node_id=862178 (Passint two arrays to a subrroutine)
######################################################################################################################################
use warnings; 
use strict; 

sub AnnualPopulationDifference {
    # Compute difference in populations between 2010 and 2011
    my ($hashref1, $hashref2) = @_; 
    
    my %result = ();
    
    for (keys %$hashref1) {
        $result{$_} = %$hashref2{$_} - %$hashref1{$_}; 
        
    }
    return %result; 
}

my %Population2010 = ("China" => 10, "India" => 15, "Nigeria" => 20); 
my %Population2011 = ("China" => 200, "India" => 300, "Nigeria" => 400); 

my %apd = &AnnualPopulationDifference(\%Population2010, \%Population2011);

for (keys %apd) {
    print "$_\[Delta\]: $apd{$_}\n"; 
}

######################################################################################################################################
# Exercise 9 - Subroutines

#make a subroutine that calculates the reverse complement of a DNA sequence
sub str_rev {
    my ($DNAarr) = @_;
    my $DNAlen = scalar @$DNAarr;
    for (my $i = 0; $i < $DNAlen / 2; $i++) 
    {
        my $temp = @$DNAarr[$i]; 
        @$DNAarr[$i] = @$DNAarr[$DNAlen - 1 - $i];
        @$DNAarr[$DNAlen - 1 - $i] = $temp; 
    }
    return @$DNAarr;
}

sub str_comp {
    my ($DNAarr) = @_; 
    my @DNAcomp = (); 
    foreach my $elem(@$DNAarr) 
    {
        if ($elem eq "A") {
            push(@DNAcomp, "T");
        } elsif ($elem eq "C") {
            push(@DNAcomp, "G");
        } elsif ($elem eq "G") {
            push(@DNAcomp, "C");
        } else {
            push(@DNAcomp, "A");
        }
    }
    return @DNAcomp;
}

@arr = ("A", "G","C","G","T","A");
@revarr = &str_rev(\@arr);
@dnacomp = &str_comp(\@revarr);

foreach my $elem (@revarr) {
    print "$elem\n";
}
print "\n";

foreach my $elem (@dnacomp) {
    print "$elem\n";
}

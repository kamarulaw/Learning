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

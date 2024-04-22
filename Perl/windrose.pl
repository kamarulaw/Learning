# Babraham Bioinformatics
use warnings; 
use strict; 

# Exercise 1: Scalars and Scalar Variables

#1a
print "Hello World\n";

#1b 
my $var = "Kamaru-deen Lawal";

#1c
print 'Mike@example.com says “$500 for a car – that’d be a good deal!”' . "\n";
print "Mike\@example.com says \“\$500 for a car – that\’d be a good deal!\”" . "\n"; 

#1d
#my $EOF_IDENTIFIER = <<"EOF"; 
#This is the syntax for a here document and it will conitnue until it 
#encounters a EOF in the first line. This is case of of double quote
#so variable value will be interpolated. For example value of var = $var
#EOF
#Use a here document to quote and print a multi-line formatted piece of text.
#Make at least one variable substitution within the body of the text. 
#print "$EOF_IDENTIFIER";

#1e 
sub formula {
    my ($a, $b, $c) = @_; 
    my $numerator = $a + $b; 
    my $denominator = $c; 
    return $numerator / $denominator;
}
print &formula(2, 3 , 4) . "\n";
print &formula(-20 , 5 , 3) . "\n"; 

# Exercise 2: Scalar Functions

#2a
sub string_len {
    my ($var) = @_; 
    return "The string \'$var\' is " . length $var , " letters long \n"; 
}
print &string_len("Perl");
print &string_len("Sisyphean");
print &string_len("Antidisestablishmentarianism");
print &string_len("Pneumonoultramicroscopicsilicovolcanoconiosis");

# Exercise 3: Conditions

#3a
sub is_palindromic {
    my ($str) = @_; 
    my $string_length = length $str; 
    for (my $i = 0; $i < $string_length / 2; $i++) 
    {
        if (substr($str, $i, 1) ne substr($str, $string_length - 1 - $i, 1)) 
        {
            return "$str a palindrome \( ? \) | false\n";
        }
    }
    return "$str a palindrome \( ? \) | true\n";
}
print &is_palindromic("chickennekcihc");
print &is_palindromic("burgerssregrub");
print &is_palindromic("123456787654321");
print &is_palindromic("12345677654321");
print &is_palindromic("1234567654321");
print &is_palindromic("1234654321");

#3b
sub classification_on_length {
    my ($str) = @_;
    my $str_len = length $str; 
    if ($str_len <= 3) {
        return 5;
    } elsif ($str_len <= 4) {
        return 6; 
    } elsif ($str_len <= 6) {
        return 8; 
    } elsif ($str_len <= 10) {
        return 10; 
    } elsif ($str_len > 10) {
        return 12; 
    }
}
print &classification_on_length("e") . " years" , "\n";
print &classification_on_length("el") . " years" , "\n";
print &classification_on_length("ely") . " years" , "\n";
print &classification_on_length("elys") . " years" , "\n";
print &classification_on_length("elyse") . " years" , "\n";
print &classification_on_length("elyse ") . " years" , "\n";
print &classification_on_length("elyse s") . " years" , "\n";
print &classification_on_length("elyse sm") . " years" , "\n";
print &classification_on_length("elyse smi") . " years" , "\n";
print &classification_on_length("elyse smit") . " years" , "\n";
print &classification_on_length("elyse smith") . " years" , "\n";

#3c 
sub death_script {
    my ($gender, $smoker, $exercise, $alcohol, $fatty_food) = @_;
    
    $gender = uc(substr($gender, 0, 1));
    $smoker = uc(substr($smoker, 0, 1));
    $fatty_food = uc(substr($fatty_food, 0, 1));
    
    my $base_age = 70;
    my $alc_units_gt_seven = $alcohol - 7; 
    
    if ($gender eq "F") {$base_age += 4;}
    if ($smoker eq "Y" || $smoker eq "T") {$base_age -= 5;}
    if ($smoker eq "N" || $smoker eq "F") { $base_age += 5;}
    if ($fatty_food eq "N" || $fatty_food eq "F") { $base_age += 3;}
    if ($exercise == 0) { $base_age -= 3;} else { $base_age += $exercise;}
    if ($alc_units_gt_seven >= 1) { $base_age -= ($alc_units_gt_seven * .5);}
    return $base_age;
}
print &death_script("male", "true", 2 , 10 , "yes") . "\n";

#3d 
sub passwordchecking_script {
    my ($user, $op, $np) = @_;
    
    if ($op ne $np && length $np > 7 && lc($np) ne $np) 
    {
        return "$np OK";
    }
    return "$np !OK";
}
print &passwordchecking_script("klawal", "!OK", "okaypwd?") . "\n";
print &passwordchecking_script("klawal", "!OK", "okaypwD?") . "\n";
print &passwordchecking_script("klawal", "okaypwD?", "okaypwD?") . "\n";
print &passwordchecking_script("klawal", "okaypwd?", "okaypwD?") . "\n";

# Exercise 4: Arrays (and loops)

#4a
sub snowwhite_script{
    my @dwarves = ("Doc","Sneezy","Grumpy","Happy","Bashful","Sleepy","Dopey");
    for (my $i = 0; $i < scalar @dwarves; $i++) 
    {
        print "Hi ho! \[$dwarves[$i]\]\n"
    }
}
&snowwhite_script();

#4b
sub random_array_population {
    my @arr = (); 
    for (my $i = 0; $i < 100; $i++) 
    {
        push(@arr, 1 + int(rand(100)));
    }
    
    @arr = sort {$a <=> $b} @arr; 
    
    for (my $i = 0; $i < 10; $i++) 
    {
        print $arr[$i] . "\t";
    }
}

print &random_array_population() . "\n"; 

#4c 
sub dna_primer_melt_temperature() {
    my ($dna_primer) = @_;
    my $melt_temperature = 0; 
    for (my $i = 0; $i < length $dna_primer; $i++) 
    {
        if (substr($dna_primer, $i, 1) eq "G" || substr($dna_primer, $i, 1) eq "C")
        {
            $melt_temperature += 4;
        }
        
        if (substr($dna_primer, $i, 1) eq "A" || substr($dna_primer, $i, 1) eq "T" || substr($dna_primer, $i, 1) eq "U")
        {
            $melt_temperature += 2;
        }
    }
    return $melt_temperature
}

print "melt temperature: " . &dna_primer_melt_temperature("AGGCT") , "\n";
print "melt temperature: " . &dna_primer_melt_temperature("TAACTGTAACTCCTAGGTA") , "\n";

# Exercise 5: Hashes (and loops)

#5a
sub sorted_amino_acids {
    # weight in Daltons
    my %aminoacid_mw_kvpairs = ("Ala" => 89, "Arg" => 174, "Asn" => 132, "Asp" => 133, "Asx" => 133, "Cys" => 121, "Gln" => 146, "Glu" => 147, "Glx" => 147, "Gly" => 75, "His" => 155, "Ile" => 131, "Leu" => 131, "Lys" => 146, "Met" => 149, "Phe" => 165, "Pro" => 115, "Ser" => 105, "Thr" => 119, "Trp" => 204, "Tyr" => 181, "Val" => 117);
    
    my @keys_sorted_by_val = sort {$aminoacid_mw_kvpairs{$a} <=> $aminoacid_mw_kvpairs{$b}} keys(%aminoacid_mw_kvpairs);
    my @vals = @aminoacid_mw_kvpairs{@keys_sorted_by_val};
    
    my %aminoacid_mw_kvpairs_sorted; 
    
    for (my $i = 0; $i < scalar @keys_sorted_by_val; $i++) 
    {
        $aminoacid_mw_kvpairs_sorted{@keys_sorted_by_val[$i]} = @vals[$i];
        print @keys_sorted_by_val[$i] . " ";
    }
    print "\n";
}

&sorted_amino_acids();

# Exercise 6: Loops

#6a
sub is_prime {
    my ($num) = @_; my $true = "True"; my $false = "False";
    if ($num == 2 || $num == 3) {return $true;}
    if ($num == 1 || $num % 2 == 0) {return $false;}
    for (my $i = 3; $i < 1 + int(sqrt($num)); $i++) {if ($num % $i == 0) {return $false;}}
    return $true; 
}

sub nth_prime {
    my ($n) = @_;
    my $primes_found = 0;
    my $guess = 2; 
    while ($primes_found < $n)
    {
        if (&is_prime($guess) eq "True") {$primes_found++;}
        if ($primes_found == $n) {return $guess;} else {$guess++;}
    }
}

print &nth_prime(100) . "\n";

# Exercise 10: Subroutines

#10a 
sub str_to_lst {
    my ($str) = @_;
    my @result = ();
    for (my $i = 0; $i < length $str; $i++) 
    {
        push(@result, substr($str, $i, 1));
    }
    return @result; 
}

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
        } elsif ($elem eq "a") {
            push(@DNAcomp, "t");
        } elsif ($elem eq "c") {
            push(@DNAcomp, "g");
        } elsif ($elem eq "g") {
            push(@DNAcomp, "c");
        } elsif ($elem eq "T") {
            push(@DNAcomp, "A")
        } elsif ($elem eq "t") {
            push(@DNAcomp, "a");
        }
    }
    return @DNAcomp;
}

sub display_list {
    my (@lst) = @_; 
    for (my $i = 0; $i < scalar @lst; $i++)
    {
        print $lst[$i] . " ";
    }
    print "\n";
}

my $dnasequence = "AgcctA";
my @dnasequence_arr = &str_to_lst($dnasequence);
my @dnasequence_reverse = &str_rev(\@dnasequence_arr);
my @dnasequence_reverse_comp = &str_comp(\@dnasequence_reverse);

print "REVERSECOMPLEMENT($dnasequence) = "; 
&display_list(@dnasequence_reverse_comp);
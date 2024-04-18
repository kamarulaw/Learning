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

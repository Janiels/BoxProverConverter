# BoxProverConverter
Convert from Word equations to BoxProver input

# Usage
Write a proof in Huth & Ryan style and put it in Word as a 3xN matrix. For example:
![Word example](/docs/Word_equation.png)

Note that no boxes are present - boxes will be detected automatically by the tool.

Next, copy the matrix out of the equation and put it in the clipboard. Then run the tool. If all goes well,
it will place input for BoxProver in the clipboard. Go to [Box prover](http://boxprover.utr.dk) and paste it.

In our case, the tool outputs this:
```
%abbrev
autogen : {p}{q}
		proof (( ~ (p /\ q) , |-  ~ q \/  ~ p)) =
[p][q]
 ~ (p /\ q)		premise; [@l1]
(  ~ ( ~ q \/  ~ p)		assumption; [@l2]
(  ~ p		assumption; [@l3]
 ~ q \/  ~ p		by dis_i2 @l3 ; [@l4]
 bot 		by neg_e @l4 @l2 ) ; [@l5]
 ~  ~ p		by neg_i @l5 ; [@l6]
p		by nne @l6 ; [@l7]
(  ~ q		assumption; [@l8]
 ~ q \/  ~ p		by dis_i1 @l8 ; [@l9]
 bot 		by neg_e @l9 @l2 ) ; [@l10]
 ~  ~ q		by neg_i @l10 ; [@l11]
q		by nne @l11 ; [@l12]
p /\ q		by con_i @l7 @l12 ; [@l13]
 bot 		by neg_e @l13 @l1 ) ; [@l14]
 ~  ~ ( ~ q \/  ~ p)		by neg_i @l14 ; [@l15]
 ~ q \/  ~ p		by nne @l15.
```

# Useful shortcuts in equations:
New 3x8 matrix:  
`\matrix<space>(&&@@@@@@@@)<space>`  
For each @, adds another row to the matrix

`\wedge`: ∧  
`\vee`: ∨  
`\neg`: ¬  
`->`: →  
`⊤`: \top  
`⊥`: \bot
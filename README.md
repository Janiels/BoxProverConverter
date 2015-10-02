# BoxProverConverter
Convert from Word equations to BoxProver input

# Usage
Write a proof in Huth & Ryan style and put it in Word as a 3xN matrix. For example:
![Word example](/docs/word_equation.png)
Note that no boxes are present - boxes will be detected automatically by the tool.

Next, copy the matrix out of the equation and put it in the clipboard. Then run the tool. If all goes well,
it will place input for BoxProver in the clipboard. Go to [Box prover](http://boxprover.utr.dk) and paste it.

# Useful shortcuts in equations:
New 3x8 matrix:
\matrix<space>(&&@@@@@@@@)<space>
For each @, adds another row to the matrix

\wedge: ∧
\vee: ∨
\neg: ¬
->: →
⊤: \top
⊥: \bot
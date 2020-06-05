# ClassicSudokuValidator
Determines if a Sudoku puzzle is correct or not
Validation rules defined by https://en.wikipedia.org/wiki/Sudoku
If any variant on the classic Sudoku puzzle is needed in the future:
- Each puzzle type would need to have to override two methods for Processing and Validation
- Would need to tell the machine what type of game we're playing, may be tough to decide if it's a 9x9 Classic or a 9x9 Classic with a slight variation in the rules

# Notes:
- A .txt file must be used, several are included in the \bin\Debug\netcoreapp3.1 folder
- If a file has empty lines or spaces, but still has a 9x9 valid grid, it is considered valid
- It will consider a Sudoku puzzle invalid if:
  - One column contains more than 9 digits
  - One row contains more than 9 digits
  - Any entry is not a numeric value
  - Any numeric value is not between 1-9
# Implementation notes:
 - Used a byte 2 dimentional array because it's smaller in size (0-255) compared to  shorts or integers (32k or 2.1m)
 - Validated the file data before checking the individual regions
 - I considered adding a auto run for test files (anything in a folder) but I wanted to keep the main program simple

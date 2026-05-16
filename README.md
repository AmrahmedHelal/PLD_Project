# PLD Project - Object-Oriented Programming Language Parser

A Windows Forms application that implements a lexical and syntactic analyzer for an Object-Oriented Programming (OOP) language using the GOLD Parser framework.

## Overview

PLD Project is a parser application that analyzes and validates custom OOP syntax. It provides real-time tokenization and parsing of code written in a simplified OOP language, displaying both lexical tokens and parse errors through an intuitive GUI.

## Features

- **Lexical Analysis**: Real-time tokenization of input code
- **Syntactic Analysis**: Full parsing of OOP language constructs using LALR parsing
- **Windows Forms GUI**: User-friendly interface for code input and analysis
- **Real-time Feedback**: Immediate parsing results and error reporting
- **Grammar Support**:
  - Class declarations (with inheritance and access modifiers)
  - Method and constructor declarations
  - Field declarations with static/access modifiers
  - Variable declarations and assignments
  - Control flow (if-else, for loops)
  - Expressions and operations
  - Method calls and object instantiation

## Project Structure

```
PLD_Project/
├── Form1.cs                 # Main UI form
├── Form1.Designer.cs        # Form designer code
├── Form1.resx              # Form resources
├── Parser.cs               # LALR Parser and grammar rules
├── Program.cs              # Application entry point
├── PLDProject.csproj       # Project file
├── PLDProject.sln          # Solution file
├── App.config              # Application configuration
└── OOP2.cgt                # GOLD Grammar Table file
```

## Prerequisites

- .NET Framework (compatible with the project configuration)
- Visual Studio or compatible C# development environment
- GOLD Parser library (com.calitha.goldparser)

## Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/AmrahmedHelal/PLD_Project.git
   cd PLD_Project
   ```

2. **Open in Visual Studio**
   - Open `PLDProject.sln` in Visual Studio

3. **Build the project**
   - Build Solution (Ctrl+Shift+B)

4. **Run the application**
   - Press F5 or click Run

## Usage

1. **Launch the application** - The GUI will open with an input text area
2. **Enter OOP code** - Type or paste your OOP language code in the input field
3. **View results**:
   - **Tokens List** - Shows lexical tokens identified in the code
   - **Parse Output** - Displays parsing results and any errors encountered

### Example Code

```
class Calculator Begin
    private int result;
    
    public void Add(int a int b) Begin
        result = a + b;
    Finish
Finish

Begin
    int x = 5;
    int y = 10;
Finish
```

## Grammar Highlights

### Supported Keywords
- **Class Definition**: `class`, `Begin`, `Finish`
- **Data Types**: `int`, `float`, `double`, `string`
- **Access Modifiers**: `public`, `private`, `protected`
- **Keywords**: `if`, `else`, `for`, `return`, `new`, `static`, `this`

### Operators
- **Arithmetic**: `+`, `-`, `*`, `/`, `%`
- **Comparison**: `==`, `!=`, `<`, `>`, `=`
- **Increment/Decrement**: `++`, `--`

### Control Structures
- **Conditional**: `if/else` statements
- **Loops**: `for` loops with full syntax support

## Technical Details

- **Parser Type**: LALR (Look-Ahead LR)
- **Grammar File**: OOP2.cgt (GOLD Compiled Grammar Table)
- **Framework**: .NET Windows Forms
- **Parser Library**: GOLD Parser (com.calitha.goldparser)

## How It Works

1. **Initialization**: The parser loads the OOP2.cgt grammar file on startup
2. **Input Processing**: When code is entered, it triggers the parser
3. **Lexical Analysis**: Breaks input into tokens and classifies them
4. **Syntactic Analysis**: Validates token sequence against grammar rules
5. **Error Reporting**: Displays any syntax errors with token information

## File Descriptions

- **Form1.cs**: Main form with event handlers for real-time parsing
- **Parser.cs**: Complete LALR parser implementation with 95 grammar rules
- **Program.cs**: Application entry point and form initialization
- **OOP2.cgt**: Compiled grammar table defining the language syntax

## Error Handling

The parser provides feedback for:
- **Token Errors**: Invalid characters or unexpected tokens
- **Parse Errors**: Grammar violations with expected tokens
- **Syntax Issues**: Detailed line number information

## Future Enhancements

- Code syntax highlighting
- Semantic analysis
- Code generation
- Extended grammar rules
- Visual AST (Abstract Syntax Tree) display

## Author

[AmrahmedHelal](https://github.com/AmrahmedHelal)

## License

This project is provided as-is for educational purposes.

## Contributing

Contributions are welcome! Feel free to submit issues and pull requests.

---

**Note**: This is an educational project demonstrating parser implementation using GOLD Parser framework for a custom OOP language.

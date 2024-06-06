# yamlchecker
## Summary
- yamlchecker checks whether the yaml file is valid.
- It returns result code according to the validation check;
    - code 0: the file is valid
    - code -16: the specified file is not exist
    - code -32: the file has syntax error
    - code -48: the file has semantic error
    - code -127: some error has occurred

## Usage
`yamlchecker [yaml file path]`

## How to Build
1. Install .NET 6 (or later) SDK
2. run `dotnet build`

## Disclaimer
This program is provided by AS-IS and the author assumes no responsibility for any consequences of using this program.

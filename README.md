# Search Speed Tests

The project attempts to compare search timings of 3 different types of searches:-
  String Match
  Regular Expressions
  Pre Processing

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Structure
Code is located under TargetSearchSpeedTests/TargetInterviewCaseStudy3/
Tests are located under TargetSearchSpeedTests/SearchSpeedTests/
Executable file TargetSearchSpeedTests/TargetInterviewCaseStudy3.exe
Test Output file TargetSearchSpeedTests/TestOutPut.txt

### Prerequisites

Please install the .NET framework on your local machine, which is required to run .NET console applications.
https://www.microsoft.com/net/download/thank-you/net471

### Installing
Download or clone the project onto your local machine. Run the executable file that comes with the project TargetInterviewCaseStudy3.exe

### Running the Application
The console application walks you through running different types of searches and returns the results of the search in the file location
provided.
You will need to provide the application as input the following:-
  a) Directory location of the files to be searched. (Eg:- C:\SearchFiles)
  b) The type of search(StringMatch, RegularExpressions, PreProcess)
  c) The search term (only allows single search term for now)
 
 Output:-
 The fileNames and the number of matches

## Running the tests
To run the tests you will need to clone the repository into a local repository and open the solution in Visual Studio 2017
Under the testing project, the tests are located in the file SearchSpeedTests.cs
These tests can be running using the MSTest runner that comes with Visual Studio.
The path of the input and output file generated can be modified.
A sample output file generated is uploaded under TargetSearchSpeedTests/TestOutput.txt

## Author
Vineet Saju




# Search Speed Tests

The project attempts to compare search timings of 3 different types of searches:-
  String Match
  Regular Expressions
  Pre Processing

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Structure
Code is located under TargetSearchSpeedTests/TargetInterviewCaseStudy3/ <br>
Tests are located under TargetSearchSpeedTests/SearchSpeedTests/ <br>
Executable file TargetSearchSpeedTests/TargetInterviewCaseStudy3.exe <br>
Test Output file TargetSearchSpeedTests/TestOutPut.txt <br>
Search files located TargetSearchSpeedTests/TargetInterviewCaseStudy3/SearchFiles/

### Prerequisites

Please install the .NET framework on your local machine, which is required to run .NET console applications.
https://www.microsoft.com/net/download/thank-you/net471

### Installing
Download or clone the project onto your local machine. <br>
Run the executable file that comes with the project TargetInterviewCaseStudy3.exe

### Running the Application
The console application walks you through running different types of searches and returns the results of the search in the file location
provided.<br>
You will need to provide the application as input the following:-<br>
  a) Directory location of the files to be searched. If no input provided default location used. (Eg:- C:\SearchFiles)<br>
  b) The type of search(StringMatch, RegularExpressions, PreProcess)<br>
  c) The search term (only allows single search term for now)<br>
 
 Output:-
 The fileNames and the number of matches

## Running the tests
To run the tests you will need to clone the repository into a local repository and open the solution in Visual Studio 2017<br>
Under the testing project, the tests are located in the file SearchSpeedTests.cs<br>
These tests can be running using the MSTest runner that comes with Visual Studio.<br>
The path of the input search files and output file generated by the tests can be modified by editing the code. Otherwise default path pointing to SearchFiles is used.<br>
A sample output file generated is uploaded under TargetSearchSpeedTests/TestOutput.txt<br>

## Author
Vineet Saju




# 24e2a906-733f-4edb-abd1-c9fe871d60d7

## Problem
Develop a function that takes one string input of any number of integers separated by single whitespace. The function then outputs
 the longest increasing subsequence (increased by any number) present in that sequence. If more than 1 sequence exists with the 
 longest length, output the earliest one. You may develop supporting functions as many as you find reasonable. Your function should
 pass the test cases provided below.
 
## Solution
Accepts string input of any number of integers separated by single whitespace and returns the longest increasing subsequence. It validates 
the input string and only accepts numbers and whitespaces in it. Will return "Incorrect input format" for all incorrect formats. Function 
can be found in PatternFinder.Util.LisFinder.Find(string input) method.

## Unit Tests
Added xUnit unit tests to perform edge case testing as well as validate given test cases.

## Continuous Integration
1. Github Action Workflow is being used for CI pipeline integration. Link - https://github.com/saikatkrroy/24e2a906-733f-4edb-abd1-c9fe871d60d7/actions/workflows/Build.yml
2. Added SonarQube Scanner into the workflow for linting. Link - https://sonarcloud.io/project/overview?id=saikatkrroy_24e2a906-733f-4edb-abd1-c9fe871d60d7

## Verification
The solution can be tested using Unit Test, Visual Studio, and Docker

### Command Prompt
1. Clone the Repository in your local
2. Open command prompt and navigate to PatternFinder/PatternFinder.Test.
3. Run "dotnet test PatternFinder.Test.csproj"

### Visual Studio
1. Clone the Repository in your local.
2. Navigate to PatternFinder folder and open the .sln with visual Studio
3. Press 'F5' and run the solution.

### Docker (ensure docker is installed)
1. Clone the Repository in your local.
2. Navigate to PatternFinder folder in Command prompt
3. Run "docker build -t patternfinder ." and wait till it completes.
4. Run "docker run -it patternfinder" and provide input.
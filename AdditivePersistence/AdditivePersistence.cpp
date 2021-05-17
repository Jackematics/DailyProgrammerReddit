// AdditivePersistence.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>

using std::string;

int calculateAdditivePersistence(int n)
{
    string convertN = std::to_string(n);
    int numberOfIterations = 0;

    while (convertN.size() > 1)
    {
        int digitAddition = 0;
        for (int i = 0; i < convertN.size(); i++)
        {
            int digit = convertN[i] - '0';
            digitAddition += digit;
        }

        convertN = std::to_string(digitAddition);
        ++numberOfIterations;
    }

    return numberOfIterations;
}

void printResult(int testInput)
{
    int numberOfIterations = calculateAdditivePersistence(testInput);
    std::cout << "Additive persistence of " << testInput << ": " << numberOfIterations << std::endl;
}

int main()
{
    int testInput1 = 13;
    int testInput2 = 1234;
    int testInput3 = 9876;
    int testInput4 = 199;

    printResult(testInput1);
    printResult(testInput2);
    printResult(testInput3);
    printResult(testInput4);   
}
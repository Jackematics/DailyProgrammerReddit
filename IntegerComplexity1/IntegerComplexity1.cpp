// IntegerComplexity1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>

#include "Factor.h"

void printResults(std::vector<int> testCases)
{
    Factor factor;

    for (int i = 0; i < testCases.size(); i++)
    {
        std::cout << "smallestFactorPairSum(" << testCases[i] << ") = " << factor.smallestFactorPairSum(testCases[i]) << std::endl;
    }    
}

int main()
{
    std::vector<int> testCases
    {
        12,
        456,
        4567,
        12345
    };

    printResults(testCases);
}
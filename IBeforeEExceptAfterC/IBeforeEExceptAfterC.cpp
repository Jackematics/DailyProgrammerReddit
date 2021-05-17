// IBeforeEExceptAfterC.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <vector>
#include <string>

bool satisfiesSpellingRule(std::string word)
{
    for (int i = 1; i < word.size(); i++)
    {
        if (word[i] == 'i')
        {            
            if (i == 1 && word[0] == 'e')
            {
                return false;
            }  
            
            if (word[i - 1] == 'e' && word[i - 2] != 'c')
            {
                return false;
            }

            if (i == word.size() - 1)
            {
                continue;
            }

            if (word[i + 1] == 'e' && word[i - 1] == 'c')
            {
                return false;
            }
        }
    }

    return true;
}

void printResults(std::string word)
{
    std::cout << word << " follows rule? " << std::to_string(satisfiesSpellingRule(word)) << std::endl;
}

int main()
{
    std::vector<std::string> testCases
    {
        "fiery",
        "hierarachy",
        "hieroglyphic",
        "ceiling", 
        "inconceivable", 
        "receipt",
        "daily",
        "programmer", 
        "one", 
        "two", 
        "three",
        "sleigh", 
        "stein", 
        "fahrenheit",
        "deifies", 
        "either", 
        "nuclei", 
        "reimburse",
        "ancient", 
        "juicier", 
        "societies",
        "a",
        "zombie",
        "tranceiver",
        "veil",
        "icier"
    };

    for (int i = 0; i < testCases.size(); i++)
    {
        printResults(testCases[i]);
    }
}

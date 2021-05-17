#include <iostream>
#include "DiceRoller.h"

void printResults(string testInput)
{
	DiceRoller diceRoller;

	std::vector<int> rolls = diceRoller.rollDice(testInput);
	int result = diceRoller.getRollTotal(rolls);

	std::cout << "Test Input: " << testInput << std::endl;
	std::cout << "*Rolls Dice*" << std::endl;
	std::cout << "Result: " << result << ": " << rolls[0];

	for (int i = 1; i < rolls.size(); i++)
	{
		std::cout << ", " << rolls[i];
	}

	std::cout << std::endl << std::endl;
}

int main()
{
	string testInput1 = "5d12";
	string testInput2 = "6d4";
	string testInput3 = "1d2";
	string testInput4 = "1d8";
	string testInput5 = "3d6";
	string testInput6 = "4d20";
	string testInput7 = "100d100";

	printResults(testInput1);
	printResults(testInput2);
	printResults(testInput3);
	printResults(testInput4);
	printResults(testInput5);
	printResults(testInput6);
	printResults(testInput7);

	return 0;
}
#pragma once

#include <string>
#include <time.h>
#include <vector>

using std::string;

class DiceRoller
{
	public: 
		int getRollTotal(std::vector<int> rollOutcomes)
		{
			int rollCounter = 0;
			for (int i = 0; i < rollOutcomes.size(); i++)
			{
				rollCounter += rollOutcomes[i];
			}

			return rollCounter;
		}

		std::vector<int> rollDice(string diceInput)
		{
			std::string delimiter = "d";
			int position = diceInput.find(delimiter);
			int numberOfDice = std::stoi(diceInput.substr(0, diceInput.find(delimiter)));
			int numberOfSides = std::stoi(diceInput.substr(position + 1));

			std::vector<int> rollOutcomes;
			srand(time(NULL));

			for (int i = 0; i < numberOfDice; i++)
			{
				int rollOutcome = rollDie(numberOfSides);
				rollOutcomes.push_back(rollOutcome);
			}

			return rollOutcomes;
		}

	private:
		int rollDie(int numberOfSides)
		{			
			int outcome = rand() % numberOfSides + 1;
			return outcome;
		}
};


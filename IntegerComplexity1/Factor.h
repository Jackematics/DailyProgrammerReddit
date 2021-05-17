#pragma once
class Factor
{
public: 
	int smallestFactorPairSum(int n)
	{
		int smallestFactorPairSum = n + 1;

		for (int i = 1; i <= n / 2 + 1; i++)
		{
			if (n % i == 0)
			{
				int factorPairSum = i + n / i;

				if (factorPairSum < smallestFactorPairSum)
				{
					smallestFactorPairSum = factorPairSum;
				}
			}
		}

		return smallestFactorPairSum;
	}
};


using System;
using System.Collections.Generic;
using System.Text;

namespace PossibleNumberOfPies
{
    class Baker
    {
        internal int[] BakeMax(
            int pumpkinFlavouringScoops,
            int apples,
            int eggs,
            int cupsOfMilk,
            int cupsOfSugar)
        {
            var ingredients = new List<int>()
            {
                pumpkinFlavouringScoops,
                apples,
                eggs,
                cupsOfMilk,
                cupsOfSugar
            };

            var ingredientsIntercepts = new List<int[]>();

            for (int i = 0; i < ingredients.Count; i++)
            {
                int[] intercepts = GetIntercepts(i, ingredients[i]);

            }

            return null;
        }

        private int[] GetIntercepts(int equation, int ingredient)
        {
            int[] intercept = new int[2];

            switch(equation)
            {
                case 0:
                    intercept[0] = ingredient;
                    intercept[1] = 0;
                    break;

                case 1:
                    intercept[0] = 0;
                    intercept[1] = ingredient;
                    break;

                case 2:
                    intercept[0] = ingredient / 3;
                    intercept[1] = ingredient / 4;
                    break;

                case 3:
                    intercept[0] = ingredient / 4;
                    intercept[1] = ingredient / 3;
                    break;

                case 4:
                    intercept[0] = ingredient / 3;
                    intercept[1] = ingredient / 2;
                    break;
            }

            return intercept;
        }
    }
}

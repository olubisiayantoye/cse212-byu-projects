using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create an array of size 'length'.
        // 2. Loop from 0 to (length - 1).
        // 3. For each index i, compute number * (i + 1).
        // 4. Store that value in the array.
        // 5. Return the filled array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// Example: RotateListRight([1,2,3,4,5,6,7,8,9], 3) → [7,8,9,1,2,3,4,5,6]
    /// This function modifies the original list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Use GetRange to split the list into two parts:
        //    - Last 'amount' items → rotatedPart
        //    - First part → remainingPart
        // 2. Clear the original list.
        // 3. Add rotatedPart, then remainingPart back to it.

        int count = data.Count;

        // Edge case: No need to rotate if amount == 0 or equal to count
        if (count == 0 || amount % count == 0)
            return;

        List<int> rotatedPart = data.GetRange(count - amount, amount);
        List<int> remainingPart = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);
    }
}


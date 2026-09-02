public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        //Step 1: I will create a fixed size array to hold the results, since I already know exactly how many 
        //multiples I need using the parameter length 
        double[] result = new double[length]; 
        
        //Step 2: From index 0 up to length (not includiing it), loop each position in an array. At each position i
        //calculate the multiple by multipling the number by (i + 1), then store it in result[i]
        for (int i = 0; i < length; i++ )
        {
            result[i] = number * (i + 1);
        }

        return result; //Step 3: Then return the complete array back 
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Step 1: Save the last 'amount' items (these will move to the front) to do so we need to a subtraction 
        //to know how many places we are moving to the front
        List<int> lastAmount = data.GetRange(data.Count - amount, amount);

        //Step 2: Save everything else (that would be the first part of the list as it was originally)
        List<int> firstAmount = data.GetRange(0, data.Count - amount);

        //Step 3: Clear out that original list completely 
        data.RemoveRange(0, data.Count);

        //Step 4:Add the pieces back in the new order, lastAmount then firstAmount 
        data.AddRange(lastAmount);
        data.AddRange(firstAmount);
    }
}

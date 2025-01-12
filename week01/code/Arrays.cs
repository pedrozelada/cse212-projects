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

        // First we create an array to store the numbers
        var result = new double[length];
        //the for structure is used to iterate over the array
         for (int i = 0; i < result.Length; i++)
         {
        // The multiple of the number is inserted according to its position 
            result[i] = number * (i + 1);
         }
        // The array is returned with the multiples
        return result; // replace this return statement with your own
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

        // In case the list is empty, or the number of rotations is 0 or less than 0 
        // or the number of rotations is greater than the number of elements in the list
        if ( data.Count == 0 || amount <= 0 || amount >= data.Count)
        return;
       
        // We subtract two sublists
        // The last amount elements
        List<int> sublista1 = data.GetRange(data.Count - amount, amount);  
        // The rest of the list
        List<int> sublista2 = data.GetRange(0, data.Count - amount); 

        // We clear the list and add the two sublists
        data.Clear();  
        data.AddRange(sublista1);  
        data.AddRange(sublista2);  

    }
}

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3) 
        => (!AreEqual(side1, side2) && !AreEqual(side1, side3) && !AreEqual(side2, side3))
        && !HasZeroSide(side1, side2, side3)
        && isValidTriangle(side1, side2, side3); 

    public static bool IsIsosceles(double side1, double side2, double side3) 
        => (IsEquilateral(side1, side2, side3) 
         || (AreEqual(side1, side2) && !AreEqual(side1, side3)) 
         || (AreEqual(side1, side3) && !AreEqual(side1, side2)) 
         || (AreEqual(side2, side3) && !AreEqual(side1, side3)))  
        && !HasZeroSide(side1, side2, side3) 
        && isValidTriangle(side1, side2, side3);

    public static bool IsEquilateral(double side1, double side2, double side3) 
        => (AreEqual(side1, side2) && AreEqual(side1, side3) && AreEqual(side2, side3))
        && !HasZeroSide(side1, side2, side3)
        && isValidTriangle(side1, side2, side3); 
    
    private static bool AreEqual(double side1, double side2)
        => side1 == side2;
    private static bool HasZeroSide(double side1, double side2, double side3)
        => side1 == 0 || side2 ==0 || side3 ==0;
    private static bool isValidTriangle(double side1, double side2, double side3)
        => (side1 + side2 >= side3) && (side2 + side3 >= side1) && (side1 + side3 >= side2); 
}
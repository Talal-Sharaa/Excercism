public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int xTopRow = 0;
        int xLeft = 0;
        int xBottomRow = size-1;
        int xRight = size-1;
        int xNum = 1;
        int[,] xMatrix = new int[size, size];
        while(xTopRow<=xBottomRow && xLeft<=xRight){
        for(int i = xLeft; i<=xRight; i++){
            xMatrix[xTopRow, i] = xNum;
            xNum++;
        }
        xTopRow++;
        for(int i = xTopRow; i<= xBottomRow; i++){
            xMatrix[i, xRight] = xNum;
            xNum++;
        }
        xRight--;
        for(int i = xRight; i>=xLeft; i--){
            xMatrix[xBottomRow, i] = xNum;
            xNum++;
        }
        xBottomRow--;
        for(int i = xBottomRow; i>= xTopRow; i--){
            xMatrix[i, xLeft] = xNum;
            xNum++;
        }
        xLeft++;
    }
        return xMatrix;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        int ax1 = -3;int ay1 = 0;int ax2 = 3;int ay2 = 4;
        int bx1 = 0;int by1 = -1;int bx2 = 9;int by2 = 2;
        Console.WriteLine("Общая площадь прямоугольников: "+(GetArea(ax1,ax2,ay1,ay2)+GetArea(bx1,bx2,by1,by2)));
    }
    public static int GetArea(int x1,int x2,int y1,int y2)
    {
        return Math.Abs(x1 - x2) * Math.Abs(y1 - y2);
    }
}
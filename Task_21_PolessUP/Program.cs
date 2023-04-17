using System.Runtime.Intrinsics.X86;

internal class Program
{
    private static void Main(string[] args)
    {
        int ax1 = -3; int ay1 = 0; int ax2 = 3; int ay2 = 4;
        int bx1 = 0; int by1 = -1; int bx2 = 9; int by2 = 2;
        Console.WriteLine(GetRec(ax1,ay1,ax2,ay2,bx1,by1,bx2,by2));
    }
    public static int GetArea(int x1, int x2, int y1, int y2)
    {

        return Math.Abs(x1 - x2) * Math.Abs(y1 - y2);
    }
    public static int GetRec(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
    {
        if (ax2 < bx1 || //первый левее второго
           ax1 > bx2 ||          //первый правее второго
           ay1 > by2 ||          //первый выше второго
           ay2 < by1)          //первый ниже второго
        {
            return (GetArea(ax1, bx2, ay1, ay2) + GetArea(bx1, bx2, by1, by2));
        }
        else
        {
            int cx1 = 0;int cy1 = 0;int cx2 = 0;int cy2 = 0;
            if (CheckPoint(ax1, ax2, ay1, ay2, bx1, by1))
            {
                cx1 = bx1;cy1 = by1;
                FindSecondPoint(bx1,bx2,by1,by2,ax1,ax2,ay1,ay2,ref cx2,ref cy2);
            }
            if (CheckPoint(ax1, ax2, ay1, ay2, bx1, by2))
            {
                cx1 = bx1;cy1 = by2;
                FindSecondPoint(bx1, bx2, by1, by2, ax1, ax2, ay1, ay2, ref cx2, ref cy2);
            }
            if (CheckPoint(ax1, ax2, ay1, ay2, bx2, by2))
            {
                cx1 = bx2;cy1 = by2;
                FindSecondPoint(bx1, bx2, by1, by2, ax1, ax2, ay1, ay2, ref cx2, ref cy2);
            }
            if (CheckPoint(ax1, ax2, ay1, ay2, bx2, by1))
            {
                cx1 = bx2;cy1 = by1;
                FindSecondPoint(bx1, bx2, by1, by2, ax1, ax2, ay1, ay2, ref cx2, ref cy2);
            }



            int per = GetArea(cx1, cx2, cy1, cy2);

            return GetArea(ax1, ax2, ay1, ay2)+ GetArea(bx1, bx2, by1, by2) - per;



        }

    }  
    public static bool CheckPoint(int ax1,int ax2,int ay1,int ay2,int cx,int cy)
    {
        if (cx >= ax1 && cx <= ax2 && cy <= ay2 && cy >= ay1)
        {
            return true;
        }
        else return false;
    }
    public static void FindSecondPoint(int bx1, int bx2, int by1, int by2, int ax1, int ax2, int ay1, int ay2, ref int cx2, ref int cy2)
    {
        if (CheckPoint(bx1, bx2, by1, by2, ax1, ay1))
        {
            cx2 = ax1; cy2 = ay1;
        }
        if (CheckPoint(bx1, bx2, by1, by2, ax1, ay2))
        {
            cx2 = ax1; cy2 = ay2;
        }
        if (CheckPoint(bx1, bx2, by1, by2, ax2, ay2))
        {
            cx2 = ax2; cy2 = ay2;
        }
        if (CheckPoint(bx1, bx2, by1, by2, ax2, ay1))
        {
            cx2 = ax2; cy2 = ay1;
        }
    }
}
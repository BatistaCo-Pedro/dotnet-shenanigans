namespace SOLID;

public class Rectangle
{
    public double Height { get; set; }
    public double Width { get; set; }
}

public class Circle
{
    public double Radius { get; set; }
}

public class AreaCalculator
{
    public double TotalArea(object[] arrObjects)
    {
        double area = 0;
        Circle objCircle;
        foreach (var obj in arrObjects)
        {
            if (obj is Rectangle objRectangle)
            {
                area += objRectangle.Height * objRectangle.Width;
            }
            else
            {
                objCircle = (Circle)obj;
                area += objCircle.Radius * objCircle.Radius * Math.PI;
            }
        }
        return area;
    }
}

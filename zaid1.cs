namespace Complete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Complete;
    using static Complete.CircleShape.UnsopportedShapeException;
    using static Complete.RectangleShape.UnsopportedShapeException;
    using static Complete.SquareShape.UnsopportedShapeException;
    using static Complete.WrongParamCountException;
    using UnsopportedShapeException = Complete.CircleShape.UnsopportedShapeException;

    //Here I Define enum For Soported ShapeType 
    namespace Complete
    {
        public enum ShapeType
        {
            Circle1 = 5,
            Rectangle1 = 6,
            Square1 = 7,
            Ellipse = 1,//This is Define Only For Test Code
            Polygon = 2,//This is Define Only For Test Code
            Triangle = 3,//This is Define Only For Test Code
        }
    }
    //Here iShape Interface Creating Shape
    namespace Complete
    {
        public interface iShape
        {
            void GetShape();
        }
    }
    namespace Complete
    {
        public class WrongParamCountException : Exception
        {
            public WrongParamCountException() { }
            public WrongParamCountException(string message) : base(String.Format("Wrong Parameter Pass....", message))
            {
            }
            //ShapeFactory Class
            public class Circle : iShape
            {
                Double x;
                Double y;
                Double pi = Math.PI;
                Double area;
                Double perimeter;
                float radius;
                public Circle(float radius)
                {
                    this.radius = radius;
                    this.perimeter = perimeter;
                    this.area = area;
                    if (radius < 0)
                    {
                        throw new WrongParamCountException();
                    }
                    else
                    {
                        area = pi * (radius * radius);
                        perimeter = 2 * pi * radius * radius;
                    }
                }
                public void GetShape()
                {
                    Console.WriteLine("Circle Created Successfully....");
                    Console.WriteLine("Area of Circle=" + area);
                    Console.WriteLine("Perimeter of Circle=" + perimeter);

                }
            }
        }
    }
    namespace Complete
    {
        //ShapeFactory Class
        public class Rectangle : iShape
        {
            public Rectangle(float length, float width)
            {

            }
            public void GetShape()
            {
                Console.WriteLine("Rectangle created Successfully....");
            }
        }
    }
    namespace Complete
    {
        //ShapeFactory Class
        public class Square : iShape
        {
            float edge;

            public Square()
            {
            }

            Square(float edge)
            {
                this.edge = edge;
            }
            public void GetShape()
            {
                Console.WriteLine("Square Created Successfully....");
            }
        }
    }
    //In Shape Factory Method iShape Can Create Many Kind of Shape But We Want to Create only Geometric Shape So Here In ShapeFactory there are geoiShapeFactory Interface That Have Method of iShape
    namespace Complete
    {
        public interface geoiShapeFactory
        {

            iShape GetShape(ShapeType shapeType);

        }
    }
    namespace Complete.CircleShape
    {
        public class UnsopportedShapeException : Exception
        {
            public UnsopportedShapeException() { }
            public UnsopportedShapeException(string name) : base(String.Format("Invalid Shape Type", name))
            {

            }

            //ShapeFactory Class For Creating CircleShape
            public class CircleShape : geoiShapeFactory
            {
                public iShape GetShape(ShapeType shapeType)
                {
                    if (shapeType != ShapeType.Circle1 && shapeType != ShapeType.Rectangle1 && shapeType != ShapeType.Square1)
                    {

                        throw new UnsopportedShapeException("Invalid Shapetype....");
                    }
                    else
                        try
                        {
                            return new Circle(4);
                        }
                        catch (WrongParamCountException ex)
                        {
                            throw new WrongParamCountException(ex.Message);
                        }

                }
            }
        }
    }
    namespace Complete.RectangleShape
    {
        public class UnsopportedShapeException : Exception
        {
            public UnsopportedShapeException() { }
            public UnsopportedShapeException(string name) : base(string.Format("invalid shape type", name))
            {

            }
             //ShapeFactory Class For Creating RectangleShape
            public class RectangleShape : geoiShapeFactory
            {
                public iShape GetShape(ShapeType shapeType)
                {
                    if (shapeType != ShapeType.Circle1 && shapeType != ShapeType.Rectangle1 && shapeType != ShapeType.Square1)
                    {
                        throw new UnsopportedShapeException();
                    }
                    else
                    {
                        return new Rectangle(4, 6);
                    }

                }
            }
        }
    }
    namespace Complete.SquareShape
    {
        public class UnsopportedShapeException : Exception
        {
            public UnsopportedShapeException() { }
            public UnsopportedShapeException(string name) : base(String.Format("Invalid Shape Type", name))
            {

            }
             //ShapeFactory Class For Creating SquareShape
            public class SquareShape : geoiShapeFactory
            {
                public iShape GetShape(ShapeType shapeType)
                {
                    if (shapeType != ShapeType.Circle1 && shapeType != ShapeType.Rectangle1 && shapeType != ShapeType.Square1)
                    {

                        throw new UnsopportedShapeException("Invalid Shape Type....");
                    }
                    else
                    {
                        return new Square();
                    }

                }
            }
        }
    }
public class Program
{
    static void Main(string[] args)
    {
         try
         {
            //Here Client Enter Shapes Which He/She Want Like->Rectangle1,Circle1,Square1, Except Ellipse,Polygon,Triangle
              geoiShapeFactory shapeFactory = new RectangleShape();
              iShape shape = shapeFactory.GetShape(ShapeType.Rectangle1);
            
              geoiShapeFactory shapeFactory1 = new CircleShape();
              iShape shape1 = shapeFactory1.GetShape(ShapeType.Circle1);

              geoiShapeFactory shapefactory3 = new SquareShape();
              iShape shape2 = shapefactory3.GetShape(ShapeType.Square1);

              shape.GetShape();

              shape1.GetShape();

              shape2.GetShape();
         }
         catch (UnsopportedShapeException e)
         {
              Console.WriteLine(e.Message);
         }
         catch (WrongParamCountException ex)
         {
              Console.WriteLine(ex.Message);
         }
              Console.ReadKey();
              Console.ReadKey();
              Console.ReadKey();
         }
    }
}



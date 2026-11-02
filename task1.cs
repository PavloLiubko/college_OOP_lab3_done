namespace lab3
{

    class Rhombus
    {

        private double side;

        private double[] diagonals = new double[2];

        private string color;

        Rhombus(double Side, double[] Diagonals, string Color)
        {

            side = Side;
            diagonals = Diagonals;
            color = Color;

        }

        Rhombus(double Side, double[] Diagonals)
        {

            side = Side;
            diagonals = Diagonals;
            color = "White";

        }

        public double getPerimeter()
        {

            return side * 4;

        }

        public double getArea()
        {

            return 0.5 * diagonals[0] * diagonals[1];

        }

        public double getSide()
        {

            return side;

        }

        public void setSide(double Side)
        {

            if (side >= 0)
            {
                side = Side;
            }
        }

        public double[] getDiagonals()
        {

            return [diagonals[0], diagonals[1]];

        }

        public void setDiagonal(double diagonal1, double diagonal2)
        {
            if (diagonal1 >= 0 && diagonal2 >= 0)
            {
                diagonals[0] = diagonal1;
                diagonals[1] = diagonal2;
            }
        }

        public string getColor()
        {

            return color;

        }

        public void setColor(string Color)
        {
            if (Color != "")
            {
                color = Color;
            }
        }

        public void Show()
        {

            Console.Write($" Rhombus' side: {side} \n Rhombus' diagonals: {diagonals[0]}, {diagonals[1]} \n Rhombus' color: {color} ");

        }


        public static void Main(string[] args)
        {

            Rhombus romb = new Rhombus(5, [3,4], "Red");

            romb.setColor("Green");
            romb.setDiagonal(6, 8);
            romb.setSide(10);

            Console.WriteLine(romb.getColor());
            Console.WriteLine($"{romb.getDiagonals()[0]}, {romb.getDiagonals()[1]} ");
            Console.WriteLine(romb.getSide());

            Console.WriteLine(romb.getPerimeter());
            Console.WriteLine(romb.getArea());


        }

    }
}

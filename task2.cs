using System.Drawing;
using System.Numerics;

namespace lab3 {

    class vector
    {

        private double x;
        private double y;
        private double z;
        private int coundition; // 0 - good, 1 - error 

        public vector (double X, double Y, double Z, int Coundition)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
            this.coundition = Coundition;
        }

        public vector() {

            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.coundition = 0;

        }

        public vector(double num)
        {

            this.x = num;
            this.y = num;
            this.z = num;
            this.coundition = 0;

        }

        vector(double[] nums)
        {

            this.x = nums[0];
            this.y = nums[1];
            this.z = nums[2];
            this.coundition = 0;

        }

        public vector(vector OtherVector) { 
        
            this.x = OtherVector.x;
            this.y = OtherVector.y;
            this.z = OtherVector.z;

        }

        ~vector() {

            Console.WriteLine($"Vector was deleted. Destructor`s conditions had code {this.coundition}");
        
        }

        public void MakeStandard(int coordinateNum) {

            if (coordinateNum > 3 || coordinateNum <= 0)
            {

                Console.WriteLine("Error: this coordinate doesn't exist.");

            }

            else {

                switch (coordinateNum) { 
                
                    case 1:
                        this.x = 0;
                        break;

                    case 2:
                        this.y = 0;
                        break;


                    case 3:
                        this.z = 0;
                        break;
                }
            
            }
        
        }

        public double getCoordinate(char coor) {


            switch (coor)
            {

                case 'x':
                    return this.x;

                case 'y':
                   return this.y;

                case 'z':
                    return this.z;

                default: return 0;

            }


        }

        public void setCoordinate(int coorNum, double value) {


            switch (coorNum)
            {

                case 1:
                    this.x = value;
                    break;

                case 2:
                    this.y = value;
                    break;

                case 3:
                    this.z = value;
                    break;

                default: 
                    Console.WriteLine("Error, this coordinate doesn't exist");
                    break;

            }


        }

        public void print() {

            Console.Write($"Vector`s coordinates: \n x: {this.x} \n y: {this.y} \n z: {this.z} \n Vector condition code: {this.coundition}");
            Console.WriteLine(' ');
        
        }

        public static vector SumVector(vector Vector1, vector Vector2) {

            return new vector(Vector1.x + Vector2.x, Vector1.y + Vector2.y, Vector1.z + Vector2.z, 0);
        
        }

        public static vector MinusVector(vector Vector1, vector Vector2)
        {

            return new vector(Vector1.x - Vector2.x, Vector1.y - Vector2.y, Vector1.z - Vector2.z, 0);

        }

        public static vector TimeVector(vector Vector1, vector Vector2)
        {

            return new vector(Vector1.y* Vector2.z - Vector1.z*Vector2.y, Vector1.z*Vector2.x - Vector1.x* Vector2.z, Vector1.x*Vector2.y - Vector1.y*Vector2.x, 0);

        }

        public static vector DivisionByNumber(vector Vector, Int16 Num) {

            if (Num == 0) { 
            
                return new vector(Vector.x, Vector.y, Vector.z, 1);
            
            }

            return new vector((Vector.x/Num), (Vector.y/Num), (Vector.z/Num), 0);


        }

        public static bool CompareVectors(vector Vector1, vector Vector2)
        {
            // true -> bigger, false -> lesser
            if (Vector1.x > Vector2.x && Vector1.y > Vector2.y && Vector1.z > Vector2.z)
            {

                return true;

            }

            else {

                return false;
            
            }
        }

        public static void Main(string[] args) { 
        
            vector firstVector  = new vector(1, 2, 3, 0);
            firstVector.print();

            firstVector.MakeStandard(1);
            firstVector.print();


            Console.WriteLine($" Your coordinate z: {firstVector.getCoordinate('z')}");

            firstVector.setCoordinate(3, 99);
            Console.WriteLine($" Your new coordinate z: {firstVector.getCoordinate('z')}");
            firstVector.print();

            vector SecondVector = new vector(123, 123, 123, 0);

            vector resVectorSum = vector.SumVector(firstVector, SecondVector);
            Console.WriteLine("Vector sum:");
            resVectorSum.print();

            vector resVectorMinus = vector.MinusVector(firstVector, SecondVector);
            Console.WriteLine("Vector minused:");
            resVectorMinus.print();

            vector resVectorTime = vector.TimeVector(firstVector, SecondVector);
            Console.WriteLine("Vector timed:");
            resVectorTime.print();

            vector resVectorDivision = vector.DivisionByNumber(firstVector, 2);
            Console.WriteLine("Vector divisioned:");
            resVectorDivision.print();

            bool isEqueal = vector.CompareVectors(firstVector, SecondVector);
            Console.WriteLine($"Are two vectors equal? Answer:{isEqueal}");
        }

    }

}

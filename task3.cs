namespace lab3 {

    class matrix { 
    
        private int rows;
        private int columns;
        private int errorCode; // 0 -> good, 1 -> error
        private int value;

        private int[,] matrixBase;

        matrix(int Rows, int Columns, int Value) {

            this.rows = Rows;
            this.columns = Columns;
            this.matrixBase = new int[Rows, Columns];
            this.value = Value;
            this.errorCode = 0;

            for (int i = 0; i < columns; i++) {

                for (int j = 0; j < rows; j++) { 
                
                    matrixBase[i, j] = value;
                
                }
            
            }
        }

        matrix() { 
        
            this.rows = 2; 
            this.columns = 2;
            this.matrixBase = new int[,] { { 0, 0 }, { 0, 0 } };
            this.errorCode = 0;

        }

        matrix(int n) {

            this.rows = n;
            this.columns = n;
            this.value = 0;
            this.errorCode = 0;
            this.matrixBase = new int[rows, columns];

            for (int i = 0; i < columns; i++)
            {

                for (int j = 0; j < rows; j++)
                {

                    matrixBase[i, j] = value;

                }

            }

        }

        matrix(int n, int m)
        {

            this.rows = n;
            this.columns = m;
            this.value = 0;
            this.errorCode = 0;
            this.matrixBase = new int[rows, columns];


            for (int i = 0; i < columns; i++)
            {

                for (int j = 0; j < rows; j++)
                {

                    matrixBase[i, j] = value;

                }

            }

        }

        matrix(matrix OtherMatrix)
        {

            this.rows = OtherMatrix.rows;
            this.columns = OtherMatrix.columns;
            this.matrixBase = OtherMatrix.matrixBase;
            this.errorCode = OtherMatrix.errorCode;

        }

        ~matrix() {

            matrixBase = null;
            Console.WriteLine("Matrix was deleted");

        }

        public void SetMatrixValue(int coor1, int coor2, int value) {

            matrixBase[coor1, coor2] = value;
        
        }

        public int GetMatrixValue(int coor1, int coor2) { 
        
            return matrixBase[coor1, coor2];
        
        }

        public int GetMatrixRows()
        {

            return this.rows;

        }

        public int GetMatrixColumns()
        {

            return this.columns;

        }

        public int GetMatrixErrorCode()
        {

            return this.errorCode;

        }

        public void SetMatrixStandardValue(int coor1, int coor2)
        {

            matrixBase[coor1, coor2] = 0;

        }

        public void PrintMatrix() {

            for (int i = 0; i < this.columns; i++)
            {

                for (int j = 0; j < this.rows; j++)
                {

                    Console.Write($"{this.matrixBase[i, j]} \t");

                }

                Console.WriteLine();

            }

            Console.WriteLine() ;

        }

        public static matrix SumMatrices(matrix matrix1, matrix matrix2) {

            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns) {

                Console.WriteLine("В матриць різні довжини колонок та рядків, операція неможлива.");

                return null;
            
            }

            matrix resultMatrix = new matrix(matrix1.columns, matrix1.rows);

            for (int i = 0; i < matrix1.columns; i++)
            {

                for (int j = 0; j < matrix1.rows; j++)
                {

                    resultMatrix.matrixBase[i, j] = matrix1.matrixBase[i, j] + matrix2.matrixBase[i, j];


                }


            }

            return resultMatrix;

        }

        public static matrix MinusMatrices(matrix matrix1, matrix matrix2)
        {

            if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            {

                Console.WriteLine("В матриць різні довжини колонок та рядків, операція неможлива.");

                return null;

            }

            matrix resultMatrix = new matrix(matrix1.columns, matrix1.rows);

            for (int i = 0; i < matrix1.columns; i++)
            {

                for (int j = 0; j < matrix1.rows; j++)
                {

                    resultMatrix.matrixBase[i, j] = matrix1.matrixBase[i, j] - matrix2.matrixBase[i, j];

                }


            }

            return resultMatrix;

        }

        public static matrix MultiplyMatrices(matrix matrix1, matrix matrix2)
        {
            if (matrix1.columns != matrix2.rows)
            {

                Console.WriteLine("Помилка: операція неможлива");
                return null;
            
            }

            matrix result = new matrix(matrix1.rows, matrix2.columns);

            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix2.columns; j++)
                {
                    for (int n = 0; n < matrix1.columns; n++)
                    {
                        result.matrixBase[i, j] += matrix1.matrixBase[i, n] * matrix2.matrixBase[n, j];
                    }
                }
            }

            return result;
        }

        public static void ScalarTime(matrix Matrix, int Number)
        {

            if (Number == 0)
            {

                Console.WriteLine("Помилка: ділення на 0 неможливе!");
                Matrix.errorCode = 1;

            }

            for (int i = 0; i < Matrix.columns; i++)
            {

                for (int j = 0; j < Matrix.rows; j++)
                {

                    Matrix.matrixBase[i, j] *= Number;

                }

            }

        }

        public static void ScalarDivision(matrix Matrix, int Number) {

            if (Number == 0) { 
            
                Console.WriteLine("Помилка: ділення на 0 неможливе!");
                Matrix.errorCode = 1;
            
            }

            for (int i = 0; i < Matrix.columns; i++) {

                for (int j = 0; j < Matrix.rows; j++) {

                    Matrix.matrixBase[i, j] /= Number;
                
                }
            
            }
        
        }


        public static bool CompareMatrices(matrix matrix1, matrix matrix2) {

            if (matrix1.columns != matrix2.columns || matrix1.rows != matrix2.rows) {

                Console.WriteLine("Помилка: такі матриці не можна порівняти");
                return false;
            
            }

            bool isBigger = true;

            for (int i = 0; i < matrix1.columns; i++) {

                for (int j = 0; j < matrix1.rows; j++) {

                    if (matrix1.matrixBase[i, j] <= matrix2.matrixBase[i, j]) { 
                    
                        isBigger = false;
                    
                    }
                
                }
            
            }

            return isBigger;
        
        }

        public static void Main(string[] args) {

            Console.WriteLine("Base matrix:");

            matrix testMatrix2 = new matrix(3, 3, 67);
            testMatrix2.PrintMatrix();

            Console.WriteLine("No arguments matrix:");

            matrix testMatrix1 = new matrix();
            testMatrix1.PrintMatrix();

            Console.WriteLine("One argument matrix:");
            matrix testMatrix3 = new matrix(5);
            testMatrix3.PrintMatrix();

            Console.WriteLine("Copied first matrix:");
            matrix testMatrix1Copy = new matrix(testMatrix2);
            testMatrix3.PrintMatrix();

            Console.WriteLine("Changed first matrix:");
            testMatrix2.SetMatrixValue(0, 0, 999);
            testMatrix2.SetMatrixStandardValue(0, 1);
            testMatrix2.PrintMatrix();
            Console.WriteLine($"New elements: {testMatrix2.GetMatrixValue(0, 0)} and {testMatrix2.GetMatrixValue(0, 1)} \n");

            Console.WriteLine("New matrix:");

            matrix newMatrix = new matrix(3, 3, 105);
            newMatrix.PrintMatrix();

            Console.WriteLine("Sum of the new and first matrices:");

            matrix sumResult = matrix.SumMatrices(newMatrix, testMatrix2);
            sumResult.PrintMatrix();

            Console.WriteLine("Difference of the new and first matrices:");

            matrix difResult = matrix.MinusMatrices(newMatrix, testMatrix2);
            difResult.PrintMatrix();

            Console.WriteLine("New matrix timed by first matrix:");

            matrix dobResult = matrix.MultiplyMatrices(newMatrix, testMatrix2);
            dobResult.PrintMatrix();

            Console.WriteLine("New matrix timed by scalar:");

            matrix.ScalarTime(newMatrix, 33);
            newMatrix.PrintMatrix();

            Console.WriteLine("New matrix devided on scalar:");

            matrix.ScalarDivision(newMatrix, 65);
            newMatrix.PrintMatrix();

            Console.WriteLine("Is new matrix bigger that first? Answer:");

            Console.WriteLine(matrix.CompareMatrices(newMatrix, testMatrix2));
           
        }


    }

}

using System;

class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Tarefa 1\r\n");
        Console.WriteLine("select [Departamento].[Nome] as Departamento, [Pessoa].Nome as Pessoa, [Pessoa].Salario \r\n  from [Departamento] join [Pessoa] \r\n  on [Pessoa].Id = (select top 1 Id from [Pessoa] where [Pessoa].DeptId = [Departamento].Id order by Salario desc)");
        Console.WriteLine("\r\nTarefa 2\r\n");

        Console.WriteLine("Cenário 1");
        int[] array1 = { 3, 2, 1, 6, 0, 5 };
        GetTree(array1);

        int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };
        Console.WriteLine("\r\nCenário 2");
        GetTree(array2);

        string GetSpaces(int num)
        {
            string res = "";
            for (int i = 0; i < num; i++)
            {
                res += " ";
            }
            return res;
        }

        void GetTree(int[] array)
        {
            var root = array.Max();

            var position = Array.FindIndex(array, row => row == root);

            var left = array.Take(position).OrderByDescending(x => x).ToArray();

            var right = array.Skip(position + 1).OrderByDescending(x => x).ToArray();


            Console.WriteLine("Array de entrada: [{0}]", string.Join(", ", array));
            Console.WriteLine("Raiz: {0}", root);
            Console.WriteLine("Galhos da esquerda: {0}", string.Join(", ", left));
            Console.WriteLine("Galhos da direita: {0}", string.Join(", ", right));

            var count = Math.Max(left.Length, right.Length);
            Console.WriteLine("{0}", GetSpaces(count) + root);

            for (int i = 0; i < count; i++)
            {
                string stringLeft = "";
                string stringRight = "";
                if (i < left.Length)
                {
                    stringLeft += left[i];
                }
                if (i < right.Length)
                {
                    stringRight += right[i];
                }


                Console.WriteLine(GetSpaces(count - i) + (string.IsNullOrEmpty(stringLeft) ? " " : "/") + (string.IsNullOrEmpty(stringRight) ? "" : GetSpaces(3 * i) + "\\"));
                Console.WriteLine("{0}{1}", GetSpaces(count - i - 1) + (string.IsNullOrEmpty(stringLeft) ? " " : stringLeft), GetSpaces(3 * i + 2) + stringRight);
            }
        }
    }





}
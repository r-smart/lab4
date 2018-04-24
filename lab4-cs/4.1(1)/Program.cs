using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4._1_1_
{
    public class RPN {
  
    static private bool IsOperator(char c)
    {
        return '+' == c || '-' == c || '/' == c || '*' == c;
    }
    static private bool IsDelimeter(char c)
    {
        return ' ' == c;
    }

    public static double parse(Char[] rpnString)
    {
        double result = 0;
        Stack<Double> temp = new Stack<Double>();
        for (int i = 0; i < rpnString.Length; i++)
        {
            if (rpnString[i] == '=') continue;
            if (!Char.IsDigit(rpnString[i]) && !IsDelimeter(rpnString[i]) && !IsOperator(rpnString[i])) {
                Console.WriteLine("Not");
                break;
            }
            if (IsDelimeter(rpnString[i])){
                continue;
            }
            if (i<rpnString.Length-1 && Char.IsDigit(rpnString[i+1]) && IsOperator(rpnString[i]))
            {
                String a = "" + rpnString[i];
                i++;
                while (!IsDelimeter(rpnString[i]) && !IsOperator(rpnString[i]))
                {
                    a += rpnString[i];
                    i++;
                    if (i == rpnString.Length) break;
                }
                temp.Push(Convert.ToDouble(a));
            }
            if (Char.IsDigit(rpnString[i]))
            {
                String a = "";
                while (!IsDelimeter(rpnString[i]) && !IsOperator(rpnString[i]))
                {
                    a += rpnString[i];
                    i++;
                    if (i == rpnString.Length) break;
                }
                temp.Push(Convert.ToDouble(a));
                i--;
            }
            else if (IsOperator(rpnString[i]))
            {
                double a = 0;
                double b = 0;
                a = temp.Pop();
                b = temp.Pop();

                switch (rpnString[i])
                {
                    case '+': result = b + a; break;
                    case '-': result = b - a; break;
                    case '*': result = b * a; break;
                    case '/': try{
                        if (a==0) {throw new ArithmeticException();}
                        result = b / a;
                    }
                    catch (ArithmeticException ) {
                        throw new ArithmeticException();
                    } 
                    break;
                }
                temp.Push(result);
            }
        }
        return temp.Peek();
    }
    public static void Main(String[] args){
        string a = "";
        bool num = false;
        int k = 0;
        int[] numbers = new int [20];
        char[] b = new char[50];
        string filename = "D:\\my\\Andrew\\4\\4.1(1)\\in.txt";
        StreamReader ks = new StreamReader(filename, Encoding.GetEncoding(1251));
        a = ks.ReadLine();
        char[] chars = a.ToArray();
        for (int i = 0; i < a.Length; i++)
        {
            num = false;
            if (Char.IsLetter(chars[i]))
            {
                for (int g = 0; g < b.Length; g++)
                {
                    if (chars[i] == b[g])
                    {
                        chars[i] = Convert.ToChar(numbers[g]);
                        num = true;
                    }
                }
                if (num == true) continue;
                Console.WriteLine("Введiть число");
                b[k] = chars[i];
                chars[i] = Convert.ToChar(Console.ReadLine());
                numbers[k] = Convert.ToInt32(chars[i]);
                k++;
            }
        }
            Console.WriteLine(parse(chars));
        /*try{
            Console.WriteLine(parse("12 2 -3 1 * 10 -5 / + * +"));
        }
        catch (ArithmeticException ){
            Console.WriteLine("division by zero");
        }*/
        Console.ReadKey();  
    }
}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            int problemId = 001;

            switch (problemId)
            {
                case 001:
                    problem_001();
                    break;
                case 002:
                    problem_002();
                    break;
                case 003:
                    problem_003();
                    break;
                case 004:
                    problem_004();
                    break;
                case 005:
                    problem_005();
                    break;
                case 006:
                    problem_006();
                    break;
                case 007:
                    problem_007();
                    break;
                case 008:
                    problem_008();
                    break;
                default:
                    break;
            }

            Console.ReadLine(); 
        }

        static void problem_001()
        {
            /**
            If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
            The sum of these multiples is 23.
            Find the sum of all the multiples of 3 or 5 below 1000.
            */

            // The upper limit. 
            int limit = 1000;
            // The two dividers and their least common multiple. 
            int divider1 = 3;
            int divider2 = 5;
            int divider3 = 15;

            // Amount of multiples of 3, 5 and 15.
            int amountOfMultiples1 = (limit - 1) / divider1;
            int amountOfMultiples2 = (limit - 1) / divider2;
            int amountOfMultiples3 = (limit - 1) / divider3;
            //Console.WriteLine("Amount " + amountOfMultiples1 + " " + amountOfMultiples2 + " " + amountOfMultiples3);

            // Calculation of sum of the Arithmetic progression.
            int sum1 = amountOfMultiples1 * (divider1 + divider1 * amountOfMultiples1) / 2;
            int sum2 = amountOfMultiples2 * (divider2 + divider2 * amountOfMultiples2) / 2;
            int sum3 = amountOfMultiples3 * (divider3 + divider3 * amountOfMultiples3) / 2;
            //Console.WriteLine("Sums " + sum1 + " " + sum2 + " " + sum3);

            // Finding the sum of all the multiples of 3 or 5 below 1000.
            int sum = sum1 + sum2 - sum3;
            Console.WriteLine("Sum " + sum);
        }

        static void problem_002()
        {
            /**
            Each new term in the Fibonacci sequence is generated by adding the previous two terms. 
            By starting with 1 and 2, the first 10 terms will be:
            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            By considering the terms in the Fibonacci sequence whose values do not exceed four million, 
            find the sum of the even-valued terms.
            */

            double limit = 4000000; // Upper limit.
            double sum = 2; // Initial sum of even Fibonacci terms <= 2.

            // The first, second and third terms.
            double a = 1;
            double b = 2;
            double c;

            do
            {
                // Calculate next terms. 
                c = a + b;
                a = b;
                b = c;

                // Add the term to the sum if it is even. 
                if (c % 2 == 0) sum += c;

                // Repeat until the upper limit. 
            } while (c <= limit);

            // Print the result.
            Console.WriteLine(sum);
        }

        static void problem_003()
        {
            /**
            The prime factors of 13195 are 5, 7, 13 and 29.
            What is the largest prime factor of the number 600851475143 ?
            */

            // Container for the prime numbers and the first prime added into it (e.g. 2). 
            List<double> primes = new List<double>();
            primes.Add(2);

            // The given number. 
            double givenNumber = 600851475143;
            double halfOfGivenNumber = givenNumber / 2;
            double largestPrimeFactor = 1;

            for (double checkNumber = 3; checkNumber <= halfOfGivenNumber; checkNumber += 2)
            {
                bool isPrime = true;
                double sqrtCheckNumber = Math.Sqrt(checkNumber);

                double primesCount = primes.Count;
                for (int j = 0; j < primesCount; j++)
                {
                    if (primes[j] > sqrtCheckNumber) break;

                    if (checkNumber % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(checkNumber);

                    if (givenNumber % checkNumber == 0)
                    {
                        givenNumber /= checkNumber;
                        largestPrimeFactor = checkNumber;
                    }
                }

                if (givenNumber == 1) break;
            }

            Console.WriteLine(largestPrimeFactor);
        }

        static void problem_004()
        {
            /**
            A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
            Find the largest palindrome made from the product of two 3-digit numbers.
            */

            for (int i = 999; i > 800; i--)
            {
                bool found = false;

                for (int j = i; j > 800; j--)
                {
                    int number = i * j;

                    // Number to string. 
                    string numberToString = number.ToString();
                    // Reverse of the number. 
                    char[] charArray = numberToString.ToCharArray();
                    Array.Reverse(charArray);
                    string reverseNumToString = new string(charArray);

                    if (numberToString == reverseNumToString)
                    {
                        Console.WriteLine(i + " * " + j + " = " + numberToString);
                        found = true;
                        break;
                    }
                }

                if (found) break;
            }
        }

        static void problem_005()
        {
            /**
            2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
            What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
            */

            int max = 20; // The max number we want to have as a divider. 
            int number = 1; // The smallest positive number we search for. 

            // List of numbers from 2 to max. 
            List<int> dividers = new List<int>();
            for (int i = 2; i <= max; i++) dividers.Add(i);

            // Here we let only the needed factors to remain. 
            for (int i = 0; i < dividers.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (dividers[i] % dividers[j] == 0) dividers[i] /= dividers[j];
                }
            }

            // Find the number and print. 
            for (int i = 0; i < dividers.Count; i++)
            {
                number *= dividers[i];
            }
            Console.WriteLine(number);
        }

        static void problem_006()
        {
            /**
            The sum of the squares of the first ten natural numbers is, 12+22+...+102=385
            The square of the sum of the first ten natural numbers is, (1+2+...+10)2=552=3025
            Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025−385=2640.
            Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
            */

            /**
            when 
            (a + b + ... + y + z) * (a + b + ... + y + z) is equal to a^2 + b^2 + ... + y^2 + z^2 + 2 * (ab + ac + ... + xy + xz + yz) 
            then 
            (a + ... + z)^2 - (a^2 + ... + z^2) is equal to 2 * (ab + ac + ... + xy + xz + yz)
            so 
            we will find 2 * (ab + ac + ... + xy + xz + yz).
            */

            int result = 0; // The end result we search for. 
            int upperLimit = 100; // The X naturals numbers. 

            // Calculate the part (ab + ac + ... + xy + xz + yz).
            for (int i = 1; i < upperLimit; i++)
            {
                for (int j = i + 1; j <= upperLimit; j++)
                {
                    result += i * j;
                }
            }

            // Calculate the 2* part. 
            result *= 2;

            // Print the result. 
            Console.WriteLine(result);
        }

        static void problem_007()
        {
            /**
            By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
            What is the 10 001st prime number?
            */

            int n = 10001; // The n-th prime to find. 

            // Container for the prime numbers and the first prime added into it (e.g. 2). 
            List<double> primes = new List<double>();
            primes.Add(2);

            // Go through odd numbers, check for primerity, add to list if prime. 
            for (double checkNumber = 3; primes.Count < n; checkNumber += 2)
            {
                bool isPrime = true; // The number is prime until the opposite has been proven. 
                double sqrtCheckNumber = Math.Sqrt(checkNumber);

                double primesCount = primes.Count; // Qty of primes found. 

                // Go through found primes and try to divide the checkNumver to it.
                for (int j = 0; j < primesCount; j++)
                {
                    // No sense to take the primes greater than sqrt of the number.
                    if (primes[j] > sqrtCheckNumber) break;

                    // If checkNumber % prime == 0 then break. 
                    if (checkNumber % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(checkNumber);

                    // Print progress. 
                    if (primesCount % 100 == 0)
                    {
                        Console.WriteLine(primesCount);
                    }
                }
            }

            // Print the result. 
            Console.WriteLine(primes[primes.Count - 1]);
        }

        static void problem_008()
        {
            /**
            The four adjacent digits in the 1000-digit number that have the greatest product 
            are 9 × 9 × 8 × 9 = 5832.
            73167176531330624919225119674426574742355349194934
            96983520312774506326239578318016984801869478851843
            85861560789112949495459501737958331952853208805511
            12540698747158523863050715693290963295227443043557
            66896648950445244523161731856403098711121722383113
            62229893423380308135336276614282806444486645238749
            30358907296290491560440772390713810515859307960866
            70172427121883998797908792274921901699720888093776
            65727333001053367881220235421809751254540594752243
            52584907711670556013604839586446706324415722155397
            53697817977846174064955149290862569321978468622482
            83972241375657056057490261407972968652414535100474
            82166370484403199890008895243450658541227588666881
            16427171479924442928230863465674813919123162824586
            17866458359124566529476545682848912883142607690042
            24219022671055626321111109370544217506941658960408
            07198403850962455444362981230987879927244284909188
            84580156166097919133875499200524063689912560717606
            05886116467109405077541002256983155200055935729725
            71636269561882670428252483600823257530420752963450
            Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. 
            What is the value of this product?
            */

            // Length of adjacent numbers. 
            int length = 13;
            // The given big number. 
            string bigNumber;
            bigNumber = "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" +
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";
            // Size of the (int)bigNumber. 
            int bigNumSize = bigNumber.Length;
            // The greatest product of the (int)legth adjacent digits in the (int)bigNumSize-digit number.
            double result = 1;
            // Array with the digits of the (int)bigNumber. 
            int[] bigNumberList = Array.ConvertAll(bigNumber.ToCharArray(), c => (int)Char.GetNumericValue(c));
            // The first index of the chain. 
            int index = 0;

            for (int i = 0; i < bigNumSize - length + 1; i++)
            {
                double product = 1;
                for (int j = 0; j < length; j++)
                {
                    product *= bigNumberList[i + j];
                }

                if (product > result)
                {
                    result = product;
                    index = i;
                    Console.WriteLine(index + " - " + result);
                }

                if (i % 100 == 0) Console.WriteLine(i);
            }

            Console.WriteLine(result);
        }
    }
}

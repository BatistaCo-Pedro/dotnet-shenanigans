﻿namespace DotnetShenanigans;

public class PointerArithmetic
{
    static void Run()
    {
        unsafe
        {
            int* values = stackalloc int[20];
            int* p = &values[1];
            int* q = &values[15];
            Console.WriteLine($"p - q = {p - q}");
            Console.WriteLine($"q - p = {q - p}");
        }
        
        // Normal pointer to an object.
        int[] a = [10, 20, 30, 40, 50];
        
        unsafe
        {
            // Must pin object on heap so that it doesn't move while using interior pointers.
            fixed (int* p = &a[0])
            {
                // p is pinned as well as object, so create another pointer to show incrementing it.
                int* p2 = p;
                Console.WriteLine(*p2);
                // Incrementing p2 bumps the pointer by four bytes due to its type ...
                p2 += 1;
                Console.WriteLine(*p2);
                p2 += 1;
                Console.WriteLine(*p2);
                Console.WriteLine("--------");
                Console.WriteLine(*p);
                // Dereferencing p and incrementing changes the value of a[0] ...
                *p += 1;
                Console.WriteLine(*p);
                *p += 1;
                Console.WriteLine(*p);
            }
        }

        Console.WriteLine("--------");
        Console.WriteLine(a[0]);
    }
    }

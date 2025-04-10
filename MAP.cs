using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> employeePay = new Dictionary<string, double>();

        // (ii) Add Homer and Monty
        employeePay["Homer"] = 20000;
        employeePay["Monty"] = 500000;

        employeePay.Remove("Homer");

        if (employeePay.ContainsKey("Carl"))
        {
            employeePay["Carl"] -= 1000;
        }

        foreach (var key in employeePay.Keys.ToList())
        {
            employeePay[key] = employeePay[key] * 0.1;
        }
    }
}

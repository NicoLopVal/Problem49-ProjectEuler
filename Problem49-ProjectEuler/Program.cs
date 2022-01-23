
List<double> allPrimes = new();
allPrimes.Add(2);

for(double i = 3;i < 10000; i +=2)
{
    bool isPrime = true;
    foreach(double prime in allPrimes)
    {
        if(i%prime == 0)
        {
            isPrime = false;
            break;
        }
    }
    if (isPrime)
        allPrimes.Add(i);
}

for(int firstNum = 0; firstNum < allPrimes.Count-2; firstNum++)
{
    if (allPrimes[firstNum] < 1000)
        continue;
    for (int secondNum = firstNum + 1; secondNum < allPrimes.Count - 1; secondNum++)
    {
        if (!HaveSameDigits(allPrimes[firstNum], allPrimes[secondNum]))
            continue;
        double difference = allPrimes[secondNum] - allPrimes[firstNum];
        for (int thirdNum = secondNum +1; thirdNum < allPrimes.Count; thirdNum++)
        {
            if(HaveSameDigits(allPrimes[secondNum], allPrimes[thirdNum]) && difference == allPrimes[thirdNum] - allPrimes[secondNum])
            {
                Console.WriteLine(allPrimes[firstNum].ToString() + allPrimes[secondNum].ToString() + allPrimes[thirdNum].ToString());
            }
        }
    }
}


Console.WriteLine();

bool HaveSameDigits(double x, double y)
{
    bool haveSameDig = true;
    string valueX = x.ToString();
    string valueY = y.ToString();

    Dictionary<int, int> digitCounts = new();
    for(int i = 0; i < 10; i++)
    {
        digitCounts.Add(i, 0);
    }

    for(int i = 0; i < valueX.Length; i++)
    {
        digitCounts[Convert.ToInt32(valueX[i].ToString())]++;
        digitCounts[Convert.ToInt32(valueY[i].ToString())]--;
    }

    for (int i = 0; i < 10; i++)
    {
        if (digitCounts[i] != 0)
        {
            haveSameDig = false;
            break;
        }
    }
    return haveSameDig;
}
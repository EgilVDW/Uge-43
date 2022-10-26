using ClassForFirstSem;

PullData pa = new();
List<string> hej = await pa.GetDataAsync();

for (int i = 0; i < hej.Count(); i++)
{
    Console.WriteLine(hej[i]);
}


Console.ReadLine();
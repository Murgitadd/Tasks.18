Console.WriteLine("Enter a four-digit number:");

int num = int.Parse(Console.ReadLine());

int minlik = num / 1000;
int yuzluk = (num % 1000) / 100;
int onluq = (num % 100) / 10;
int teklik = (num % 10);

Console.WriteLine(minlik+yuzluk+onluq+teklik);

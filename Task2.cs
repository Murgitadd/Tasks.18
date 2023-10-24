Console.WriteLine("Enter a three-digit number:");

int num = int.Parse(Console.ReadLine());

int yuzluk = (num % 1000) / 100;
int onluq = (num % 100) / 10;
int teklik = (num % 10);

if (yuzluk == onluq && onluq == teklik)
{
    Console.WriteLine("Butun ededler eynidir.");
}
else
{
    Console.WriteLine("Eyni olmayan ededler var!");
}

# Dictionary - Словарь

[Краткий экскурс по словарям в C#](https://metanit.com/sharp/tutorial/4.9.php)

Тип данных Словарь в языке C# является обыденным словарём: есть ключ и значение по этому ключу. Ключ обязан быть уникальным.

Данный тип данных содержится в библиотеке `System.Collections.Generic`.

При объявлении словаря указывается тип `Dictionary`, а затем, в треугольных скобках указывается тип данных сначала ключа, а затем тип данных значения по ключу

```C#
// Dictionary<Type of Key, Type of value> dictionary_name;
Dictionary<string, int> stringNumbers;
```

## Синтаксис

Далее будет приведён пример объявления, инициализации и использования словаря в C#:
```C#
using System.Collections.Generic;

// Инициализация без входных параметров
Dictionary<string, int> stringNumbers = new Dictionary<string, int>();

// Инициализация с входными параметрами
Dictionary<int, string> numbers = new Dictionary<int, string>
{
    {1, "One"},
    {2, "Two"},
    {3, "Three"},
    // ...
    // ...
    {10, "Ten"}
};

// Обращение по ключу - индексация по ключу
stringNumbers["One"] = 1;
stringNumbers["Two"] = 2;
stringNumbers["Three"] = 3;
stringNumbers["SecondThree"] = 3; // Значения могут повторяться, ключи - нет!


// Добавление новой строки: ключ, значение по ключу
stringNumbers.Add("Ten", 10);

Console.WriteLine($"{numbers[2]}");
Console.WriteLine($"{stringNumbers["Two"]}");

// Console out
// Two
// 2

// Перебор словаря
foreach (var number in numbers)
{
    Console.WriteLine($"{number.Key}: {number.Value}");
}

// Console out
// 1: One
// 2: Two
// 3: Three
// 10: Ten


// Очистка словаря
numbers.Clear();

foreach (var number in numbers)
{
    Console.WriteLine($"{number.Key}: {number.Value}");
}

// Console out
// 

// Проверка наличия ключа методом ContainsKey
if (!numbers.ContainsKey(10))
{
    numbers.Add(10, "Ten");
}

foreach (var number in numbers)
{
    Console.WriteLine($"{number.Key}: {number.Value}");
}

// Console out
// 10: Ten

string searchedValue = "Ten";

// Проверка наличия значения методом ContainsValue
if (numbers.ContainsValue(searchedValue))
{
    int key = 0;

    foreach (var number in numbers)
    {
        Console.WriteLine($"{number.Key}: {number.Value}");

        if (number.Value == searchedValue)
        {
            key = number.Key;
            return;
        }
    }

    // Удаление строки данных в словаре по ключу методом Remove
    numbers.Remove(key);
}

foreach (var number in numbers)
{
    Console.WriteLine($"{number.Key}: {number.Value}");
}

// Console out
//
```
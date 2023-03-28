# Dictionary - Словарь

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
```
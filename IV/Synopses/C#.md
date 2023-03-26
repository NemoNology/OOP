# ***C# - О языке программирования***

# Общее
**Объектно-ориентированный язык**.  
  
Разработан в 1998-2001 годах Microsoft как язык разработки приложений для платформы [.NET & .NET Core.](https://en.wikipedia.org/wiki/.NET)  
  
C# относится к семье языков с C-подобным синтаксисом, из них его синтаксис наиболее близок к C++ и Java.  
  
Язык имеет статическую типизацию, поддерживает полиморфизм, перегрузку операторов  
(в том числе операторов явного и неявного приведения типа),  
делегаты, атрибуты, события, переменные, свойства, обобщённые типы и методы,  
итераторы, анонимные функции с поддержкой замыканий, LINQ, исключения, комментарии в формате XML.
  
C# в отличие от C++ не поддерживает множественное наследование классов  
(между тем допускается множественная реализация интерфейсов).
  
**Компилируется в байт-код**, а затем обрабатывается исполняемой средой (.NET Virtual Box).

[CLR](https://ru.wikipedia.org/wiki/Common_Language_Runtime) - Исполняющая среда для языков разработки приложений для платформы .NET & .NET Core.

Последняя версия языка: [C# 11](https://learn.microsoft.com/ru-ru/dotnet/csharp/whats-new/csharp-version-history)

*[C# - ru Wiki](https://ru.wikipedia.org/wiki/C_Sharp)*

#
# Типы данных

**Неполная диаграмма типов данных**:  
![Неполная диаграмма типов данных](https://camo.githubusercontent.com/c04650c94baa252eaeae9983a0ea210d058d96131754cedf403cf4fef5e0d4a1/68747470733a2f2f7777772e632d7368617270636f726e65722e636f6d2f55706c6f616446696c652f426c6f67496d616765732f3131323932303132313534383236504d2f43736861727044617461547970657343686172742e706e67)  

*[Система типов C#](https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/types/)*

*[Общие сведения о классах](https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/types/classes)*

*[Операторы объявления](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/statements/declarations)*

Работа с указателями:

* *[Ненадежный код, типы указателей и указатели функций](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/unsafe-code#pointer-types)*
* *[Операторы, связанные с указателями](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/pointer-related-operators)*

*[Exception Класс](https://learn.microsoft.com/ru-ru/dotnet/api/system.exception?view=net-6.0)*

*[Анонимные типы](https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/types/anonymous-types)*

Поддерживает динамическую типизацию, с помощью ключевого слова [dynamic](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/interop/using-type-dynamic).

## Синтаксис:

* **Объявление (и инициализация) переменных простых типов данных**:
    ```C#
    int a;
    int b = 24, c = b + 8;
    a = c * 2;
    float f2 = 0.14f;
    double pi = 15.70796327 / 5;

    string hello;
    string world = ", World!";

    hello = "Hello";
    char c1 = '_';

    // Инициализация объекта класса
    // См. класс Dog ниже
    Dog dog = new Dog("Шарик", "Мой дом", 4);

    var greetings = hello + world; 

    dynamic dyn1 = 123;
    ```
* **Простенькое консольное приложение:**
    ```C#
    Console.Write("Input your's name: ");
    var name = Console.ReadLine();
    Console.Write($"Glad to see you, {name}!");

    Console.ReadLine();
    ```
* **Создание простенького класса:**
    ```C#
    class Dog
    {
        private string _dirtySecret = "Tore the pillow";
        private bool _isSmart = new Random().Next(0, 10) > 6 ? true : false;

        private string _name = "Unknown";
        private string _address = "Unknown";

        public string Name 
        { 	
            get => _name;
        
            set
            {
                if (value == null)
                {
                    value = "Unknown";
                }
                else
                {
                    _name = value;
                }
            }
        }
        
        public string Address
        {
            get => _address;
        
            set
            {
                if (value == null)
                {
                    value = "Unknown";
                }
                else
                {
                    _address = value;
                }
            }
        }

        public byte Age { get; set; }

        public Dog(string name, string address)
        {
            Name = name;
            Address = address;
        }
        
        public Dog(string name, string address, byte age)
        {
            Name = name;
            Address = address;
            Age = age;
        }

        public void Bark()
        {
            Console.WriteLine("Bark!");
        }

        public void WhatsTheDogDoing()
        {
            for (var i = 0; i < new Random().Next(0, 6); i++)
            {
                Bark();
            }
        }

        public void SayAge()
        {
            if (_isSmart)
            {
                for (var i = 0; i < Age; i++)
                {
                    Bark();
                }
            }
            else
            {
                WhatsTheDogDoing();
            }
        }
        
        public Dog GiveBirth(string bornName)
        {
            return new Dog(bornName, Address);
        }
    }
    ```

#
# Using & NuGet - Подключенине библиотек в C#

## Ключевое слово Using

При подключении библиотек, которые содержаться в .NET SDK, 
необходимо использовать ключевое слово using, 
а после указать имя библиотеки, 
которую необходимо подключить

### пример
```C#
using System;
...
using System.Numerics;
```

При подключении собственного .cs файла
необходимо указывать не наименование файла, 
а имя пространства имён, в котором содержится необходимая
программная часть.


```C#
// Additional file - MyClass.cs

namespace MyNameSpace
{
	public class MyClass
	{
		public string Prop1 { get; set; }
		public int Prop2 { get; set; }
		public double Prop3 { get; set; }
		
		public void SumIntegers(int a, int b) => return a + b;
	}
}

// main file - Pogramm.cs

...
using MyNameSpace;
...

NyClass mc = new MyClass();

var res = mc.SumIntegers(2, 6);
```
##

## NuGet

Если необходимой библиотеки, которые отсутствуют в .NET SDK, 
то есть возможность воспользоваться системой управлением пакетов NuGet

### 1: Открываем NuGet

### 2: Ищем необходимую библиотеку

### 3: Устанавливаем

### 4: Используем

##
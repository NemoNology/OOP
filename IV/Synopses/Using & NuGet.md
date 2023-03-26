# Using & NuGet - Подключенине библиотек в C#

## Ключевое слово Using

При подключении библиотек, которые содержаться в .NET SDK, 
необходимо использовать ключевое слово **using**, 
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
а наименование пространства имён, в котором содержится необходимая
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
		
		public int SumIntegers(int a, int b) => a + b;
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
![image](https://user-images.githubusercontent.com/91414886/227812502-848813d0-8138-4cbe-af58-83b6c59155be.png)  
![image](https://user-images.githubusercontent.com/91414886/227812548-0713134b-4d97-42c4-87f2-4f0d3dfec002.png)
### 2: Ищем необходимую библиотеку
![image](https://user-images.githubusercontent.com/91414886/227812564-0e31be16-fa37-4499-b73e-1d5be16fafe3.png)
### 3: Устанавливаем
![image](https://user-images.githubusercontent.com/91414886/227812594-47763d9b-6bb6-42cb-978f-4ce9ef4c8ad4.png)
### 4: Используем
![image](https://user-images.githubusercontent.com/91414886/227812646-6cfe466e-decb-4f09-a761-5676af133d38.png)
##

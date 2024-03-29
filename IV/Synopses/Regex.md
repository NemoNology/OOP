# Regex C# - Регулярные выражения в C#

*Примечание:* не забудьте подключить необходимую библиотеку - System.Text.RegularExpressions

[Сайт для создания и тестирования регулярных выражений](https://regex101.com)  
[Ru Wiki](https://ru.wikipedia.org/wiki/Регулярные_выражения)

## Синтаксис с примерами

Регулярное выражение в C# по синтаксису является строкой со стоящим перед ней символом собаки - @:

```C#
string reg = @"Регулярное выражение";
```
Если не использовать @, то будет происходить обыденный поиск подстроки в строке, без раскрытия потенциала регулярных выражений.

Использование регулярных выражений происходит с помощью метода Regex.Matches().   
Входными параметрами он принимает входную строку, в которой он ищет и само регулярное выражение.

`var m = Regex.Match(inputString, regexExpression);`

### **Операторы в регулярном выражении**

* `@"()"` - Скобки: всё как и в математике - отдельное вычисляемое выражение
* `@"+"` - Сложение: всё как и в математике - сложение выражений
* `@"Привет|Hello"` - Или (ИЛИ): поиск первого выражения или второго. Если есть оба варианта, то найдёт обоих  
* `@"[коля]"` - Один из последовательности: поиск одного символа из последовательности. В данном случае либо найти "к", либо "о", либо "л", либо "я"
* `@"[0-9]"; @"[a-z]"; @"[ё-о]"` - Диапазон символов: поиск любого символа из данного диапазона
* `@"[^коля]"` - Любой кроме тех, что в последовательности (Отрицание - НЕ): поиск любого символа непринадлежащего введённой последовательности. В данном случае найти всё кроме "к", "о", "л", либо "я"
* `@"[^0-9]"` - Любой кроме тех, что в диапазоне (Отрицание - НЕ): поиск любого символа не принадлежащего диапазону. В данном случае любой символ не цифра
* `@"^(Hello)"` - Поиск в начале строки
* `@"(Hello)$"` - Поиск в конце строки
* 
* `@"{n, m}"` - Количество вхождений: поиск выражения стоящего перед этими фигурными скобками, которое должно повториться, как минимум n раз, максимум - m раз. <br/> Если указать только одно число, например `@"(a){4}"`, то поиск будет искать только подстроку `"aaaa"`. <br/> Пример: Найти в начале строки "Hello", но перед этим может стоять любое кол-во пробелов.<br/> *Решение:* `@"^(( ){0,}(Hello))"`. Как видно, можно не задавать верхний предел, но **нижний - обязательно**! Иначе это зачтётся как символы. *В скобки я разложил для того, чтобы было легче ассоциировать и работать с этим как с выражениями*
* `@"."` - Любой символ. *Если хотите поискать точку, то её надо экранировать - `@"\."`*
* `@"\s"` - Любое пустое пространство: пробел, перенос строки и т.д.
* `@"\S"` - Любое непустое пространство. Всё то, что не попадает под `@"\s"` *Если не увидели разницу, то она в регистре. Любое пустое пространство - строчная s, любое непустое пространство - заглавная S*
* `@"\d"` - Любая цифра
* `@"\D"` - Любая не цифра
* `@"\w"` - Любой символ, описывающий слово, включая цифры 
* `@"\W"` - Любой символ, не описывающий слово - пробелы, спецсимволы, знаки препинания...
* `@"(#)?"` - Аналог `@"(#){0,1}"` 
* `@"(#)*"` - Аналог `@"(#){0,}"` 
* `@"(#)+"` - Аналог `@"(#){1,}"`

С остальными операторами ознакомьтесь самостоятельно.

Также, 3-им параметром метод `Regex.Match` может принимать настройки поиска.  
Например, поиск без зависимости от регистра:

`RegexOptions options = RegexOptions.IgnoreCase;`

Также есть другая настройка, которая необходима при поиске в мультистроковой строке:

`RegexOptions options = RegexOptions.Multiline;`

Теперь при использовании оператора `@"^"` поиск будет производиться не в начале всей вводимой строке, а в начале любой из строк строке, тоже самое и с оператором `@"$"` - не конец во всей вводимой строке, а конец любой строки.

В нашем случае будут использоваться обе этих настройки:

`RegexOptions opt = RegexOptions.IgnoreCase | RegexOptions.Multiline;`

### **Примеры C#**

Поиск будет в одной строке data (См. ниже)

* Поиск по слову
    ```C#
    string reg = @"гремучую";
    
    foreach (Match m in Regex.Matches(data, reg))
    {
        Console.WriteLine($"Found {m.Value} at {m.Index}");
    }
    
    // Console out:
    // Found гремучую at 1589
    ```

Если мы вдруг помним, что где-то было какое-то слова, наподобие "бумага", но мы не совсем уверены, что оно употреблялось именно в этом падеже, без дополнительных суффиксов и так далее, то можно произвести поиск по корню.  
Из решения задачи в лобовую: просто вбить искомый корень, но это даст нам в m.Value лишь значение вбитого корня, а захотелось бы вывести всё оставшееся слово.  
К счастью на то регулярные выражения и даны.  
Для того, чтобы засчитать любые приставки и суффиксы в слове необходимо использовать разрешённую последовательность символов в приставке и суффиксе

* Усовершенствованный поиск по слову: поиск по корню слова:
    ```C#
    string reg = @"\w*бума\w*";
    
    foreach (Match m in Regex.Matches(data, reg, opt))
    {
        Console.WriteLine($"Found {m} at {m.Index}");
    }
    
    // Console out:
    // Found бумажка at 178
    // Found бумажка at 2248
    ```

Вышеуказанных операторов должно хватать на решение популярных задач. Но мы разберём ещё одну:
Дан список строк с наименованиями файлов:
```C#
List<string> files = new List<string>
{
   "log_28_03_2023.txt",
   "log_09_03_2023.docx",
   "log_03_03_2023.xml",
   // ...
   // ...
   // ...
   "log_07_02_2023.txt",
   "log_06_02_2023.xml",
   "log_01_02_2023.pdf",
   "log_16_01_2023.txt",
   "log_04_01_2023.md"
}
```
Необходимо найти все файлы за февраль (Наименования представлены в виде Имя_число_месяц_год.расширение)

Делается это достаточно просто:

```C#
RegexOptions opt = RegexOptions.IgnoreCase;

string reg = @"\w*_\d*_02_(\w|\.)*";
    
for (int i = 0; i < files.Count; i++)
{
    Match m = Regex.Match(files[i], reg, opt);

    if (m.Success)
    {
        Console.WriteLine($"Found {m.Value}; File number: {i + 1}");
    }
}

// Console out:
// Found log_07_02_2023.txt; File number: 4
// Found log_06_02_2023.xml; File number: 5
// Found log_01_02_2023.pdf; File number: 6
```

**Строка data**:
```C#
string data =

    // Владимир Маяковский
    // Стихи о советском паспорте
    // 1929 г.
    """
    Я волком бы
                выгрыз
                      бюрократизм.
    К мандатам
              почтения нету.
    К любым
            чертям с матерями
                             катись
    любая бумажка.
                  Но эту...
    По длинному фронту
                      купе
                          и кают
    чиновник
            учтивый
                   движется.
    Сдают паспорта,
                   и я
                      сдаю
    мою
        пурпурную книжицу.
    К одним паспортам —
                        улыбка у рта.
    К другим —
               отношение плевое.
    С почтеньем
                берут, например,
                                паспорта
    с двухспальным
                  английским левою.
    Глазами
            доброго дядю выев,
    не переставая
                кланяться,
    берут,
            как будто берут чаевые,
    паспорт
            американца.
    На польский —
                глядят,
                        как в афишу коза.
    На польский —
                выпяливают глаза
    в тугой
            полицейской слоновости —
    откуда, мол,
                и что это за
    географические новости?
    И не повернув
                 головы качан
    и чувств
            никаких
                    не изведав,
    берут,
          не моргнув,
                     паспорта датчан
    и разных
            прочих
                  шведов.
    И вдруг,
            как будто
                     ожогом,
                            рот
    скривило
            господину.
    Это
        господин чиновник
                          берет
    мою
        краснокожую паспортину.
    Берет —
           как бомбу,
                     берет —
                            как ежа,
    как бритву
              обоюдоострую,
    берет,
          как гремучую
                      в 20 жал
    змею
        двухметроворостую.
    Моргнул
           многозначаще
                       глаз носильщика,
    хоть вещи
             снесет задаром вам.
    Жандарм
           вопросительно
                        смотрит на сыщика,
    сыщик
         на жандарма.
    С каким наслажденьем
                        жандармской кастой
    я был бы
            исхлестан и распят
    за то,
          что в руках у меня
                            молоткастый,
    серпастый
             советский паспорт.
    Я волком бы
               выгрыз
                     бюрократизм.
    К мандатам
              почтения нету.
    К любым
           чертям с матерями
                            катись
    любая бумажка.
                  Но эту...
    Я
     достаю
           из широких штанин
    дубликатом
              бесценного груза.
    Читайте,
            завидуйте,
                      я —
                         гражданин
    Советского Союза.
    """;
```

### **Примеры Notepad++**
* Открываем файл, содержащий информацию, в которой нам предстоит порыться
![image](https://user-images.githubusercontent.com/91414886/228074736-c0d33207-6953-43ab-b4d0-fd92c64dda73.png)  
* Нажимаем "Найти..." (Ctrl + F или "Поиск" -> "Найти...")
![image](https://user-images.githubusercontent.com/91414886/228075005-4cbd3152-334e-4dbd-8a41-8f87725771f5.png)  
* Выбираем "Регулярные выражения"  
![image](https://user-images.githubusercontent.com/91414886/228075156-f18fde3f-e860-4a90-ab73-b2649bb48319.png)  
* В поле "Найти:" пишем наше регулярное выражение без кавычек и без @
![image](https://user-images.githubusercontent.com/91414886/228075641-0583e069-db6a-4f44-95bb-6377dbadec27.png)  
![image](https://user-images.githubusercontent.com/91414886/228075773-1ac771a1-b4a9-4f00-ad58-c1b0c6ada96f.png)  
![image](https://user-images.githubusercontent.com/91414886/228077177-f8a8160a-e2d8-448b-8d26-7dd1933a750f.png)

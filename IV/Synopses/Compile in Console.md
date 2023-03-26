# Compile in Console - Компиляция/Сборка .cs файла через консоль с использованием dotnet

**_Примечание:_ необходимо установить .Net SDK, для использования console dotnet**

## Инструкция

### 0: Выбираем местоположение нашего будущего приложения
![image](https://user-images.githubusercontent.com/91414886/227805558-b6ded591-0948-4f61-b7bd-63b1282f5895.png)
### 1: Создаём проект [определённого шаблона](https://learn.microsoft.com/ru-ru/dotnet/core/tools/dotnet-new-sdk-templates) с использованием комманды dotnet new
![image](https://user-images.githubusercontent.com/91414886/227807728-84e3ddb2-4f43-4c4e-a3f6-fa89b756a28b.png)  
![image](https://user-images.githubusercontent.com/91414886/227807741-6610a1b3-27ba-44c9-9467-49e0deb5332d.png)  
![image](https://user-images.githubusercontent.com/91414886/227807751-01327ab0-be51-4693-973f-e73f36100150.png)
### 2: Пишем нужный нам код в _главном_ файле. Для каждого шаблона он свой
![image](https://user-images.githubusercontent.com/91414886/227807958-c9afc4de-a16c-4179-94ed-8aa808aa9aee.png)
### 3: Заходим в консоль и собираем наш проект, используя комманду dotnet build <Путь к проекту>.
![image](https://user-images.githubusercontent.com/91414886/227808183-96b0f3db-2f7a-4d78-8018-1cd386ad4b0f.png)  
Также можно не указывать путь проекта, есть консоль уже _находится_ в папке с проектом.  
Если необходимо построить и запустить проект, то используйте комманду dotnet run <Путь к проекту>
### 4: Проверяем наличие построенного решения
![image](https://user-images.githubusercontent.com/91414886/227808281-2e13cfdc-46c2-47cc-9bc3-7c7a4bfc97b4.png)  
![image](https://user-images.githubusercontent.com/91414886/227808285-dd4464c8-daca-4b79-97bc-21636440dd12.png)  
![image](https://user-images.githubusercontent.com/91414886/227808290-8b8f9480-8ae1-4fa8-8abe-f4cd7d8e3125.png)  
![image](https://user-images.githubusercontent.com/91414886/227808296-27a52537-0499-419b-a0af-0f16d6b321c1.png)
### 5: Запускаем для проверки
![image](https://user-images.githubusercontent.com/91414886/227808315-44edc89d-5f85-45de-b97d-8806275e9ca6.png)
##

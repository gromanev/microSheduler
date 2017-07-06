# microSheduler
Небольшой планировщик для .NET Core, который позволяет выставлять задачи на повтор через заданное количество времени

# Как пользоваться?
А всё очень просто, есть один метод, в который мы пересылаем Таск с возвращаемым булевым типом, и 2 интервала - при успешном выполнении таска и при неудачном (мало ли, ошибки всякие).
Пример:
```
public class MyClass
{
    public async Task<bool> Init()
    {
        return true;
    }
}

...
var myClass = new MyClass();
MicroMultipleSheduler.Start(myClass.Init, 1, 0.5);
...
```

Я даже выложил пакет на NuGet, просто сделай:
```
Install-Package LynxTeam.microSheduler 
```

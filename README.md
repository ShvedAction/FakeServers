# Создание заглушек для автоматизированных тестов на C#

Этот инструмент предназначен для имитации ответов HTTP серверов во время тестирования. 
Т.е. если Вам необходимо имитировать ответы от связанных систем, то Вы можете поднять локально сервер, создав следующий экземпляр:

```C#
IFakeServer MyFakeServer = new FakeHttpServer("http://localhost:3000/");
```

В этот момент запустится HttpAsyncServer слушающий соответствующий адрес.

### Настройка ожидаемых ответов и запросов для сервера:

```C#
MyFakeServer.ShouldRecived().Post("ожидаемое тело запроса").Response("тело отклика");
```

Теперь сервер на HTTP запрос методом POST и содержанием "ожидаемое тело запроса" ответит: "тело отклика" (единожды).

### Проверка пришедших запросов.

```C#
MyFakeServer.CheckAllReciverConditional();
```

Если хотя бы один запрос не был получен, тогда будет проброшено исключение посредством Assert.Fail("Some receiver conditionals are not met.") из Microsoft.VisualStudio.TestTools.UnitTesting;

Для просмотра актуального списка пришедших запросов Вы можете воспользоваться методом "GetReciveHistory":

```C# 
string[] actualRequests = MyFakeServer.GetReciveHistory();
```

## Подробнее.
Предусмотрена возможность регламентировать заголовки ответа. ([примеры в тестах](FakeHttpServerTests/TestsForAnyIFakeServer.cs))

Также есть возможность сравнивать XML запросы учитывая разные представления и предусмотрен вариант настройки игнорирования значений узлов.([примеры в тестах](FakeHttpServerTests/ReciverConditionalsTests/XMLReciverConditionalTest.cs))

Есть возможность поднимать сервер на удалённой машине.([примеры в тестах](FakeHttpServerTests/RemoteFakeServerTest.cs))

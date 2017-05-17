[![Build status](https://ci.appveyor.com/api/projects/status/ood1asmx791wbdsg/branch/master?svg=true)](https://ci.appveyor.com/project/ShvedAction/fakeservers/branch/master)

# C# Tool for testing HTTP API with shapshots

This tool mocks responses from HTTP API. It's useful to make unit tests of your component, just stub the external APIs with a proxy server:

```C#
IFakeServer MyFakeServer = new FakeHttpServer("http://localhost:3000/");
```

### Requests and Responses Settings

```C#
MyFakeServer.ShouldRecived().Post("request body").Response("response body");
```

The server replies once to a POST-request with the response "response body".

### Incoming requests checks

```C#
MyFakeServer.CheckAllReciverConditional();
```

If the response has not been received then the exception would be raised using `Assert.Fail("Some receiver conditionals are not met.")` from `Microsoft.VisualStudio.TestTools.UnitTesting`.

To look at the actual incoming requests you can use `GetReceiveHistory` method:

```C#
string[] actualRequests = MyFakeServer.GetReceiveHistory();
```

## Details

There're some useful options:

- set HTTP headers ([examples](FakeHttpServerTests/TestsForAnyIFakeServer.cs))
- XML requests with the different object views and skipping some nodes` values ([examples](FakeHttpServerTests/ReceiverConditionalsTests/XMLReciverConditionalTest.cs))
- start a server on remote machine ([examples](FakeHttpServerTests/RemoteFakeServerTest.cs))

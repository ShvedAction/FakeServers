[![Build status](https://ci.appveyor.com/api/projects/status/ood1asmx791wbdsg/branch/master?svg=true)](https://ci.appveyor.com/project/ShvedAction/fakeservers/branch/master)

# The tool for the automatic tests fake plugs creation, made on C#

This tool is to imitate the HTTP answers during the tests. For instance, if you’d need to have fake answers from the related systems, you can raise the local host with the next example:

```C#
IFakeServer MyFakeServer = new FakeHttpServer("http://localhost:3000/");
```

With this command, you would raise the HttpAsyncServer listening appropriate address.

### The repllies and requests settings for the server: 

```C#
MyFakeServer.ShouldRecived().Post("request body").Response("response body");
```

Now the HTTP server would reply for the POST-method request with "request body" (once).

### Incoming requests check. 

```C#
MyFakeServer.CheckAllReciverConditional();
```

If the reply has not been received then the exception would be raised with Assert.Fail("Some receiver conditionals are not met.") из Microsoft.VisualStudio.TestTools.UnitTesting.

For the actual incoming requests list overview you can use the "GetReciveHistory" method with: 

```C# 
string[] actualRequests = MyFakeServer.GetReciveHistory();
```

## Details.
There is an option to manage the HTTP headers.([examples in the tests](FakeHttpServerTests/TestsForAnyIFakeServer.cs))

There is also an option to match the XML requests with the different interpretation taken into account. Also there is an option provided for the node values disregard settings.([examples in the tests](FakeHttpServerTests/ReciverConditionalsTests/XMLReciverConditionalTest.cs))

There is also an option to raise a server on remote machine.([examples in the tests](FakeHttpServerTests/RemoteFakeServerTest.cs))

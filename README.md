SimpleTimer
===========

Javascript like methods for SetTimeout and SetInterval


Simple usage
---------------

Static class and methods to execute code after a timeout (in milliseconds) 

```csharp

SimpleTimer.SetTimeout(() => Debug.WriteLine("Code called once in 10s"), 10000);

```

Static class and methods to execute code in an interval

```csharp

SimpleTimer.SetInterval(() => Debug.WriteLine("Code once every 5s"), 5000);

```

# Circuit Breaker Pattern Sample

A small .NET Core console application demonstrating the usage of the *Circuit Breaker* design pattern.

This example is discussed in [The Circuit Breaker Pattern Part 2 - C# implementation](http://blog.techdominator.com/article/circuit-breaker-pattern-part-2-csharp-implementation.html)

## Principle

A *Circuit Breaker* is an object that wraps an integration point to an external system that is usually remote, prone to failure and can sometimes respond with high latency (3rd party service, database, queue).

This wrapper tracks the availability of the external system and can implement behaviors that stabilizes the system when the external system is down. To learn more please checkout:
 - [The Circuit Breaker Design Pattern - Basic Principle](http://blog.techdominator.com/article/circuit-breaker-pattern-part-1-basic-principle.html)
 - [Circuit Breaker](https://martinfowler.com/bliki/CircuitBreaker.html)

## Building and running the example

In order to run the example you will need to have installed:

- [.NET Core 2 SDK](https://www.microsoft.com/net/download/core)
- the [MongoDB Database engine](https://docs.mongodb.com/manual/installation/)

Please refer to the previous links for platform specific installation instructions.

After cloning the repository, make sure that you have a MongoDB database instance running then execute the following to run the example:
```
cd CircuitBreakerSample
dotnet restore
dotnet build
dotnet run
```
## Configuration 
The [`src/Config.cs`](https://github.com/MissaouiChedy/CircuitBreakerSample/blob/master/src/Config.cs) class contains all the configurable properties of this sample such as the database name and url.

## Behavior

The console application will behave normally when the database is available, it will randomly perform sequential reads and writes. You should see something similar to the following in the console:

```
Written: { Id: 3, Name: 'Baby Roy 3'}
Read => { Id: 3, Name: 'Baby Roy 3'}
Read => { Id: 3, Name: 'Baby Roy 3'}
Read => { Id: 3, Name: 'Baby Roy 3'}
Written: { Id: 7, Name: 'Baby Roy 7'}
Written: { Id: 8, Name: 'Baby Roy 8'}
Written: { Id: 9, Name: 'Baby Roy 9'}
Written: { Id: 10, Name: 'Baby Roy 10'}
```

**By killing the database instance while the program is running** you will observe how the *Circuit Breaker* behaves when the external system is unavailable...

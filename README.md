# Hangfire.MetaExtensions

[![AppVeyor](https://img.shields.io/appveyor/ci/Silvenga/hangfire-metaextensions.svg?maxAge=2592000&style=flat-square)](https://ci.appveyor.com/project/Silvenga/hangfire-metaextensions)

Generic extensions to dynamically store and retrieve arbitrary objects during Hangfire task creation and invocation. 

## Install

```
Install-Package Hangfire.MetaExtensions
```

## Usage

Below is a contrived example of usage:

```csharp
GlobalConfiguration.Configuration
                .UseMetaExtensions();

// ...

IBackgroundJobClient client = // ...
client.AddOrUpdateMeta("key", new object())
      .Enqueue(() => Console.WriteLine());

// You can even update the queue!
client.UseQueue("dynamic-queue")
      .Enqueue(() => Console.WriteLine());

```

> Note that the value must JSON serializable and will be stored in Hangfire via the current storage strategy.

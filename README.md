# Hangfire.MetaExtensions

[![AppVeyor](https://img.shields.io/appveyor/ci/Silvenga/hangfire-metaextensions.svg?maxAge=2592000&style=flat-square)](https://ci.appveyor.com/project/Silvenga/hangfire-metaextensions)

Generic extensions to dynamically store and retrieve arbitrary objects during Hangfire task creation and invocation. 

## Install

Latest releases can be found on [MyGet](https://www.myget.org/F/silvenga/api/v2).

> TODO: Create Nuget.org packages.
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

```

> Note that the value must JSON serializable and will be stored in Hangfire via the current storage strategy.

## TODO

- [ ] Docs
- [ ] Support materializing key-values during invocation
- [X] Nuget package
- [X] Setup CI
- [ ] Test `GlobalConfigurationExtensions`
- [ ] Test using Hangfire directly
- [ ] Detect when overriding built in key-values
- [ ] Update nuspec
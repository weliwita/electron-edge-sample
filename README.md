electron-edge-sample
=====================

Getting Started with electron edge

This is an attempt to get a electron app up and running with .net core. 
I had to use older preview version of dotnet core to get everything up and running.
Need to upgrade the sample when newer versions are supported.

## Running The sample

```
> npm install
> set EDGE_USE_CORECLR=1
> cd core_modules\helloworld
> dotnet restore
> dotnet build
> set EDGE_USE_CORECLR=1
> npm run start
```


### scaffalding and building the core project
```
> cd core_modules\helloworld 
> dotnet new -t Lib
```
Added nessasary code for startup class

```c#
namespace HelloWorld
{
    using System.Threading.Tasks;
    public class Startup
    {
        public async Task<object> Invoke(object input)
        {
            return "Hello from dot net core";
        }
    }
}
```

### common issues
could not load system runtime. 
```
Could not load file or assembly 'System.Runtime, Version=4.1.0.0, ...'
```
You have fall back to .net framework native clr mode. Switch to CoreCLR mode.
```
>set EDGE_USE_CORECLR=1
```
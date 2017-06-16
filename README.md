electron-edge-sample
=====================

Getting Started with electron-edge

This is an attempt to get a electron app up and running with .net core. 
I had to use older preview version of dotnet core `1.0.0-preview2-003121` to get everything up and running.
Need to upgrade the sample if newer versions are supported.

## Running The sample
Please note that this sample run on dotnet core `1.0.0-preview2-003121`. You may try pointing to different versions of core clr in `global.json` file.
```
> npm install
> cd core_modules\helloworld
> dotnet restore
> dotnet build
> set EDGE_USE_CORECLR=1
> npm run start
```

When run, the electron app spit out a console log with the message from core dll
```
Hello from dot net core
```


#### scaffalding the core dll project
```
> cd core_modules\helloworld 
> dotnet new -t Lib
```

Add nessasary code for startup class

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

#### Reference the `startup` class in the js file

```javascript
var helloWorld = edge.func({
  assemblyFile: path.join(__dirname, 'core_modules\\helloworld\\bin\\Debug\\netstandard2.0\\helloworld.dll'),
  typeName: 'HelloWorld.Startup'
});
```

#### common issues you may encounter while running this sample
```
Could not load file or assembly 'System.Runtime, Version=4.1.0.0, ...'
```
You have fall back to .net framework native clr mode. Switch to CoreCLR mode.
```
>set EDGE_USE_CORECLR=1
```

>set EDGE_APP_ROOT=D:\Projects\GitHub\electron-edge-sample\core_modules\helloworld\bin\Debug\netstandard2.0

>set EDGE_DEBUG=1


>dotnet restore -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json -s D:\r\edge\src\double\Edge.js\bin\Release -s https://api.nuget.org/v3/index.json -v Debug
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
  assemblyFile: path.join(__dirname, 'core_modules\\helloworld\\bin\\Debug\\netstandard1.6\\helloworld.dll'),
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

```
A JavaScript error occurred in the main process
Uncaught Exception:
Error: The module '/home/rasika/Work/github/electron-edge-sample/node_modules/electron-edge/build/Release/edge_coreclr.node'
was compiled against a different Node.js version using
NODE_MODULE_VERSION 46. This version of Node.js requires
NODE_MODULE_VERSION 53. Please try re-compiling or re-installing
the module (for instance, using `npm rebuild` or`npm install`).
    at process.module.(anonymous function) [as dlopen] (ELECTRON_ASAR.js:173:20)
    at Object.Module._extensions..node (module.js:598:18)
    at Object.module.(anonymous function) [as .node] (ELECTRON_ASAR.js:173:20)
    at Module.load (module.js:488:32)
    at tryModuleLoad (module.js:447:12)
    at Function.Module._load (module.js:439:3)
    at Module.require (module.js:498:17)
    at require (internal/module.js:20:19)
    at Object.<anonymous> (/home/rasika/Work/github/electron-edge-sample/node_modules/electron-edge/lib/edge.js:51:10)
    at Object.<anonymous> (/home/rasika/Work/github/electron-edge-sample/node_modules/electron-edge/lib/edge.js:172:3)
```

use elecron rebuild to build the package.
`npm install --save-dev electron-rebuild`
and run 
`./node_modules/.bin/electron-rebuild`
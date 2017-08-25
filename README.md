Electron AddOn Sample
======================

`npm install`

plese not that target should be same node-gyp version used in Electron.i.e. electron version found in package.json file or global electron version used.
. You can find cached version inside %UserProfile%\.elecron-gyp folder. Optionaly if cached version is not available you can specify the `dist-url` option as described here.
https://github.com/electron/electron/blob/master/docs/tutorial/using-native-node-modules.md#manually-building-for-electron

`node-gyp configure build --target=1.6.11`

`npm run start`


### TS(2307) Cannot find module or its corresponding type declarations.
Webpack으로 resolve.alias 설정할 때 만약 Typescript 사용중이라면 Typescript에서도 `path`설정을 해줘야 한다 
```
{
  "compilerOptions": {
    // ...
    "paths": {
      "@stories/*": ["./src/stories/*"],
      "@pages/*": ["./src/pages/*"],
    }
  },
  "include": ["src"]
}
```

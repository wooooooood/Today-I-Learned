https://github.com/dotnet/runtime/issues/31326

```
Attempting to JIT compile method ~ while running in aot-only mode.
```
- aot-only mode: Released mode
- System.Text.Json 때문인 것으로 보여짐. Newtonsoft로 바꾸면 되긴함

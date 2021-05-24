```
The referenced project 'Relative path to the referenced project from the current directory' does not exist."
```
- https://stackoverflow.com/questions/6016149/msbuild-resolveprojectreferences-error
- https://docs.microsoft.com/en-US/troubleshoot/visualstudio/general/building-solution-with-multiple-projects-fails

- 원인: `Path.GetFullPath` 길이
- Workaround: 해당 폴더를 바탕화면에 둔다 (path 길이조절..)

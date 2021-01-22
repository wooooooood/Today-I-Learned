# Branch

- 로컬 브랜치 목록 및 현재 브랜치 확인 
```
git branch
```

- remote 브랜치 목록 `-r` | `--remotes`
```
git branch -r
```

- 전체 브랜치 목록 `-a` | `--all`
```
git branch -a
```

- `브랜치이름`브랜치 생성 
```
git branch 브랜치이름
```

- `브랜치이름`브랜치를 만들면서 해당 브랜치로 전환 
```
git checkout -b 브랜치이름
```

- 현재 로컬 브랜치 이름 변경  
```
git branch -m 변경할이름
```

- 브랜치 강제 삭제  
```
git branch -D 삭제할브랜치이름
```

- [pr 브랜치로 checkout하여 확인](https://docs.github.com/en/github/collaborating-with-issues-and-pull-requests/checking-out-pull-requests-locally)  
`upstream` 또는 `origin`  
`ID`는 PR번호 #ID
```
$ git fetch upstream pull/ID/head:BRANCHNAME
```

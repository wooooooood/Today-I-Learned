# Git command
*실전편*

## 1. PR까지의 흐름
### 기본
- Stage 전
```
git diff 파일이름    
```
- Stage
```
git add .           //전체
git add 파일이름

git status          //Stage, unstage 상태확인
```
- Commit
```
git commit
git commit -m "message"
```
- Push
```
git push
```

### Upstream이 따로있는게 아니라 해당 레포 자체에서 같이 작업할때, 같은 브랜치를 여러명이 커밋중일때
```
git checkout origin/SHARED_BRANCH
git pull origin SHARED_BRANCH
git push origin HEAD:SHARED_BRANCH
```

<br />

## 2. 변경사항 적용
- 특정 파일 undo changes (unstage 상태)
```
git checkout 특정파일 이름
```

<br />

- UnStage
```
git reset
git reset --hard    //Force Unstage, Undo changes
```

<br />

- Commit Message 변경 (Commit 후 Push 전, 가장 최근 commit에 대해서)
```
git commit --amend
```

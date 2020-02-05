# Git command
*실전편*

### 1. PR까지의 흐름
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
```
- Push
```
git push
```

<br />

### 2. 변경사항 적용
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

<br />

### 3. 브랜치
- 현재 로컬 브랜치 이름 변경  
```
git branch -m 변경할 이름
```

<br />

- Remote branch 포함한 모든 브랜치 확인
```
git branch -r
```

<br />

### 4. 기타
- commit history 확인
```
git log
git log --oneline    //한줄 로그
```

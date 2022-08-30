- 커밋, 브랜치 스위칭 등 모든 깃 기록이 다나온다
```
git reflog
```

- origin/브랜치A 작업 ->커밋 -> 다른 브랜치(브랜치B)에서 작업 후 브랜치A 돌아왔을 때 커밋한게 없다?
```
git reflog //기록을 본다
git reset --hard commitid //되돌린다
```

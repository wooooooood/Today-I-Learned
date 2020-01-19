# unique

범위 안에서 연속된 수들 중 중복되는 값을 제거, unique한 값만 남긴다.
> Return : An iterator to the element that follows the last element not removed.  
> 참고 : http://www.cplusplus.com/reference/algorithm/unique/

<br />

```cpp
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

vector<int> solution(vector<int> arr) 
{
    unique(arr.begin(), arr.end());

    return arr;
}

int main()
{
    vector<int> result = solution({1,1,3,3,0,1,1});

    for (auto& tmp : result){
        cout<<tmp<<" ";           //1 3 0 1 0 1 1 
    }

    return 0;
}

```
기존 벡터에서 unique를 통해 수정된 부분을 제외하고 그대로 유지된다. (1,3,0,1,0,1,1)->(1,3,0,1)/(0,1,1)
  
<br />
  
### iterator로 중복 범위가 끝나는 부분을 알 수 있다
> Iterators are used to point at the memory addresses of STL containers.  

```cpp
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

vector<int> solution(vector<int> arr) 
{
    vector<int>::iterator it;
    it = unique (arr.begin(), arr.end());   
    arr.resize(distance(arr.begin(),it));

    return arr;
}

int main()
{
    vector<int> result = solution({1,1,3,3,0,1,1});

    for (auto& tmp : result){
        cout<<tmp<<" ";           //1 3 0 1
    }

    return 0;
}

```

<br />

### 응용
> https://programmers.co.kr/learn/courses/30/lessons/12901

```cpp
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

vector<int> solution(vector<int> arr) 
{
    vector<int>::iterator endOfUnique;
    endOfUnique = unique (arr.begin(), arr.end());   
    arr.erase(endOfUnique, arr.end());
    //arr.erase(unique (arr.begin(), arr.end()), arr.end());
    
    //arr.resize(distance(arr.begin(), unique (arr.begin(), arr.end())));

    return arr;
}

int main()
{
    vector<int> result = solution({1,1,3,3,0,1,1});

    for (auto& tmp : result){
        cout<<tmp<<" ";           //1 3 0 1
    }

    return 0;
}
```

# axios 결과값으로 내가 원하는 Type 정하고 싶을때
- axios 함수를 범용적으로 사용하려는 경우
- 핵심: `Promise<AxiosResponse<T>>`
```ts
import axios, { AxiosResponse } from "axios";

export const GetApiAsync = async <T>(
  path: string,
  parameters?: object,
): Promise<AxiosResponse<T>> => {
  return await axios.get(path, {
    params: parameters,
  });
};
```
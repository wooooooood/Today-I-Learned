//https://sosohanya.tistory.com/80
//숫자로부터 02:04 등의 표현을 하기 위함
export const fillZeroToTime = (time: number) => {
  return `${("00" + Math.floor(time / 100)).slice(-2)}:${("00" + (time % 100)).slice(-2)}`;
};

//api로 date를 넘겼을때에도 local date time 으로 제대로 들어가도록 하기 위함
export const getLocalDate = (value: Date) => {
  const newDate = value;
  var now_utc = Date.UTC(
    newDate.getUTCFullYear(),
    newDate.getUTCMonth(),
    newDate.getUTCDate(),
    newDate.getUTCHours(),
    newDate.getUTCMinutes(),
    newDate.getUTCSeconds()
  );
  return new Date(
    new Date(now_utc).getTime() - new Date(now_utc).getTimezoneOffset() * 60000
  );
};

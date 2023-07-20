export function setLocal(key: string, value: string) {
  window.localStorage.setItem(key, value);
}

export function removeLocal(key: string) {
  window.localStorage.removeItem(key);
}

export function getLocal(key: string) {
  return window.localStorage.getItem(key);
}

export function setSession(key: string, value: string) {
  window.sessionStorage.setItem(key, value);
}

export function getSession(key: string) {
  return window.sessionStorage.getItem(key);
}

export function removeSession(key: string) {
  return window.sessionStorage.removeItem(key);
}

export function setCookie(name: string, value, exdays = 30) {
  const d = new Date();
  d.setTime(d.getTime() + exdays * 24 * 60 * 60 * 1000);
  let expires = "expires=" + d.toUTCString();

  document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

export function getCookie(key: string) {
  let name = key + "=";
  let decodedCookie = decodeURIComponent(document.cookie);
  let ca = decodedCookie.split(";");
  for (let i = 0; i < ca.length; i++) {
    let c = ca[i];
    while (c.charAt(0) === " ") {
      c = c.substring(1);
    }
    if (c.indexOf(name) === 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

export function setCookie2(name, value, expireAt = new Date()) {
  document.cookie =
    name + '=' + value + '; path=/; expires=' + expireAt.toUTCString() + ';';
}

export function getCookie2(name) {
  let obj = name + '=';
  let x = 0;
  let endOfCookie;
  while (x <= document.cookie.length) {
    let y = x + obj.length;
    if (document.cookie.substring(x, y) == obj) {
      if ((endOfCookie = document.cookie.indexOf(';', y)) == -1)
        endOfCookie = document.cookie.length;
      return document.cookie.substring(y, endOfCookie);
    }
    x = document.cookie.indexOf(' ', x) + 1;

    if (x == 0) break;
  }
  return '';
}

export function removeCookie(key: string) {
  document.cookie = key + "=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;";
}


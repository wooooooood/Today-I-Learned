# 1. Map app
### TMAP
- doesn't support geocoding
- doesn't support official scheme https://developers.skplanetx.com/community/forum/t-map/view/?ntcStcId=20120822157546

```
tmap://
tmap://search?name=검색어
tmap://route?goalx=경도&goaly=위도&goalname=이름
```
> [안드로이드 지도앱 길안내 연동 (Intent) - Mr. Latte](https://www.mrlatte.net/code/2019/10/26/navigation-route-intent-android.html)

<br />

### Google map
```
comgooglemaps://
comgooglemaps://?q=위도,경도
```
> https://xamgirl.com/quick-tip-launching-google-maps-in-xamarin-forms/

<br />

### Kakao map
```
kakaomap://
kakaomap://look?p=위도,경도
```
> http://apis.map.kakao.com/ios/guide/#urlscheme_open_mapapp

# Publish Xamarin iOS App via Mac VS

**failed to parse altool output. Failed to parse PList data**
1. Update `Visual Studio` & `Xcode` to Latest
2. Match `Build version` & `App version` same
> https://forums.xamarin.com/discussion/172296/app-store-connect-application-loader-publishing-failed-failed-to-parse-altool-output
3. experience) clean, quit VS, Open again, archive, release
4. **높은 확률로 성공하는 case**) bin / obj 파일 삭제 -> Open VS (restores nuget package automatically) -> archive on release mode -> release

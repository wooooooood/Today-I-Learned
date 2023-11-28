"엑셀 파일 pdf로 변환하기"라는 기능을 만들 때, 서버에 MS 엑셀이 설치되어 있는 경우 Interop이라는 것을 사용해서 기능을 구현할 수 있다.

GPT에게 물어봤을때는 아래와 같은 이유로 Interop 사용을 권장하지 않는다. 
1. potential server instability
2. dependency on Excel being installed
3. issues with scalability

하지만 내가 사용해본 누겟들은 다 문제가 있었다

### Spire.XLS
- `NumberToString` 결과가 한자로 나옴
- 무료 버전은 장수 제한 있음 (3장인가)
- 한장만 하기에는 그나마 제일 괜찮음
### iText7 
- 코딩으로 pdf 만드는것만 지원
- office excel 포맷 그대로 출력이 안됨
- 7이전 버전은 자체 버그 있음
### GrapeCity 
- 유료라서 출력된 pdf에 경고문구 있음
- `NumberToString` 결과가 ###로 표시됨"""
### EPPlus 
- 유료라서 실행도 안됨 (License err)

## 누겟
`Microsoft.Office.Interop.Excel` v15.0.4795.1001 사용이 안되어서 `MSOffice.Interop` v15를 사용했다.  
내 컴퓨터의 엑셀 버전은 2019인데 GPT가 말한 아래 내용과 연관이 있는지는 모르겠다.

> version "15.0.4795.1001" is associated with Office 2013. For compatibility with Office 2019, you should ideally use a version that corresponds to or is later than Office 2019.  
The version number "15.0.xxxx.xxxx" is commonly associated with Office 2013, and "16.0.xxxx.xxxx" is typically associated with Office 2016, 2019, and Microsoft 365.  
To find a version that is specifically compatible with Office 2019, you might need to check the official documentation or release notes of the Excel Interop library or try using a version with a "16.0.xxxx.xxxx" version number.  

어쨌든 `MSOffice.Interop`를 사용해도 네임스페이스는 동일하게 `Microsoft.Office.Interop.Excel`를 사용한다.

## 코드

```cs
public string ExceltoPdf(string excelLocation, string outputLocation)
{
    try
    {
        var app = new Microsoft.Office.Interop.Excel.Application();
        app.Visible = false;
        Microsoft.Office.Interop.Excel.Workbook wkb = app.Workbooks.Open(excelLocation);
        wkb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputLocation);

        wkb.Close();
        app.Quit();

        return outputLocation;

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.StackTrace);
        throw ex;
    }
}
```

## Global Assembly Cache (GAC)
```
System.IO.FileNotFoundException: Could not load file or assembly 'office, Version=15.0.0.0, Culture=neutral, PublicKeyToken=-'. The system cannot find the file specified.
```
이런 같은 오류가 뜰 수 있다. 그러면 어셈블리가 GAC안에 있는지 확인해봐야 한다. 커맨드 라인으로는 아래와 같이 확인해볼 수 있다.

1. Open Command Prompt as Administrator:
Right-click on the Command Prompt icon and select "Run as administrator."

2. Navigate to the GAC:
Use the cd command to navigate to the GAC directory. The typical path is C:\Windows\assembly for .NET Framework versions before 4.0 and C:\Windows\Microsoft.NET\assembly for later versions.
```
cd C:\Windows\Microsoft.NET\assembly
```

3. List Assemblies:
Use the gacutil command with the /l switch to list the assemblies in the GAC.
This command will list all the assemblies in the GAC.
```
gacutil /l
```
4. Search for the Assembly:
Look for the 'office' assembly in the list. If it's there, you should see something like:

```
Microsoft.Office.Interop.Excel, Version=15.0.0.0, Culture=neutral, PublicKeyToken=-, processorArchitecture=MSIL
```
The version, culture, and PublicKeyToken should match the version you are referencing in your project.

5. Please note that starting with .NET Framework 4.0, the GAC viewer is not available, and you need to use the gacutil command or explore the GAC folder directly.

6. If you don't find the assembly in the GAC, it might not be installed, or the version might be different. Make sure you have the correct version of the assembly installed.

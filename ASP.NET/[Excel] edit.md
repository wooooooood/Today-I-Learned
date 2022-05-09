- openXML 패키지를 사용한다
- [FileCloner](../C%23/CodeSnippets.FileCloner.cs)를 믹스해서 사용하면 이런 경우를 처리할 수 있다
  1.  서버에서 가지고있는 템플릿에 내용 업데이트해서 다운로드하기
  2.  서버에 가지고있는 엑셀 파일을 업데이트하기

# Set Cell value

- 단 document를 새로 열어서 작업을 하는거라 이걸 많이 하게되면 오래걸리긴 함. open document를 바깥으로 빼서 실행하는게 나을듯

```cs
public static void SetCell<T>(MemoryStream stream, string sheetName, string columnName, uint rowIndex, T value)
{
	using (var document = SpreadsheetDocument.Open(stream, true)){
		var sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().Where(s => s.Name == sheetName);
		var relationshipId = sheets.First().Id.Value;
		WorksheetPart worksheetPart = (WorksheetPart)
		document.WorkbookPart.GetPartById(relationshipId);
		if (worksheetPart != null)
		{
			Cell cell = InsertCellInSheet(columnName, rowIndex, worksheetPart);

			if (typeof(T) == typeof(int))
			{
				cell.CellValue = new CellValue(Convert.ToInt32(value));
				cell.DataType = new EnumValue<CellValues>(CellValues.Number);
			}
			else //string default
			{
				cell.CellValue = new CellValue(value.ToString());
				cell.DataType = new EnumValue<CellValues>(CellValues.String);
			}

			worksheetPart.Worksheet.Save();
		}
	}
}

// https://www.c-sharpcorner.com/blogs/add-update-rows-data-in-excel-using-open-xml-and-c-sharp
public static Cell InsertCellInSheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
{
	Worksheet worksheet = worksheetPart.Worksheet;
	SheetData sheetData = worksheet.GetFirstChild<SheetData>();
	string cellReference = columnName + rowIndex;
	Row row;
	//check whether row exist or not
	//if row exist
	if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
		row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
	//if row does not exist then it will create new row
	else
	{
		row = new Row()
		{
			RowIndex = rowIndex
		};
		sheetData.Append(row);
	}
	//check whether cell exist or not
	//if cell exist
	if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
		return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
	//if cell does not exist
	else
	{
			Cell refCell = null;
			foreach (Cell cell in row.Elements<Cell>())
			{
					if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
					{
							refCell = cell;
							break;
					}
			}
			Cell newCell = new Cell()
			{
					CellReference = cellReference
			};
			row.InsertBefore(newCell, refCell);
			worksheet.Save();
			return newCell;
	}
}
```

# Refresh Cell Formula

- `상황`: 어떤 cell들은 수식을 갖고 있는데, 해당 수식에 ref된 cell의 값이 바뀌는 경우 수식을 한번 더 실행시켜줘야 변경된 값에 맞게 내용이 업데이트된다

```cs
public static void ForceCalculation(MemoryStream stream)
{
	using (var document = SpreadsheetDocument.Open(stream, true)){
    document.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
    document.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
	}
}
```

### Ref

> https://stackoverflow.com/questions/6309109/using-open-xml-how-do-you-insert-a-formula-into-an-excel-2010-worksheet

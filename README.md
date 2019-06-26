[![NuGet](https://img.shields.io/badge/nuget-v0.2.0-blue.svg)](https://www.nuget.org/packages/VanishFlare/)

[Japanese](README.ja.md "Japanese")

# VanishFlare #
A library that develops WinForms quickly.  
[Metroit.Windows.Forms](https://github.com/takiru/Metroit) has been extended.  
The target framework is .NET 4.5.

## Flow values to other controls ##
You can use the FieldControlMaps property to set values from the object selected by the Metroit extension CustomAutoCompleteBox to other controls.

- VfMapTextBox
- VfMapLimitedTextBox
- VfMapNumericTextBox

Property  

|Name                |Meaning                                                    |
|--------------------|--------------------------------------------------------|
|FieldControlMaps    |StringFieldControlMap[]                                 |

StringFieldMap
  - Control
    - Control for which you want to set the value of FieldName.
  - FieldName
    - Property name of the value to be set for the object selected by CustomAutoCompleteBox.

## How to use ##
In the example below, when selecting a value from input candidates for vfMapTextBox1, set the value of Column2 as Text of label1.
```C#
vfMapTextBox1.FieldControlMaps = new StringFieldControlMap[] {
    new StringFieldControlMap() { Control = label1, FieldName = "Column2" }
};

var dt = new DataTable();
dt.Columns.Add("Column1");
dt.Columns.Add("Column2");

var row = dt.NewRow();
row["Column1"] = "aaa1 disp";
row["Column2"] = DateTime.Now;
dt.Rows.Add(row);

row = dt.NewRow();
row["Column1"] = "aaa2 disp";
row["Column2"] = new DateTime(2010, 10, 12);
dt.Rows.Add(row);

vfMapTextBox1.CustomAutoCompleteBox.DataSource = dt;
```

In the following example, when selecting a value from input candidates for vfMapTextBox1, the value of Sample2Data in the EfSample2 class is set as Text of label1.  
You can access the interior of the object hierarchy by using "->".
```C#
public class EfSample1 : DbContext
{
    [Key]
    public string Sample1Data { get; set; }
    public DbSet<EfSample2> EfSample2 { get; set; }
}

public class EfSample2 : DbContext
{
    [Key]
    public string Sample2Data { get; set; }
}
```
```C#
vfMapTextBox1.FieldControlMaps = new StringFieldControlMap[] {
    new StringFieldControlMap() { Control = label1, FieldName = "EfSample2->Sample2Data" }
};

var efList = new List<EfSample1>();
var efSample1 = new EfSample1()
{
    Sample1Data = "Sample1Data"
};
efSample1.EfSample2.Add(new EfSample2()
{
    Sample2Data = "Sample2Data"
});
efList.Add(efSample1);

vfMapTextBox1.CustomAutoCompleteBox.DataSource = efList;
```

If the control to be mapped is a CheckBox, the Checked property is set according to the following criteria.  

| Value                | Setting value |
|-------------------|--------|
| "true"            | true   |
| "false"           | false  |
| "0"               | false  |
| "false", "0"以外  | true   |
| 0                 | false  |
| 0以外             | true   |

If the control to be mapped is a RadioButton, the Checked property is set according to the following criteria.  

| Value                | Setting value |
|-------------------|--------|
| "true"            | true   |
| "false"           | false  |
| "0"               | false  |
| "false", "0"以外  | true   |
| 0                 | false  |
| 0以外             | true   |

When mapping control is ComboBox, Text property or SelectedItem property are set according to the following criteria.  

| Condition         | Setting property |
|--------------------|----------------|
| DataSource == null | Text           |
| DataSource != null | SelectedItem   |

## In the designer, select FieldName from class properties ##
By inheriting the classes below, you can realize the method of selecting the property of any class.  
Properties must match BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty.
 - VfTextBoxBase
 - VfLimitedTextBoxBase
 - VfLNumericTextBoxBase

1. Prepare the target class.
    ```C#
    public class TestListItem
    {
        public string Column1 { get; set; }
        public DateTime Column2 { get; set; }
    }
    ```
1. Prepare a class for mapping properties.
    ```C#
    public sealed class TestListItemFieldControlMap : Vf.Windows.Forms.FieldControlMapBase<TestListItem> { }
    ```
1. Prepare a control that uses the mapping class.
    ```C#
    public class TestListItemTextBox : VfTextBoxBase<TestListItemFieldControlMap> { }
    ```
1. If you check the FieldControlMasps of TestListItemTextBox in the designer, you can see that FieldName is selectable from the class properties.  
    ![prop](./images/prop.png "prop")

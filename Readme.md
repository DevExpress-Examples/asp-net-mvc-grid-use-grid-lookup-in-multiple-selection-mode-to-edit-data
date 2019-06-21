<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [GridData.cs](./CS/Models/GridData.cs) (VB: [GridData.vb](./VB/Models/GridData.vb))
* **[GridLookupPartial.cshtml](./CS/Views/Home/GridLookupPartial.cshtml)**
* [GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to use GridLookup in EditForm in multiple selection mode
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t328613)**
<!-- run online end -->


<p>Starting with v15.1, GridLookup can be automatically bound to a model field that returns an array of values (see  <a href="https://www.devexpress.com/Support/Center/p/T196024">DevexpressEditorsBinder - Support binding multiple values selected in MVC editor extensions to a Model's collection-type property</a>)<br>This example illustrates how to use GridLookup in a multiple selection mode (<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridLookupProperties_SelectionModetopic">SelectionMode</a> is <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridLookupSelectionModeEnumtopic">Multiple</a>) as a GridView editor. The main idea is to use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxGridViewColumn_SetEditItemTemplateContenttopic">MVCxGridViewColumn.SetEditItemTemplateContent</a> method to place GridLookup in EditForm. The same approach will work for a custom EditForm (<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_SetEditFormTemplateContenttopic">GridViewSettings.SetEditFormTemplateContent</a>) as well.<br><br>Note that prior to version 16.1.6, the GridLookupExtension.Bind method doesn't automatically select required keys. It's necessary to assign a delegate method to the PreRender property to manually select the values using the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebDataGridViewSelection_SelectRowByKeytopic">GridViewSelection.SelectRowByKey</a> method. Starting with version 16.1.6, it is sufficient to pass values to bind/select to the GridLookupExtension.Bind method.<br><br></p>


```cs
 //Prior to version 16.1.6 only
 settings.PreRender = (s, e) => {
        MVCxGridLookup lookup = s as MVCxGridLookup;
        for (int i = 0; i < Model.TagIDs.Length; i++)        
            lookup.GridView.Selection.SelectRowByKey(Model.TagIDs[i]);                  
 };
```




```vb
 'Prior to version 16.1.6 only
 settings.PreRender = Sub(s, e)
          Dim lookup As MVCxGridLookup = TryCast(s, MVCxGridLookup)
          For i As Integer = 0 To Model.TagIDs.Length - 1
                lookup.GridView.Selection.SelectRowByKey(Model.TagIDs(i))
          Next i                                                          
 End Sub
```


<br>In order to use client-side unobtrusive JavaScript validation with GridLookup, it's necessary to pass a correct model instance to a partial view. This instance should be of the same type as an item of the collection bound to GridView.<br><br>Controller:<br><br>


```cs
public ActionResult GridLookupPartial(int? KeyParameter) {
      var model = GetModelInstanceByKey(KeyParameter);    
      return PartialView(model);
}
```


 


```vb
Public Function GridLookupPartial(ByVal KeyParameter? As Integer) As ActionResult
	  Dim model = GetModelInstanceByKey(KeyParameter)
	  Return PartialView(model)
End Function
```


<br> PartialView:<br><br>


```cs
@Html.DevExpress().GridLookup(settings=>{
    settings.Name = PropertyName;
}).BindList(...).Bind(Model.PropertyName).GetHtml()
```




```vb
@Html.DevExpress().GridLookup(Sub(settings)
    settings.Name = PropertyName
End Sub).BindList(...).Bind(Model.PropertyName).GetHtml()
```


<p><strong>See also:</strong> <br><a href="https://www.devexpress.com/Support/Center/p/T328413">GridView - How to use GridLookup with single selection mode in EditForm </a><br><br><strong>Web Forms:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E2979">How to use two-way data-bound ASPxGridLookup in edit form of ASPxGridView to edit data</a><br><a href="https://www.devexpress.com/Support/Center/p/E3981">How to use ASPxGridLookup in multiple selection mode as the ASPxGridView editor</a></p>

<br/>



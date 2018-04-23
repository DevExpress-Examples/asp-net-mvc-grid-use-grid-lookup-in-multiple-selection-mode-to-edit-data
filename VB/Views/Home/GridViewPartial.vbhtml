@Imports Ex_2.Models

@Html.DevExpress().GridView(Sub(settings)
    settings.Name = "GridView"
    settings.KeyFieldName = "ID"
    settings.CallbackRouteValues = new With{ .Controller = "Home", .Action = "GridViewPartial" }
    
    settings.SettingsEditing.UpdateRowRouteValues = new With { .Controller = "Home", .Action = "GridViewUpdatePartial" }
    settings.SettingsEditing.DeleteRowRouteValues = new With { .Controller = "Home", .Action = "GridViewDeletePartial" }
    settings.SettingsEditing.AddNewRowRouteValues = new With { .Controller = "Home", .Action = "GridViewInsertPartial" }
    settings.CommandColumn.Visible = true
    settings.CommandColumn.ShowEditButton = true
    settings.CommandColumn.ShowNewButtonInHeader = true
    settings.CommandColumn.ShowDeleteButton = true
    settings.CustomColumnDisplayText = Sub (s, e) 
    
         If e.Column.FieldName = "TagIDs" Then
			Dim tagIDs = CType(e.Value, Integer())
			Dim text = DataProvider.GetTags().Where(Function(t) tagIDs.Contains(t.ID)). Select(Function(t) t.Name).DefaultIfEmpty().Aggregate(Function(a, b) a & ", " & b)
			e.DisplayText = If(text, String.Empty)
   End If
    End Sub
    settings.Columns.Add(Sub(col)
        col.FieldName = "ID"
        col.EditFormSettings.Visible =  DefaultBoolean.False
    End Sub)
    settings.Columns.Add(Sub(col)
        col.FieldName = "TagIDs"
        col.SetEditItemTemplateContent(Sub(container)
          Html.RenderAction("GridLookupPartial", New With { .CurrentID = DataBinder.Eval(container.DataItem, "ID")})
            
        End Sub)
    End Sub)

End Sub).SetEditErrorText(CStr(ViewData("EditError"))).Bind(Model).GetHtml()
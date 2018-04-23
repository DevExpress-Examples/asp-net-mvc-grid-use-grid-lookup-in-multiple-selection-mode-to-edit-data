@modelType Ex_2.Models.GridDataItem
@Html.DevExpress().GridLookup(Sub(settings)

                                  settings.Name = "TagIDs"
                                  settings.Properties.TextFormatString = "{0}:{1}"
                                  settings.Width = Unit.Pixel(400)
                                  settings.GridViewProperties.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridLookupPartial", .CurrentID = Model.ID}
                                  settings.ShowModelErrors = True
                                  settings.KeyFieldName = "ID"
                                  settings.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                  settings.Columns.Add("ID")
                                  settings.Columns.Add("Name")
                                  settings.PreRender = Sub(s, e)
    
                                                           Dim lookup As MVCxGridLookup = TryCast(s, MVCxGridLookup)
                                                           For i As Integer = 0 To Model.TagIDs.Length - 1
                                                               lookup.GridView.Selection.SelectRowByKey(Model.TagIDs(i))
                                                           Next i
                                                           lookup.GridView.Width = lookup.Width
                                                       End Sub
                              End Sub).BindList(ViewData("Tags")).Bind(Model.TagIDs).GetHtml()
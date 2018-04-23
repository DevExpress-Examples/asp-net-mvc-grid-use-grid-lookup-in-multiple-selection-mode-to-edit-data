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
                              End Sub).BindList(ViewData("Tags")).Bind(Model.TagIDs).GetHtml()
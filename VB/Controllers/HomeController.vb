Imports Microsoft.VisualBasic
Imports Ex_2.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Example.Controllers

	Public Class HomeController
		Inherits Controller
		Public Function Index() As ActionResult

			Return View()
		End Function

		Public Function GridViewPartial() As ActionResult
			Dim model = DataProvider.GetGridData()
			Return PartialView(model)
		End Function
		Public Function GridLookupPartial(ByVal CurrentID? As Integer) As ActionResult
			ViewData("Tags") = DataProvider.GetTags()
			Dim model As New GridDataItem() With {.ID = -1, .TagIDs = New Integer(){}}
			If CurrentID > -1 Then
				model = DataProvider.GetGridData().Where(Function(item) item.ID.Equals(CurrentID)).FirstOrDefault()
			End If

			Return PartialView(model)
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewUpdatePartial(ByVal item As GridDataItem) As ActionResult
			Dim model = DataProvider.GetGridData()
			If ModelState.IsValid Then
				Try
					DataProvider.UpdateGrid(item)
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			Else
				ViewData("EditError") = "Please, correct all errors."
			End If
			Return PartialView("GridViewPartial", model)
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewInsertPartial(ByVal item As GridDataItem) As ActionResult
			Dim model = DataProvider.GetGridData()
			If ModelState.IsValid Then
				Try
					DataProvider.InsertGrid(item)
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			Else
				ViewData("EditError") = "Please, correct all errors."
			End If
			Return PartialView("GridViewPartial", model)
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function GridViewDeletePartial(ByVal ID As System.Int32) As ActionResult
			Dim model = DataProvider.GetGridData()

			If ID >= 0 Then
				Try
					DataProvider.DeleteGrid(model.Where(Function(x) x.ID = ID).FirstOrDefault())
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			End If
			Return PartialView("GridViewPartial", model)
		End Function
	End Class
End Namespace

<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>@ViewBag.Title</title>

    @Html.DevExpress().GetStyleSheets(new StyleSheet With { .ExtensionSuite = ExtensionSuite.Editors },
    new StyleSheet With { .ExtensionSuite = ExtensionSuite.GridView })
    @Html.DevExpress().GetScripts(    new Script With { .ExtensionSuite = ExtensionSuite.Editors },
    new Script With  { .ExtensionSuite = ExtensionSuite.GridView })
</head>

<body>
    @RenderBody()
</body>
</html>

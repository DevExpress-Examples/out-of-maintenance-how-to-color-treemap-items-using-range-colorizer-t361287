Imports DevExpress.XtraTreeMap
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Xml.Linq

Namespace RangeColorizerSample
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            CreateTreeMapDataAdapter()
            CreateTreeMapColorizer()
        End Sub

        Private Sub CreateTreeMapDataAdapter()
            Dim dataAdapter As New TreeMapHierarchicalDataAdapter()
            dataAdapter.DataSource = CreateStatistics()

            ' Fill the Mappings collection using mappings specifying 
            ' how to convert data objects to tree map items.
            dataAdapter.Mappings.Add(New TreeMapHierarchicalDataMapping With {.Type = GetType(CountryStatistics), .LabelDataMember = "Name", .ChildrenDataMember = "EnergyStatistics"})
            dataAdapter.Mappings.Add(New TreeMapHierarchicalDataMapping With {.Type = GetType(EnergyInfo), .LabelDataMember = "Type", .ValueDataMember = "Value"})

            treeMap.DataAdapter = dataAdapter
        End Sub

        #Region "#RangeColorizer"
        Private Sub CreateTreeMapColorizer()
            Dim colorizer As New TreeMapRangeColorizer()
            colorizer.Palette = Palette.CreatePalette(Color.FromArgb(110, 201, 90), Color.FromArgb(227, 227, 51), Color.FromArgb(255, 93, 23))
            colorizer.RangeStops.Add(1)
            colorizer.RangeStops.Add(64)
            colorizer.RangeStops.Add(256)
            colorizer.RangeStops.Add(1024)

            treeMap.Colorizer = colorizer
        End Sub
        #End Region ' #RangeColorizer

        Private Function CreateStatistics() As List(Of CountryStatistics)
            Dim statistics As New List(Of CountryStatistics)()
            Dim doc As XDocument = XDocument.Load("..\..\Data\EnergyStatistic.xml")
            For Each xCountry As XElement In doc.Element("ArrayOfEnergyStatistic").Elements("CountryEnergyInfo")
                Dim countryStatistics As New CountryStatistics()
                countryStatistics.Name = xCountry.Attribute("Country").Value
                For Each xEnergyInfo As XElement In xCountry.Elements("EnergyStatistic")
                    countryStatistics.EnergyStatistics.Add(New EnergyInfo With {.Type = xEnergyInfo.Attribute("TypeName").Value, .Value = Convert.ToDouble(xEnergyInfo.Attribute("Value").Value)})
                Next xEnergyInfo
                statistics.Add(countryStatistics)
            Next xCountry
            Return statistics
        End Function
    End Class
End Namespace

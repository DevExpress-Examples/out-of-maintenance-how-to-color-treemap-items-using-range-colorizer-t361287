Imports System.Collections.Generic

Namespace RangeColorizerSample
    Public Class EnergyInfo
        Public Property Type() As String
        Public Property Value() As Double
    End Class

    Public Class CountryStatistics
        Public Property Name() As String


        Private energyStatistics_Renamed As New List(Of EnergyInfo)()
        Public ReadOnly Property EnergyStatistics() As List(Of EnergyInfo)
            Get
                Return energyStatistics_Renamed
            End Get
        End Property
    End Class
End Namespace

Imports System
Imports System.Collections.Generic
Imports System.Linq

Public Class Employee
    Public Property Name As String
    Public Property Department As String
    Public Property Salary As Decimal

    Public Sub New(name As String, department As String, salary As Decimal)
        Me.Name = name
        Me.Department = department
        Me.Salary = salary
    End Sub
End Class

Public Class Payroll
    Private ReadOnly Employees As New List(Of Employee)

    Public Sub AddEmployee(name As String, department As String, salary As Decimal)
        Employees.Add(New Employee(name, department, salary))
    End Sub

    Public Function GetTotalSalary() As Decimal
        Return Employees.Sum(Function(employee) employee.Salary)
    End Function

    Public Function GetAverageSalary() As Decimal
        If Employees.Count = 0 Then
            Return 0
        End If

        Return GetTotalSalary() / Employees.Count
    End Function

    Public Sub PrintReport()
        Console.WriteLine("Payroll Report")
        Console.WriteLine("==============")

        For Each employee In Employees
            Console.WriteLine(
                $"{employee.Name} | {employee.Department} | ${employee.Salary:F2}"
            )
        Next

        Console.WriteLine("==============")
        Console.WriteLine($"Employees: {Employees.Count}")
        Console.WriteLine($"Total Salary: ${GetTotalSalary():F2}")
        Console.WriteLine($"Average Salary: ${GetAverageSalary():F2}")
    End Sub
End Class

Module Program
    Sub Main()
        Dim payroll As New Payroll()

        payroll.AddEmployee("Alice", "Engineering", 6200D)
        payroll.AddEmployee("Brian", "Marketing", 4700.5D)
        payroll.AddEmployee("Clara", "Design", 5300.75D)
        payroll.AddEmployee("David", "Finance", 5800.25D)

        payroll.PrintReport()
    End Sub
End Module
using System;
using OfficeOpenXml;
using System.IO;

//create a login class that picks student ID and password from the studentdata.xlsx file and logs in student.
public class Login : Student
{
    //set base constructor with dummy values
    public Login() :base(0,"","","")
    {

    }
    public Student LoginStudent()
    {
        Console.WriteLine("Enter Student Id:");
        int studentID = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();
        //read student from excel file
        var students = ReadStudentsFromExcel();
        //find the student with given ID and password
        return students.Find(s =>s.StudentID==studentID && s.Password==password);
    }
    private static List<Student> ReadStudentsFromExcel()
    {
        var students = new List<Student>();
        //specify file path
        string filepath = "StudentData.xlsx";

        //read data from excel file
        //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using(var package = new ExcelPackage(new FileInfo(filepath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;

            for(int row=2; row <= rowCount; row++)
            {
                int id = int.Parse(worksheet.Cells[row,1].Value.ToString());
                string name = worksheet.Cells[row,2].Value.ToString();
                string email = worksheet.Cells[row,3].Value.ToString();
                string password = worksheet.Cells[row,4].Value.ToString();

                students.Add(new Student(id, name, email,password));
            }
        }
        return students;
    }
}
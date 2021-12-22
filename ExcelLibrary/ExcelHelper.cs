using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using TouristСenterLibrary.Entity;
using System.Reflection;

namespace ExcelLibrary
{
    public class ExcelHelper : IDisposable
    {
        private Application _excel;
        private Workbook _workbook;
        private _Worksheet _worksheet;
        private Excel.Range _excelRange;
        private string _filePath;

        public ExcelHelper()
        {
            _excel = new Excel.Application();
        }
        public bool Open(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    _workbook = _excel.Workbooks.Open(filePath);
                }
                else
                {
                    _workbook = _excel.Workbooks.Add();
                    _filePath = filePath;


                }

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public bool OpenNewExcel(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    _workbook = _excel.Workbooks.Open(filePath, false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public bool SetParticipant(List<Participant> participants)
        {
            try
            {
                _worksheet = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);
                _worksheet.Name = "Участники";
                _worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                object[,] participantsExport = new object[participants.Count, 4];

                for (int i = 0; i < participants.Count; i++)
                {
                    participantsExport[i, 0] = participants[i].Surname;
                    participantsExport[i, 1] = participants[i].Name;
                    participantsExport[i, 2] = participants[i].Middlename;
                    participantsExport[i, 3] = $"'{participants[i].ClientTelefonNumber}";
                }

                _excelRange = _worksheet.get_Range("A2", Missing.Value);
                _excelRange = _excelRange.get_Resize(participants.Count, 4);
                _excelRange.set_Value(Missing.Value, participantsExport);
                _excelRange.Columns.AutoFit();
                _worksheet.Cells[1, 1] = "Фамилия";
                _worksheet.Cells[1, 2] = "Имя";
                _worksheet.Cells[1, 3] = "Отчество";
                _worksheet.Cells[1, 4] = "Телефон";
                _excel.Visible = true;
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
        public bool SetEquipment(List<HikeEquipment> equipments, List<CountableHikeEquip> countableEquipments)
        {
            try
            {
                //_worksheet = (Excel.Worksheet)_workbook.Worksheets.get_Item(2);
                //_worksheet.Name = "Снаряжение";
                //_worksheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                //object[,] participantsExport = new object[participants.Count, 4];

                //for (int i = 0; i < participants.Count; i++)
                //{
                //    participantsExport[i, 0] = participants[i].Surname;
                //    participantsExport[i, 1] = participants[i].Name;
                //    participantsExport[i, 2] = participants[i].Middlename;
                //    participantsExport[i, 3] = $"'{participants[i].ClientTelefonNumber}";
                //}

                //_excelRange = _worksheet.get_Range("A2", Missing.Value);
                //_excelRange = _excelRange.get_Resize(participants.Count, 4);
                //_excelRange.set_Value(Missing.Value, participantsExport);
                //_excelRange.Columns.AutoFit();
                //_worksheet.Cells[1, 1] = "Фамилия";
                //_worksheet.Cells[1, 2] = "Имя";
                //_worksheet.Cells[1, 3] = "Отчество";
                //_worksheet.Cells[1, 4] = "Телефон";
                //_excel.Visible = true;
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public object[,] GetParticipants()
        {
            object[,] values;
            try
            {
                _worksheet = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);
                Excel.Range startRange = _worksheet.get_Range("A2", Missing.Value);
                Excel.Range ftrRange = startRange.get_End(XlDirection.xlToRight);
                Excel.Range finishRange = ftrRange.get_End(XlDirection.xlDown);
                Excel.Range excelRange = (Excel.Range)_worksheet.get_Range(startRange, finishRange);
                values = (object[,])excelRange.Value2;
                return values;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            values = new object[0, 0];
            return values;
        }


        public void Dispose()
        {
            try
            {
                if (!_excel.Visible)
                {
                    _workbook.Close();
                }                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(_filePath))
            {
                _workbook.SaveAs(_filePath );
                _filePath = null;

            }
            else
            {
                _workbook.Save();
            }
        }
    }
}

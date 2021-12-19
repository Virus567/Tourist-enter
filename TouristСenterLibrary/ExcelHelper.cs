﻿using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using TouristСenterLibrary.Entity;
using System.Reflection;

namespace tourCenter
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
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public object[,] GetParticipants()
        {
            _worksheet = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);
            Excel.Range _excelRange1 = _worksheet.get_Range("A1", Missing.Value);       
            _excelRange1 = _excelRange1.get_End(XlDirection.xlToRight);           
            _excelRange1 = _excelRange1.get_End(XlDirection.xlDown);
         
            string downAddress = _excelRange1.get_Address(
                false, false, XlReferenceStyle.xlA1,
                Type.Missing, Type.Missing);

            _excelRange1 = _excelRange1.get_Range("A1", downAddress);
            object[,] values = (object[,])_excelRange1.Value2;
            return values;
        }


        public void Dispose()
        {
            try
            {
                _workbook.Close();
            } 
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(_filePath))
            {
                _workbook.SaveAs(_filePath);
                _filePath = null;

            }
            else
            {
                _workbook.Save();
            }
        }
    }
}

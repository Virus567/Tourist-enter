using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using TouristСenterLibrary.Entity;
using System.Reflection;
using System.Linq;

namespace ExcelLibrary
{
    public class ExcelHelper : IDisposable
    {
        private Application _excel;
        private Workbook _workbook;
        private _Worksheet _worksheet1;
        private _Worksheet _worksheet2;
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
                    _workbook.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
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

        public bool SetParticipant(List<Participant> participants, int childrenAmount)
        {
            try
            {
                _worksheet1 = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);
                _worksheet1.Name = "Участники";
                _worksheet1.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                object[,] participantsExport = new object[participants.Count, 4];

                for (int i = 0; i < participants.Count; i++)
                {
                    participantsExport[i, 0] = participants[i].Surname;
                    participantsExport[i, 1] = participants[i].Name;
                    participantsExport[i, 2] = participants[i].Middlename;
                    participantsExport[i, 3] = $"'{participants[i].PhoneNumber}";
                }

                _excelRange = _worksheet1.get_Range("A2", Missing.Value);
                _excelRange = _excelRange.get_Resize(participants.Count, 4);
                _excelRange.set_Value(Missing.Value, participantsExport);
                _excelRange.Columns.AutoFit();
                _worksheet1.Cells[1, 1] = "Фамилия";
                _worksheet1.Cells[1, 2] = "Имя";
                _worksheet1.Cells[1, 3] = "Отчество";
                _worksheet1.Cells[1, 4] = "Телефон";
                _worksheet1.Cells[2, 6] = "Количество человек:";
                _worksheet1.Cells[3, 6] = "Количество детей:";
                _worksheet1.Cells[2, 7] = participants.Count;
                _worksheet1.Cells[3, 7] = childrenAmount;
                _worksheet1.Columns.AutoFit();
                _excel.Visible = true;
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
        public bool SetEquipment(Hike hike)
        {
            try
            {              
                _worksheet2 = (Excel.Worksheet)_workbook.Worksheets.get_Item(2);
                _worksheet2.Name = "Снаряжение";
                _worksheet2.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;

                object[,] equipmentExport = new object[hike.CountableHikeEquipList.Count+ hike.EquipmentsList.Count, 2];
                hike.CountableHikeEquipList.OrderBy(e => e.CountableEquipment.Name);
                int count = 0;
                for (int i = 0; i < hike.CountableHikeEquipList.Count; i++)
                {
                    equipmentExport[i, 0] = hike.CountableHikeEquipList[i].CountableEquipment.Name;
                    equipmentExport[i, 1] = hike.CountableHikeEquipList[i].Number;
                    count = i;
                }
                for (int i = count+1; i < hike.EquipmentsList.Count+ hike.CountableHikeEquipList.Count; i++)
                {
                    equipmentExport[i, 0] = hike.EquipmentsList[i-count-1].Name;
                    equipmentExport[i, 1] = 1;
                }

                _excelRange = _worksheet2.get_Range("A2", Missing.Value);
                _excelRange = _excelRange.get_Resize(hike.CountableHikeEquipList.Count + hike.EquipmentsList.Count, 2);
                _excelRange.set_Value(Missing.Value, equipmentExport);
                _excelRange.Columns.AutoFit();
                _worksheet2.Cells[1, 1] = "Наименование";
                _worksheet2.Cells[1, 2] = "Количество";
                _worksheet2.Columns.AutoFit();
                _excel.Visible = true;
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
                _worksheet2 = (Excel.Worksheet)_workbook.Worksheets.get_Item(1);
                Excel.Range startRange = _worksheet2.get_Range("A2", Missing.Value);
                Excel.Range ftrRange = startRange.get_End(XlDirection.xlToRight);
                Excel.Range finishRange = ftrRange.get_End(XlDirection.xlDown);
                Excel.Range excelRange = (Excel.Range)_worksheet2.get_Range(startRange, finishRange);
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
